using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogQuest : Interactable
{

    private bool questComplete;

    private ItemObject itemObject;
    public DialogueTrigger hedgehogObject;
    public ItemObject hedgehogRequirement;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;

        itemObject = GetComponent<ItemObject>();
    }

    // Function that handles dropping off the worms for the hedgehog and playing a dialogue that marks the end of the quest
    void UpdateHedgehog()
    {
        itemObject.OnHandleDropOffItem();
        hedgehogObject.TriggerDialogue();
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        if (hedgehogRequirement.MeetsRequirements()) { return "Press E to give the worms to the hedgehog!!"; }
        else if (questComplete) { return ""; }
        else { return "Hedgehog needs some worms! Find them!"; }

    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        if (hedgehogRequirement.MeetsRequirements())
        {
            UpdateHedgehog();
            questComplete = true;
        }
        else if (questComplete)
        {
            UpdateHedgehog();
        }
    }
}