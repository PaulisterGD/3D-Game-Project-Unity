using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueNPC : Interactable
{
    //public Light m_light;
    //public bool isOn;
    //public GameObject[] playerModels;

    public dogquest dogQuest;
    public DialogueTrigger questStart, questEnd;
    public GameObject[] billboards = new GameObject[2];
    private int dialogueTallyStart, dialogueTallyEnd;
    private int questID = 6;
    public QuestUIConditionals questUI;
    public QuestUIManager questUIManager;

    private void Start()
	{
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        billboards[0].gameObject.SetActive(true);
        billboards[1].gameObject.SetActive(false);
        dialogueTallyStart = 0;
        dialogueTallyEnd = 0;
	}

	// Function that triggers the Blue NPC's dialogue when the player interacts with it.
	void StartDialogue()
    {
        questStart.TriggerDialogue();
        if(dialogueTallyStart < questStart.dialogue.sentences.Length) dialogueTallyStart++;
		else
		{
            billboards[1].gameObject.SetActive(true);
            questUIManager.SetPopUpSprite(questUI.popUpQuestUI[0]);
            questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[0], questID);
        }
    }

    void EndDialogue()
	{
        questEnd.TriggerDialogue();
        if(dialogueTallyEnd < questEnd.dialogue.sentences.Length) dialogueTallyEnd++;
		else
		{
            billboards[0].SetActive(false);
            questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[1], questID);
		}
	}

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        //if (isOn) return "Press [E] to turn OFF the light\nand make me appear!";
        //return "Press [E] to turn ON the light\nand make me disappear!";
        return "Interact to talk with the dog owner";
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        if (dogQuest.dogReturned)
        {
            EndDialogue();
        }
        else StartDialogue();
    }
}
