using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadPondQuestManager : Interactable
{
    private bool questComplete;
    private int dialogueTally;
    private int questID = 7;
    public QuestUIConditionals questUI;
    public QuestUIManager questUIManager;


    private ItemObject itemObject;
    public DialogueTrigger pondObject;
    public ItemObject pondRequirement;
    public GameObject billboard;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;
        dialogueTally = 0;
        itemObject = GetComponent<ItemObject>();
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
    }

    // Function that handles dropping off the toad in the pond and playing a dialogue that marks the end of the quest
    void UpdateToad()
    {
        itemObject.OnHandleDropOffItem();
        pondObject.TriggerDialogue();
        if(dialogueTally < pondObject.dialogue.sentences.Length)
		{
            dialogueTally++;
		}
		else
		{
            billboard.SetActive(false);
            questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[0], questID);
		}
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
	{
        if (pondRequirement.MeetsRequirements()) { return "Return the toad here!"; }
        else if (questComplete) { return ""; }
        else { return "Wait, isn't there meant to be a toad here?"; }
        
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
