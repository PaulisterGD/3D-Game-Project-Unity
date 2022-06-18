using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //Declarations of different components, like the dialogue managers.
    public Animator animator;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    private bool firstLineDone = false;                                     //Boolean that determines whether to START dialogue or CONTINUE it.

    //Classic Unity message, plays once at the start of the instance of the object.
    private void Awake()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        animator = GameObject.FindWithTag("DialogueBox").GetComponent<Animator>();                            //Set up the animator that runs the dialogue box animation.
    }

    //Function that is called when one wants to start a dialogue.
    public void TriggerDialogue()
    {
        //Statement that determines whether we're at the start of the dialogue or not.
        if (!firstLineDone)
        {
            dialogueManager.StartDialogue(dialogue);                        //If yes, START the dialogue.
            firstLineDone = true;                                           //And let the script know we're done with the first line
        }
        else
        {
            dialogueManager.DisplayNextSentence();                          //If no, CONTINUE the dialogue
        }

        if (!animator.GetBool("IsOpen")) { firstLineDone = false; }         //When the dialogue box transitions out of screen, reset the firstLineDone bool.
    }
}