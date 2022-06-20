using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckQuestManager : Interactable
{
    public DuckFollowBread ducky;
    public GameObject[] billboards = new GameObject[2];
    public DialogueTrigger questStart, questEnd;
    private int dialogueTallyStart, dialogueTallyEnd;
    private int questID = 3;
    public QuestUIConditionals questUI;
    public QuestUIManager questUIManager;
    public ItemObject breadCrumbs;
    private bool questComplete, breadCrumbsGiven;

    // Start is called before the first frame update
    void Start()
    {
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        billboards[0].SetActive(true);
        billboards[1].SetActive(false);
        dialogueTallyStart = 0;
        dialogueTallyEnd = 0;
        questComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest()
	{
        questStart.TriggerDialogue();
        if(dialogueTallyStart < questStart.dialogue.sentences.Length) dialogueTallyStart++;
		else
		{
            if (!breadCrumbsGiven)
            {
                breadCrumbsGiven = true;
                breadCrumbs.OnHandleGiveItem();
            }
            billboards[1].SetActive(true);
            questUIManager.SetPopUpSprite(questUI.popUpQuestUI[0]);
            questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[0], questID);
        }
	}

    public void FinishQuest()
    {
        questEnd.TriggerDialogue();
        if (dialogueTallyEnd < questEnd.dialogue.sentences.Length) dialogueTallyEnd++;
        else
        {
            billboards[0].SetActive(false);
            billboards[1].SetActive(false);
            breadCrumbs.OnHandleDropOffItem();
            questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[1], questID);
            questComplete = true;
        }
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        if (questComplete) return "";
        else if (ducky.duckReturned) return "The duckies are back! Interact with mama duck!";
        return "Interact to talk with the Mama duck!";
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
		if (!ducky.duckReturned)
		{
            StartQuest();
		}
		else
		{
            FinishQuest();
		}
    }
}
