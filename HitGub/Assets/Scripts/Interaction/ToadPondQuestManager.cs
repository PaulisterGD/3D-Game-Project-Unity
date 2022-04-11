using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadPondQuestManager : Interactable
{
    private ItemObject itemObject;
    // Start is called before the first frame update
    void Start()
    {
        itemObject = GetComponent<ItemObject>();
    }

    // Function that handles dropping off the toad in the pond and playing a dialogue that marks the end of the quest
    void UpdateToad()
    {
        itemObject.OnHandleDropOffItem();
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
	{
        return "Press E to return the toad!";
	}

    //Starts the interaction when the player presses the E button.
    public override void Interact()
	{
        UpdateToad();
	}
}
