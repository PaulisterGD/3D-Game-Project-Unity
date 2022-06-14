using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverQuest : Interactable
{ 

    private bool questComplete;

    private ItemObject itemObject;
    public DialogueTrigger startQuest, finishQuest;
    public ItemObject beaverRequirement;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;

        itemObject = GetComponent<ItemObject>();
    }

    // Function that handles dropping off the sticks for the beaver and playing a dialogue that marks the end of the quest
    void UpdateBeaver()
    {
        itemObject.OnHandleDropOffItem();
        finishQuest.TriggerDialogue();
    }

    public void StartQuest()
	{
        startQuest.TriggerDialogue();
	}

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        if (beaverRequirement.MeetsRequirements()) { return "Press E to return the sticks to the Beaver!!"; }
        else if (questComplete) { return ""; }
        else { return "Press E to talk to the beaver!"; }

    }

        //Starts the interaction when the player presses the E button.
        public override void Interact()
    {
        if (beaverRequirement.MeetsRequirements())
        {
            UpdateBeaver();
            questComplete = true;
        }
        else if (questComplete)
        {
            UpdateBeaver();
        }
		else
		{
            StartQuest();
		}
    }
}