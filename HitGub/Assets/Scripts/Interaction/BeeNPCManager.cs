using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeNPCManager : Interactable
{

    public GameObject flowerPlanter;
    public FlowerWaterManager waterManager;
    public DialogueTrigger questStartDialogue, postFlowerDialogue, questEndDialogue;
    public ItemObject giveSeeds, giveWaterBottle;
    public float seedCount = 5;

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
        dialogueDelayOne = 0;
        dialogueDelayTwo = 0;
        questState = QuestState.QuestStart;
    }

	void Update()
	{
		switch (questState)
		{
            case QuestState.QuestStart: break;
            case QuestState.PreFlower: if (!giveSeeds.MeetsRequirements()) { questState = QuestState.PostFlower; } break;
            case QuestState.PostFlower:	
                if (waterBottleGiven) { 
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
            case QuestState.QuestStart: return "Press E to talk to the bee!";
            case QuestState.PreFlower: return "Plant 5 flowers!";
            case QuestState.PostFlower: return "Press E to see what the bee has to say!";
            case QuestState.Watering: return "You need to water the plants!";
            case QuestState.QuestEnd: return "Press E to show the watered flowers to the bee!";
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
                break;
        }
	}

    void QuestStartFunc()
    {
        questStartDialogue.TriggerDialogue();
        dialogueDelayOne++;

        if (dialogueDelayOne > questStartDialogue.dialogue.sentences.Length){
            if (!flowerSeedsGiven) {
                for (int i = 0; i < seedCount; i++) { giveSeeds.OnHandleGiveItem(); }
                flowerSeedsGiven = true;
                questState = QuestState.PreFlower;
            }
        }
    }

    public void PostFlowerStateFunc()
	{
        postFlowerDialogue.TriggerDialogue();
        dialogueDelayTwo++;

        if (dialogueDelayTwo > postFlowerDialogue.dialogue.sentences.Length)
        {
            if (!waterBottleGiven)
            {
                giveWaterBottle.OnHandleGiveItem();
                waterBottleGiven = true;
            }
        }
    }
}
