using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeUI : MonoBehaviour
{
    public QuestUIConditionals questUIConditionals;
    public QuestUIManager questUIManager;
    public BeeNPCManager npcManager;
    public ItemObject[] requirementArray;
    public int questID = 2;

    private bool[] questFlags = new bool[2];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < questFlags.Length; i++) { questFlags[i] = false; }
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        npcManager = GameObject.FindObjectOfType<BeeNPCManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcManager.questState == BeeNPCManager.QuestState.PreFlower)
		{
            QuestUIUpdate(0);
		}
        else if (npcManager.questState == BeeNPCManager.QuestState.Watering)
		{
            QuestUIUpdate(1);
		}
    }

    public void QuestUIUpdate(int state)
	{
        if (!questFlags[state])
		{
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[state]);
            questUIManager.SetClipboardSprite(questUIConditionals.clipboardQuestUI[state], questID);
		}
	}
}
