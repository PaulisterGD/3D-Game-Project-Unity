using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdQuest : Interactable
{
    private bool questComplete;
    private bool[] uiFlags = new bool[5];
    private ItemObject itemObject;
    private int questID = 8;
    private int startDialogueCount, finishDialogueCount, startTally, finishTally;

    public GameObject billboard;
    public ItemObject[] birdRequirementArray;
    public QuestUIConditionals questUIConditionals;
    public QuestUIManager questUIManager;
    public DialogueTrigger questStart, questEnd;
    public ItemObject birdRequirement;

    // Start is called before the first frame update
    void Start()
    {
        startTally = 0;
        finishTally = 0;
        startDialogueCount = questStart.dialogue.sentences.Length;
        finishDialogueCount = questEnd.dialogue.sentences.Length;
        questComplete = false;
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        itemObject = GetComponent<ItemObject>();
    }

	void Update()
	{
        if (birdRequirementArray[4].MeetsRequirements()) { QuestProgress(5); }
        else if (birdRequirementArray[3].MeetsRequirements()) { QuestProgress(4); }
        else if (birdRequirementArray[2].MeetsRequirements()) { QuestProgress(3); }
        else if (birdRequirementArray[1].MeetsRequirements()) { QuestProgress(2); }
        else if (birdRequirementArray[0].MeetsRequirements()) { QuestProgress(1); }
    }

	public void StartQuest()
	{
        questStart.TriggerDialogue();
		if (startTally < startDialogueCount) startTally++;
        else
		{
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[0]);
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[0], questID);
		}
	}

    public void QuestProgress(int number)
    {
        if (!uiFlags[number - 1])
        {
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[number]);
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[number], questID);
            uiFlags[number - 1] = true;
        }
    }

    // Function that handles dropping off the sticks for the beaver and playing a dialogue that marks the end of the quest
    void FinishQuest()
    {
        itemObject.OnHandleDropOffItem();
        questEnd.TriggerDialogue();
        if (finishTally < finishDialogueCount) finishTally++;
        else billboard.SetActive(false);
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
