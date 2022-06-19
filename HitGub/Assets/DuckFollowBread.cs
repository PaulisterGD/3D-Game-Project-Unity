using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckFollowBread : MonoBehaviour
{
    public ItemObject itemObject;
    public GameObject BreadCrumb, mamaDuck;
    public Transform target;
    public bool duckReturned;
    private bool uiUpdated;
    NavMeshAgent nav;

    private int questID = 3;
    public QuestUIConditionals questUI;
    public QuestUIManager questUIManager;

    // Start is called before the first frame update
    void Start()
    {
        questUIManager = GameObject.FindObjectOfType<QuestUIManager>();
        nav = GetComponent<NavMeshAgent>();
        SetTarget();
        duckReturned = false;
        uiUpdated = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        if (target != null || target != transform) nav.SetDestination(target.transform.position);
    }

    void SetTarget()
	{
        BreadCrumb = GameObject.FindWithTag("BreadCrumb");
        if (BreadCrumb != null)
        {
            float distance = Vector3.Distance(transform.position, BreadCrumb.transform.position);
            float goalDistance = Vector3.Distance(transform.position, mamaDuck.transform.position);
            if ( goalDistance < 20 )
            {
                target = mamaDuck.GetComponent<Transform>();
                duckReturned = true;
            }
            else if ( distance < 15 )
			{
                target = BreadCrumb.GetComponent<Transform>();
                if (!uiUpdated) UpdateQuest();
            }
        }
        else target = transform;

        
        
    }

	public void UpdateQuest()
	{
        questUIManager.SetPopUpSprite(questUI.popUpQuestUI[0]);
        questUIManager.SetClipboardSprite(questUI.clipboardQuestUI[0], questID);
        uiUpdated = true;
	}

	void OnTriggerEnter (Collider ducktrigger) 
    {
        if(ducktrigger.name == "mama duck")
		{
            target = ducktrigger.transform;
            
		}
    }
}
