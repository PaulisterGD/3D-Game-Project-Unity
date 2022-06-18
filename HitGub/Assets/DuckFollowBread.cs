using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckFollowBread : MonoBehaviour
{
    public GameObject BreadCrumb;
    public Transform target;
    private bool duckReturned;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        BreadCrumb = GameObject.FindWithTag("BreadCrumb");
        target = BreadCrumb.GetComponent<Transform>();
        duckReturned = false;
    }

    // Update is called once per frame
    void Update()
    {
        BreadCrumb = GameObject.FindWithTag("BreadCrumb");
        target = BreadCrumb.GetComponent<Transform>();
        nav.SetDestination(target.transform.position);
    }

    void OnTriggerEnter (Collider ducktrigger) {
        if(ducktrigger.gameObject.name == "big mama duck")
		{
            target = ducktrigger.transform;
            nav.SetDestination(target.transform.position);
            duckReturned = true;
        }
    }
}
