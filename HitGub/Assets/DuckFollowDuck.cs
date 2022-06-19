using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckFollowDuck : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject ducky;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = ducky.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) nav.SetDestination(target.position);
    }
}
