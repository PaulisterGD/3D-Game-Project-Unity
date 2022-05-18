using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    //Declarations
    public float interactionDistance;       //Determines how far you can be before detecting an interactable.

    public Text interactionText;            //Text object that shows instructions on how to interact with an object.
    public Camera cam;                      

    private Collider intCollision;          //Collider that is set to whichever interactable you're closest to.
    public Transform interactCheck;         //An empty child of the player object that is the base for detection code.
    public LayerMask interactMask;          //A layer mask that is set to "Interactables".
    bool canInteract;                       //The bool that is affected by the interactable detection code.
    public Collider[] interactCollider;     //List of colliders that have been spotted.

    // Update is called once per frame
    void Update()
    {
        //Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
        //RaycastHit hit;

        //First check for whether there's interactables in the vicinity.
        canInteract = Physics.CheckSphere(interactCheck.position, interactionDistance, interactMask);
        
        //bool that controls the interaction instructional text.
        bool successfulHit = false;

        //Code that runs when we've found an interactable
        if (canInteract)
        {
            //List ALL the interactables in range
            interactCollider = Physics.OverlapSphere(interactCheck.position, interactionDistance, interactMask);
            foreach (Collider collider in interactCollider)
            {
                intCollision = collider;
                Debug.Log(intCollision.ToString());     //And print their names on the Debug screen.
            }
            
            //Find the first element in the list of interactables.
            Interactable interactable = intCollision.GetComponent<Interactable>();

            //Found something? Good, run this code then.
            if (interactable != null)
            {
                HandleInteraction(interactable);                        //Run code that determines what kind of interaction needs to be done (click or hold)
                interactionText.text = interactable.GetDescription();   //Give the appropriate instructions to the screen.
                successfulHit = true;                                   //Raise the flag that displays them.
            }
        }

        if (!successfulHit) interactionText.text = "";                  //Check for the above flag.
    }

    //Code that determines how to interact with an object.
    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;                                        //Set the interaction key (in our case, this is haed-coded to E)
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key)) { interactable.Interact(); } //Run the interactable's code when the button is PRESSED.
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key)) { interactable.Interact(); }     //Run the interactable's code when the button is HELD.
                break;
            case Interactable.InteractionType.Auto:
                interactable.Interact();
                break;
            default:
                throw new System.Exception("Unsupported type of interactable.");    //If all else fails, throw an error.
                //break;
        }
    }
}
