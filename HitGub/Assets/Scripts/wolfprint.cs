using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfprint : Interactable
{
    //public Light m_light;
    //public bool isOn;
    //public GameObject[] playerModels;
    public GameObject billboard;
    public DialogueTrigger dialogueTrigger;
    public int tally, dialogueCount;

	private void Start()
	{
		dialogueCount = dialogueTrigger.dialogue.sentences.Length;
        tally = 0;
	}

	// Function that triggers the Blue NPC's dialogue when the player interacts with it.
	void UpdateDialogue()
    {
        dialogueTrigger.TriggerDialogue();
        if(tally < dialogueCount)
		{
            tally++;
		}
		else
		{
            billboard.SetActive(false);
		}
        /*
        m_light.enabled = isOn;
        foreach (GameObject modelObject in playerModels)
        {
            modelObject.GetComponent<Renderer>().enabled = !isOn;
        }
        */
    }

    //Provides instructions on how to interact and why
    public override string GetDescription()
    {
        //if (isOn) return "Press [E] to turn OFF the light\nand make me appear!";
        //return "Press [E] to turn ON the light\nand make me disappear!";
        return "Interact to talk about the wolf print!";
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        //isOn = !isOn;
        UpdateDialogue();
    }
}
