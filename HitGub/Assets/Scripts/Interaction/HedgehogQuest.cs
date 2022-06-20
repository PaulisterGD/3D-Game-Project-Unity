using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogQuest : Interactable
{

    public bool questComplete, tickOnce;
    private ItemObject itemObject;
    private int endTally, tally;

    public HedgehogUI hedgehogUI;
    public DialogueTrigger startQuest, hedgehogObject;
    public ItemObject hedgehogRequirement;
    public QuestProgressManager progressManager;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;
        tickOnce = false;
        tally = 0;
        endTally = 0;
        itemObject = GetComponent<ItemObject>();
        progressManager = GameObject.FindObjectOfType<QuestProgressManager>();
    }

    void StartQuest()
	{
        startQuest.TriggerDialogue();
        if(tally < startQuest.dialogue.sentences.Length)
		{
            tally++;
		}
        else
		{
            hedgehogUI.QuestStartPopUp();
        }
    }

    // Function that handles dropping off the worms for the hedgehog and playing a dialogue that marks the end of the quest
    void UpdateHedgehog()
    {
        hedgehogObject.TriggerDialogue();
        if(endTally < hedgehogObject.dialogue.sentences.Length) endTally++;
		else
		{
            itemObject.OnHandleDropOffItem();
			if (!tickOnce)
			{
                tickOnce = true;
                progressManager.QuestCountUp();
            }
            
        }
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        if (hedgehogRequirement.MeetsRequirements()) { return "Interact to give the worms to the hedgehog!!"; }
        else if (questComplete) { return ""; }
        else { return "Interact to talk to this poorly hedgehog!"; }

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
		else
		{
            StartQuest();
		}
    }
}