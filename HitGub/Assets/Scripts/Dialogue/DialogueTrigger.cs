using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Animator animator;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    private bool firstLineDone = false;

    private void Start()
    {
        animator = FindObjectOfType<Animator>();
    }

    public void TriggerDialogue()
    {
        if(!firstLineDone)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            firstLineDone = true;
        }
        else
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }

        if (!animator.GetBool("IsOpen")) { firstLineDone = false; }
    }
}
