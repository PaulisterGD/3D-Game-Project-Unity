using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    public float interactionDistance;

    public Text interactionText;
    public Camera cam;

    private Collider intCollision;
    public Transform interactCheck;
    public LayerMask interactMask;
    bool canInteract;
    public Collider[] interactCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
        //RaycastHit hit;

        canInteract = Physics.CheckSphere(interactCheck.position, interactionDistance, interactMask);
        
        bool successfulHit = false;

        if (canInteract)
        {
            interactCollider = Physics.OverlapSphere(interactCheck.position, interactionDistance, interactMask);
            foreach (Collider collider in interactCollider)
            {
                intCollision = collider;
                Debug.Log(intCollision.ToString());
            }
            
            Interactable interactable = intCollision.GetComponent<Interactable>();

            if (interactable != null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }
        }

        if (!successfulHit) interactionText.text = "";
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key)) { interactable.Interact(); }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key)) { interactable.Interact(); }
                break;
            case Interactable.InteractionType.Minigame:
                //Minigame code goes here (idk if its necessary)
                break;
            default:
                throw new System.Exception("Unsupported type of interactable.");
                //break;
        }
    }
}
