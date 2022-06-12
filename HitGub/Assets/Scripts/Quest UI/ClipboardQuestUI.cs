using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardQuestUI : MonoBehaviour
{
    public QuestUIManager questUIManager;

    // Start is called before the first frame update
    void Start()
    {
        questUIManager = GameObject.Find("QuestUIManager").GetComponent<QuestUIManager>();
    }

    // Update is called once per frame
    void Update()
    {

	}
}
