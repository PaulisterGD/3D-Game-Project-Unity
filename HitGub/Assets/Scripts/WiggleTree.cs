using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleTree : Interactable
{
    public Animator animator;
    public GameObject spawnNuts;
    public int nutCount;
    public int questCompletionTally = 50;
    public bool questComplete;

    public float time = .1f;

    // Start is called before the first frame update
    void Start()
    {
        questComplete = false;
        nutCount = 0;
    }

    // Update is called once per frame
    void ActivateTreeWiggle()
    {
        if (!questComplete)
        {
            animator.SetBool("TreeWiggleToggle", true);
            Debug.Log("On");
            spawnNuts.GetComponent<SpawnNuts>().spawnNuts();
            nutCount++;
            Invoke("DeActivateTreeWiggle", time);
            //animator.SetBool("TreeWiggleToggle", false);
            if (nutCount >= questCompletionTally) questComplete = true;
        } 
    }

    void DeActivateTreeWiggle()
    {
        animator.SetBool("TreeWiggleToggle", false);
        Debug.Log("Off");
    } 

    public override string GetDescription()
    {
        if (!questComplete) return "Press E to interact";
        return "You got the acorns! Return to the squirrel!";
    }

    public override void Interact()
    {
        ActivateTreeWiggle();
    }
}
