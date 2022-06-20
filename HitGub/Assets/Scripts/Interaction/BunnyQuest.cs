using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyQuest : Interactable
{
    private int dialogueCount, tally;
    private bool questTriggered, questComplete, tickOnce;
    private bool[] bunnyProgressFlags = new bool[4];
    private ItemObject itemObject;
    private int questID = 2;

    public int trashCount;
    public QuestUIConditionals questUIConditionals;
    public QuestUIManager questUIManager;
    public GameObject billboard;
    public DialogueTrigger startBunny, bunnyObject;
    public ItemObject bunnyRequirement;
    public ItemObject[] trash;
    public Animator bunnyAnimator;
    public QuestProgressManager progressManager;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;
        questTriggered = false;
        tickOnce = false;
        dialogueCount = 0;
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        itemObject = GetComponent<ItemObject>();
        progressManager = GameObject.FindObjectOfType<QuestProgressManager>();
    }

    private void Update()
	{
        UpdateTrashCount();
        if (trashCount > 0) ProgressUI(trashCount);
	}

    public void UpdateTrashCount()
	{
        trashCount = 0;
        for (int i = 0; i < trash.Length; i++)
		{
            if (trash[i].MeetsRequirements()) trashCount++;
        }
	}

    public void ProgressUI(int state)
    {
        if (!bunnyProgressFlags[state - 1])
		{
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[state]);
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[state], questID);
            bunnyProgressFlags[state - 1] = true;
		}
    }

	// Function that handles dropping off the worms for the hedgehog and playing a dialogue that marks the end of the quest
	void UpdateBunny()
    {
        itemObject.OnHandleDropOffItem();
        bunnyObject.TriggerDialogue();
        if (tally < bunnyObject.dialogue.sentences.Length) tally++;
        else
        {
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[5], questID);
            bunnyAnimator.Play("Bunny Waving Animation");
            billboard.SetActive(false);
            if (!tickOnce)
            {
                tickOnce = true;
                progressManager.QuestCountUp();
            }
        }
    }

    void StartBunny()
	{
        startBunny.TriggerDialogue();
        if (dialogueCount < 4)
		{
            dialogueCount++;
		}
		else
		{
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[0]);
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[0], questID);
            questTriggered = true;
		}
	}

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        if (bunnyRequirement.MeetsRequirements()) { return "Interact to throw the trash away!!"; }
        else if (questComplete) { return ""; }
        else if (!questTriggered) { return "Interact to talk to the bunny"; }
        else { return "Bunny is stuck! Pick up the trash!"; }
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        if (bunnyRequirement.MeetsRequirements())
        {
            UpdateBunny();
            questComplete = true;
        }
        else if (questComplete)
        {
            UpdateBunny();
        }
        else if (!questTriggered)
		{
            StartBunny();
		}
    }
}
