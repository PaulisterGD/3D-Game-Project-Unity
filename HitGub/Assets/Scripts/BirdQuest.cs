using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdQuest : Interactable
{
    private bool questComplete;

    private ItemObject itemObject;
    public DialogueTrigger questStart, questEnd;
    public ItemObject birdRequirement;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;

        itemObject = GetComponent<ItemObject>();
    }

    public void StartQuest()
	{
        questStart.TriggerDialogue();
	}

    // Function that handles dropping off the sticks for the beaver and playing a dialogue that marks the end of the quest
    void FinishQuest()
    {
        itemObject.OnHandleDropOffItem();
        questEnd.TriggerDialogue();
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        if (birdRequirement.MeetsRequirements()) { return "Press E to return the sticks to the Bird!!"; }
        else if (questComplete) { return ""; }
        else { return "Press E to talk to the bird!"; }

    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        if (birdRequirement.MeetsRequirements())
        {
            FinishQuest();
            questComplete = true;
        }
        else if (questComplete)
        {
            FinishQuest();
        }
		else
		{
            StartQuest();
		}
    }
}
