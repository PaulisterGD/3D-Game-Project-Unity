using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadPondQuestManager : Interactable
{
    private bool questComplete, tickOnce;
    private int dialogueTally;
    private int questID = 7;
    public QuestUIConditionals questUI;
    public QuestUIManager questUIManager;


    private ItemObject itemObject;
    public DialogueTrigger pondObject;
    public ItemObject pondRequirement;
    public GameObject billboard, toad;
    public QuestProgressManager progressManager;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;
        tickOnce = false;
        dialogueTally = 0;
        itemObject = GetComponent<ItemObject>();
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        progressManager = GameObject.FindObjectOfType<QuestProgressManager>();
    }

    // Function that handles dropping off the toad in the pond and playing a dialogue that marks the end of the quest
    void UpdateToad()
    {
        itemObject.OnHandleDropOffItem();
        pondObject.TriggerDialogue();
        if(dialogueTally < pondObject.dialogue.sentences.Length)
		{
            if (dialogueTally == 0)
            {
                Instantiate(toad, new Vector3(221.138f, 41.219f, 135.723f), new Quaternion(0.089808f, 0.014844f, 0.10548f, 0.990247f));
                var toadAnim = toad.GetComponent<Animator>();
                toadAnim.SetBool("WaveGoodbye", true);
            }
            dialogueTally++;
		}
		else
		{
            billboard.SetActive(false);
            questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[0], questID);
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
