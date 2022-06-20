using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButterflyManager : Interactable
{
    private bool startDone, questComplete, allComplete;
    private int dialogueTallyStart, dialogueTallyEnd;
	public DialogueTrigger questStart, questEnd;
    public Sprite[] billboardSprites = new Sprite[2];
    public Image billboard;
    public ButtonBehaviour magGlass;
    public Animator animator;
    public GameObject butterfly;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTallyStart = 0;
        dialogueTallyEnd = 0;
        startDone = false;
        questComplete = false;
        allComplete = false;
        billboard.gameObject.SetActive(true);
        billboard.sprite = billboardSprites[0];
        animator = butterfly.GetComponent<Animator>();
        animator.SetBool("QuestDone", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (magGlass.zoomCheck && startDone)
        {
            questComplete = true;
            billboard.sprite = billboardSprites[0];
        }
    }

    public void StartDialogue()
	{
        questStart.TriggerDialogue();
        if(dialogueTallyStart < questStart.dialogue.sentences.Length) dialogueTallyStart++;
		else
		{
            billboard.sprite = billboardSprites[1];
            startDone = true;
		}
	}

    public void EndDialogue()
	{
        if(dialogueTallyEnd < questEnd.dialogue.sentences.Length) dialogueTallyEnd++;
        else
		{
            allComplete = true;
            billboard.gameObject.SetActive(false);
            animator.SetBool("QuestDone", true);
        }
    }

	public void OnBecameVisible()
	{
        
    }

	public override string GetDescription()
    {
        if (allComplete) return "";
        else if (questComplete) return "You did it! Interact to tell dad what you see!";
        else if (startDone) return "Press the magnifying glass button!";
        else return "Oh look! A cute butterfly! Let's interact with it";
    }
    public override void Interact()
    {
		if (!questComplete)
		{
            StartDialogue();
		}
        else if (questComplete)
		{
            EndDialogue();
		}
    }
}
