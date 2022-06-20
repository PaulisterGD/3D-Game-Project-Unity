using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DropCrumbs : MonoBehaviour
{
    public ItemObject breadCrumbRequirement;
    public GameObject breadcrumb, playerModel;
    public PlayerInteraction interaction;

    public InputActions playerInteract;
    private InputAction interactControl;
    public bool weInteracted;

    private void Awake()
    {
        playerInteract = new InputActions();
    }

    private void OnEnable()
    {
        interactControl = playerInteract.Playercontrol.Interact;
        interactControl.Enable();
        interactControl.performed += Interact;
    }

    private void OnDisable()
    {
        interactControl.Disable();
    }


    public bool breadCrumbFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        if (breadCrumbRequirement.MeetsRequirements())
        {
            breadCrumbFlag = true;
        }
        else 
        {
            breadCrumbFlag = false;
        }

        if (breadCrumbFlag)
        {
            if(weInteracted)
            {
                Instantiate(breadcrumb, new Vector3(playerModel.transform.position.x - 1, playerModel.transform.position.y, playerModel.transform.position.z ),playerModel.transform.rotation); 
            }
        }
        weInteracted = false;

    }

    void Interact(InputAction.CallbackContext context)
    {
        weInteracted = true;
    }

}
