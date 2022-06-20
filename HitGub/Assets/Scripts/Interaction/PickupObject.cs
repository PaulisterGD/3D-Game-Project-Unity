using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : Interactable
{
    private ItemObject itemObject;
    // Start is called before the first frame update
    void Start()
    {
        itemObject = GetComponent<ItemObject>();
    }

    // Function that calls the function that handles picking up items
    void UpdateItem()
    {
        itemObject.OnHandlePickupItem();
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        //if (isOn) return "Press [E] to turn OFF the light\nand make me appear!";
        //return "Press [E] to turn ON the light\nand make me disappear!";
        return "Interact to pick up!";
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        UpdateItem();
    }
}
