using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationscript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);

        }
        else
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsIdle", true);
        }
    }
}
