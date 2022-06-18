using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadPickUpManager : Interactable
{
    public ItemObject itemObject;
    public DialogueTrigger pickUpDialogue;
    private int dialogueTally;
    private int questID = 7;
    public GameObject[] billboards = new GameObject[2];
    public QuestUIConditionals questUI;
    public QuestUIManager questUIManager;

    // Start is called before the first frame update
    void Start()
    {
        itemObject = GetComponent<ItemObject>();
        pickUpDialogue = GetComponent<DialogueTrigger>();
        dialogueTally = 0;
        billboards[0].gameObject.SetActive(true);
        billboards[1].gameObject.SetActive(false);
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpHandle()
	{
        pickUpDialogue.TriggerDialogue();
        if (dialogueTally < pickUpDialogue.dialogue.sentences.Length)
		{
            dialogueTally++;
		}
		else
		{
            itemObject.OnHandlePickupItem();
            billboards[0].gameObject.SetActive(false);
            billboards[1].gameObject.SetActive(true);
            questUIManager.SetPopUpSprite(questUI.popUpQuestUI[0]);
            questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[0], questID);
        }
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        //if (isOn) return "Press [E] to turn OFF the light\nand make me appear!";
        //return "Press [E] to turn ON the light\nand make me disappear!";
        return "Interact with the toad!";
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        PickUpHandle();
    }

}
