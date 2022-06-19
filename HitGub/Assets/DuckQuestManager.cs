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

    // Start is called before the first frame update
    void Start()
    {
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        billboards[0].SetActive(true);
        billboards[1].SetActive(false);
        dialogueTallyStart = 0;
        dialogueTallyEnd = 0;
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
            breadCrumbs.OnHandleGiveItem();
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
            breadCrumbs.OnHandleDropOffItem();
            billboards[0].SetActive(false);
            billboards[1].SetActive(false);
            questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[1], questID);
        }
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
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