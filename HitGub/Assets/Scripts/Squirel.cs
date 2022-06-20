using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirel : Interactable
{
    //public Light m_light;
    //public bool isOn;
    //public GameObject[] playerModels;

    public QuestUIConditionals questUIConditionals;
    public QuestUIManager questUIManager;
    public GameObject questCompleteDetect;
    public DialogueTrigger startQuestDialogue, endQuestDialogue;
    public int questID = 4;
    private bool questFlag, uiFlag;
    private int questStartTally, questEndTally;


	private void Start()
	{
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        questFlag = false;
        uiFlag = false;
        questStartTally = 0;
        questEndTally = 0;
	}

    // Function that triggers the Blue NPC's dialogue when the player interacts with it.
    void UpdateDialogue()
    {
        questFlag = questCompleteDetect.GetComponent<WiggleTree>().questComplete;
        if (!questFlag)
        {
            startQuestDialogue.TriggerDialogue();
            if(questStartTally < startQuestDialogue.dialogue.sentences.Length) questStartTally++;
			else 
            {
                QuestStartUI();
            }
        }
        else
        {
            endQuestDialogue.TriggerDialogue();
            if (questEndTally < endQuestDialogue.dialogue.sentences.Length) questEndTally++;
			else
			{
                uiFlag = true;
                QuestStartUI();
			}
        }
        /*
        m_light.enabled = isOn;
        foreach (GameObject modelObject in playerModels)
        {
            modelObject.GetComponent<Renderer>().enabled = !isOn;
        }
        */
    }

    public void QuestStartUI()
	{
		if (!uiFlag)
		{
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[0]);
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[0], questID);
		}
        else
        {
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[1], questID);
        }
	}

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        //if (isOn) return "Press [E] to turn OFF the light\nand make me appear!";
        //return "Press [E] to turn ON the light\nand make me disappear!";
        return "Interact with the squirrel!";
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        //isOn = !isOn;
        UpdateDialogue();
    }
}

