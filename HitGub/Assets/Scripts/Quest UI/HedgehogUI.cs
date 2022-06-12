using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogUI : MonoBehaviour
{
    public QuestUIConditionals questUIConditionals;
    public QuestUIManager questUIManager;
    public ItemObject[] requirementArray;

    private bool[] questFlags;

    // Start is called before the first frame update
    void Start()
    {
        questFlags = new bool[4];
        for (int i = 0; i < questFlags.Length; i++) { questFlags[i] = false; }
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (requirementArray[2].MeetsRequirements()){ QuestProgressPopUp(3); } 
        else if (requirementArray[1].MeetsRequirements()){ QuestProgressPopUp(2); }
        else if (requirementArray[0].MeetsRequirements()){ QuestProgressPopUp(1); }
    }

    public void QuestStartPopUp()
	{
        if (!questFlags[0])
		{
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[0]);
            questFlags[0] = true;
        }
	}

    public void QuestProgressPopUp(int number)
	{
        if (!questFlags[number])
		{
            questUIManager.SetPopUpSprite(questUIConditionals.popUpQuestUI[number]);
            questFlags[number] = true;
        }
	}
}
