using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeNPCManager : Interactable
{
    private bool tickOnce;
    public GameObject flowerPlanter, billboard;
    public FlowerWaterManager waterManager;
    public DialogueTrigger questStartDialogue, postFlowerDialogue, questEndDialogue;
    public ItemObject giveSeeds, giveWaterBottle;
    public float seedCount = 5, tally;
    public Animator beeAnimator;
    public QuestProgressManager progressManager;


    public enum QuestState
	{
        QuestStart,
        PreFlower,
        PostFlower,
        Watering,
        QuestEnd
	}
    public QuestState questState;

    private float dialogueDelayOne, dialogueDelayTwo;
    private bool flowerSeedsGiven, waterBottleGiven;

    // Start is called before the first frame update
    void Start()
    {
        flowerSeedsGiven = false;
        waterBottleGiven = false;
        tickOnce = false;
        dialogueDelayOne = 0;
        dialogueDelayTwo = 0;
        questState = QuestState.QuestStart;
        beeAnimator = GetComponent<Animator>();
        progressManager = GameObject.FindObjectOfType<QuestProgressManager>();

    }

    void Update()
	{
		switch (questState)
		{
            case QuestState.QuestStart: break;
            case QuestState.PreFlower: if (!giveSeeds.MeetsRequirements()) { questState = QuestState.PostFlower; } break;
            case QuestState.PostFlower:	
                if (waterBottleGiven) {
                    waterManager.WaterCountReset();
                    questState = QuestState.Watering;
                } 
                break;
            case QuestState.Watering:
                //Debug.Log("Waiting for quest competion...");
                bool waterCheck = waterManager.WaterCheck();
                Debug.Log("Check returns " + waterCheck);
                if (waterCheck) {
                    giveWaterBottle.OnHandleDropOffItem();
                    waterManager.WaterCountReset();
                    questState = QuestState.QuestEnd;
                } 
                break;
            case QuestState.QuestEnd: break;
            default:
                Debug.LogError("whoa what's going on? The state machine broke in Update!");
                break;
        }
        //Debug.Log(questState);
	}

	public override string GetDescription()
	{
        switch (questState)
        {
            case QuestState.QuestStart: return "Interact to talk to the bee!";
            case QuestState.PreFlower: return "Plant 5 flowers!";
            case QuestState.PostFlower: return "Interact to see what the bee has to say!";
            case QuestState.Watering: return "You need to water the plants!";
            case QuestState.QuestEnd: return "Interact to show the watered flowers to the bee!";
            default: Debug.LogError("whoa what's going on? The state machine broke in GetDescription!"); return "";
        }
    }
	public override void Interact()
	{
        switch (questState)
		{
            case QuestState.QuestStart:
                QuestStartFunc();
                break;
            case QuestState.PreFlower:
                break;
            case QuestState.PostFlower:
                PostFlowerStateFunc();
                break;
            case QuestState.Watering:
                break;
            case QuestState.QuestEnd:
                questEndDialogue.TriggerDialogue();
                if (tally < questEndDialogue.dialogue.sentences.Length) tally++;
                else
                {
                    billboard.SetActive(false);
                    if (!tickOnce)
                    {
                        tickOnce = true;
                        progressManager.QuestCountUp();
                    }
                }
				break;
			}
	}

    void QuestStartFunc()
    {
        questStartDialogue.TriggerDialogue();
        
        if (dialogueDelayOne < questStartDialogue.dialogue.sentences.Length)
        {
            dialogueDelayOne++;
        }
		else
		{
            if (!flowerSeedsGiven)
            {
                flowerSeedsGiven = true;
                for (int i = 0; i < seedCount; i++) { giveSeeds.OnHandleGiveItem(); }
                questState = QuestState.PreFlower;
            }
        }
    }

    public void PostFlowerStateFunc()
	{
        postFlowerDialogue.TriggerDialogue();

        if (dialogueDelayTwo < postFlowerDialogue.dialogue.sentences.Length)
        {
            dialogueDelayTwo++;
        }
		else
		{
            if (!waterBottleGiven)
            {
                waterBottleGiven = true;
                giveWaterBottle.OnHandleGiveItem();
            }
        }
    }
}
