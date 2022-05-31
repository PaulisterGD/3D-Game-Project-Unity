using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckFollowBread : MonoBehaviour
{
    public GameObject BreadCrumb;
    public Transform target;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        BreadCrumb = GameObject.FindWithTag("BreadCrumb");
        target = BreadCrumb.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        BreadCrumb = GameObject.FindWithTag("BreadCrumb");
        target = BreadCrumb.GetComponent<Transform>();
        nav.SetDestination(BreadCrumb.transform.position);
    }
}
