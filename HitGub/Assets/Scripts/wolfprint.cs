using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfprint : Interactable
{
    //public Light m_light;
    //public bool isOn;
    //public GameObject[] playerModels;

    public DialogueTrigger dialogueTrigger;

    // Function that triggers the Blue NPC's dialogue when the player interacts with it.
    void UpdateDialogue()
    {
        dialogueTrigger.TriggerDialogue();
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
        return "Press E to interact";
    }

    //Starts the interaction when the player presses the E button.
    public override void Interact()
    {
        //isOn = !isOn;
        UpdateDialogue();
    }
}
