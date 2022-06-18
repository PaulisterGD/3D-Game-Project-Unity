using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckFollowBread : MonoBehaviour
{
    public ItemObject itemObject;
    public GameObject BreadCrumb;
    public Transform target;
    public bool duckReturned;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        SetTarget();
        duckReturned = false;
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
        if (BreadCrumb != null) target = BreadCrumb.GetComponent<Transform>();
        else target = transform;
    }

    void OnTriggerEnter (Collider ducktrigger) 
    {
        if(ducktrigger.name == "mama duck")
		{
            target = ducktrigger.transform;
            duckReturned = true;
		}
    }
}
