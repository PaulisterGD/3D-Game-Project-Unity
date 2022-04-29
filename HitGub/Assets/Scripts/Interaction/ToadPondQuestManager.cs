using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadPondQuestManager : Interactable
{
    private bool questComplete;

    private ItemObject itemObject;
    public DialogueTrigger pondObject;
    public ItemObject pondRequirement;
    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;

        itemObject = GetComponent<ItemObject>();
    }

    // Function that handles dropping off the toad in the pond and playing a dialogue that marks the end of the quest
    void UpdateToad()
    {
        itemObject.OnHandleDropOffItem();
        pondObject.TriggerDialogue();
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
	{
        if (pondRequirement.MeetsRequirements()) { return "Press E to return the toad!"; }
        else if (questComplete) { return ""; }
        else { return "You still need to find the toad!"; }
        
	}

    //Starts the interaction when the player presses the E button.
    public override void Interact()
	{
        if (pondRequirement.MeetsRequirements())
		{
            UpdateToad();
            questComplete = true;
        } 
        else if (questComplete)
		{
            UpdateToad();
		}
	}
}
