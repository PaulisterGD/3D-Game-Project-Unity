using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerQuestManager : Interactable
{

    public DialogueTrigger warningDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void WarningDialogue()
    {
        warningDialogue.TriggerDialogue();
    }

    public override string GetDescription()
    {
        return "";
    }

    public override void Interact()
    {
        WarningDialogue();
    }

}
