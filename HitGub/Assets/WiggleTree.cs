using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleTree : Interactable
{
    public Animator animator;

    public float time = .1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void ActivateTreeWiggle()
    {
        animator.SetBool("TreeWiggleToggle", true);
        Debug.Log("On");
        Invoke("DeActivateTreeWiggle", time);
        //animator.SetBool("TreeWiggleToggle", false);
    }

    void DeActivateTreeWiggle()
    {
        animator.SetBool("TreeWiggleToggle", false);
        Debug.Log("Off");
    } 

    public override string GetDescription()
    {
        return "Press E to interact";
    }

    public override void Interact()
    {
        ActivateTreeWiggle();
    }

    void update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}
