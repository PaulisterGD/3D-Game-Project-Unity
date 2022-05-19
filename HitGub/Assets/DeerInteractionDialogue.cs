using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerInteractionDialogue : Interactable
{

    public DialogueTrigger infoDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void InfoDialogue()
    {
        infoDialogue.TriggerDialogue();
    }

    public override string GetDescription()
    {
        return "";
    }

    public override void Interact()
    {
        InfoDialogue();
    }

}

