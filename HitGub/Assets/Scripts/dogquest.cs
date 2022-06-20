using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dogquest : MonoBehaviour
{
    public Animator anim;
    public GameObject target, billboard, dogOwner;
    public bool dogReturned;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        dogReturned = false;
        billboard.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float goalDistance = Vector3.Distance(transform.position, dogOwner.transform.position);
        if (goalDistance < 10)
        {
            target = dogOwner;
            dogReturned = true;
        }

        if (target != null) { nav.SetDestination(target.transform.position); }

        if(nav.velocity.magnitude > 0.1) anim.SetBool("IsMoving", true);
        else anim.SetBool("IsMoving", false);
    }

    void OnTriggerEnter (Collider dogtrigger) {
        if (dogtrigger.tag == "Player"){
            if (!dogReturned) { 
                target = GameObject.FindGameObjectWithTag("Player");
                billboard.SetActive(false);
            }
        }
    }
/*void OnTriggerEnter (UnityEngine.Collider NPCtrigger){
    if (){            
            
    }
}*/
}
