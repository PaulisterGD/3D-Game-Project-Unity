using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        gameObject.transform.position = new Vector3(h, 0, v) * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("idle", true);
        }
    }

}
