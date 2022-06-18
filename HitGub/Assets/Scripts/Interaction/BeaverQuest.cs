using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverQuest : Interactable
{ 
    private bool questComplete;
    private ItemObject itemObject;
    private int tally, questID;
    private bool[] beaverUIFlags = new bool[5];

    public ItemObject[] beaverRequirementArray;
    public QuestUIConditionals questUIConditionals;
    public QuestUIManager questUIManager;
    public GameObject billboard;
    public DialogueTrigger startQuest, finishQuest;
    public ItemObject beaverRequirement;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;
        tally = 0;
        questID = 5;
        itemObject = GetComponent<ItemObject>();
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
    }

    void Update()
    {
        if (beaverRequirementArray[4].MeetsRequirements()) { BeaverQuestProgress(5); }
        else if (beaverRequirementArray[3].MeetsRequirements()) { BeaverQuestProgress(4); }
        else if (beaverRequirementArray[2].MeetsRequirements()) { BeaverQuestProgress(3); }
        else if (beaverRequirementArray[1].MeetsRequirements()) { BeaverQuestProgress(2); }
        else if (beaverRequirementArray[0].MeetsRequirements()) { BeaverQuestProgress(1); }
    }

    public void BeaverQuestProgress(int number)
    {
        if (!beaverUIFlags[number - 1])
        {
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[number]);
            beaverUIFlags[number - 1] = true;
        }
    }

    // Function that handles dropping off the sticks for the beaver and playing a dialogue that marks the end of the quest
    void UpdateBeaver()
    {
        itemObject.OnHandleDropOffItem();
        finishQuest.TriggerDialogue();
        if (tally < finishQuest.dialogue.sentences.Length) tally++;
        else
        {
            billboard.SetActive(false);
            questUIManager.SetClipboardSprite(null, questID);
        }
    }

    public void StartQuest()
	{
        startQuest.TriggerDialogue();
        if (tally < startQuest.dialogue.sentences.Length) tally++;
        else
        {
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[0]);
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[0], questID);
        }
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