using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer: MonoBehaviour
{
    public Animator anim;
    public Transform target;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);

        if (nav.velocity.magnitude > 1)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsIdle", false);
        }
        else
        {
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsIdle", true);
        }
    }
}
