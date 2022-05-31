using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeNPCManager : Interactable
{
    public GameObject flowerObject;
    public DialogueTrigger questStartDialogue, postFlowerDialogue, questEndDialogue;
    public ItemObject giveSeeds, giveWaterBottle;
    public float seedCount = 5;
    public float dialogueDelay = 0;
    public float xRand, zRand, lowBound, highBound;

    public enum QuestState
	{
        QuestStart,
        PreFlower,
        PostFlower,
        QuestEnd
	}
    public QuestState questState;

    private bool flowerSeedsGiven, waterBottleGiven;

    // Start is called before the first frame update
    void Start()
    {
        flowerSeedsGiven = false;
        waterBottleGiven = false;
        lowBound = -5.0f;
        highBound = 5.0f;
        questState = QuestState.QuestStart;
    }


    // Update is called once per frame
    void QuestStartFunc()
    {
        questStartDialogue.TriggerDialogue();
        dialogueDelay++;
        
        if (dialogueDelay > 3)
		{
            if (!flowerSeedsGiven)
            {
                for (int i = 0; i < seedCount; i++)
                {
                    giveSeeds.OnHandleGiveItem();
                }
                flowerSeedsGiven = true;
                questState = QuestState.PreFlower;
            }
        }
        /*
        switch (questState)
		{
            case QuestState.QuestStart:
                
                break;
            case QuestState.PostFlower:
                postFlowerDialogue.TriggerDialogue();
                if (!waterBottleGiven) { giveWaterBottle.OnHandleGiveItem(); waterBottleGiven = true; }
                giveWaterBottle.OnHandleGiveItem();
                break;
            case QuestState.QuestEnd:
                questEndDialogue.TriggerDialogue();
                break;
            default:
                break;
        }
        */
    }

    public void FlowerPlanting()
	{
        xRand = Random.Range(lowBound, highBound);
        zRand = Random.Range(lowBound, highBound);
        Instantiate(flowerObject, new Vector3(transform.position.x + xRand, transform.position.y, transform.position.z + zRand), transform.rotation);
    }

	public override string GetDescription()
	{
        switch (questState)
        {
            case QuestState.QuestStart:
                return "Press E to talk to the bee!";
            case QuestState.PreFlower:
                return "Plant 5 flowers!";
            case QuestState.PostFlower:
                return "Press E to see what the bee has to say!";
            case QuestState.QuestEnd:
                return "Press E to show the watered flowers to the bee!";
            default:
                Debug.LogError("whoa what's going on? The state machine broke!");
                return "";
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
                break;
            case QuestState.QuestEnd:
                break;
        }
        
	}
}
