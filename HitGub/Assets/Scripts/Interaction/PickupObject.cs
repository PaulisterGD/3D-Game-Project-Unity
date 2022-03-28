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

    // Update is called once per frame
    void UpdateItem()
    {
        itemObject.OnHandlePickupItem();
    }

    public override string GetDescription()
    {
        //if (isOn) return "Press [E] to turn OFF the light\nand make me appear!";
        //return "Press [E] to turn ON the light\nand make me disappear!";
        return "Press E to pick up!";
    }

    public override void Interact()
    {
        UpdateItem();
    }
}
