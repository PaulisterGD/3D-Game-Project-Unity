using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyQuest : Interactable
{
    private int dialogueCount;
    private bool questTriggered, questComplete;
    private ItemObject itemObject;

    public GameObject billboard;
    public DialogueTrigger startBunny, bunnyObject;
    public ItemObject bunnyRequirement;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;
        questTriggered = false;
        dialogueCount = 0;

        itemObject = GetComponent<ItemObject>();
    }

    // Function that handles dropping off the worms for the hedgehog and playing a dialogue that marks the end of the quest
    void UpdateBunny()
    {
        itemObject.OnHandleDropOffItem();
        bunnyObject.TriggerDialogue();
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
            questTriggered = true;
		}
	}

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        if (bunnyRequirement.MeetsRequirements()) { return "Press E to throw the trash away!!"; }
        else if (questComplete) { return ""; }
        else if (!questTriggered) { return "Press E to talk to the bunny"; }
        else { return "Bunny is stuck! Pick up the trash!"; }
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        if (bunnyRequirement.MeetsRequirements())
        {
            UpdateBunny();
            questComplete = true;
            billboard.SetActive(false);
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
