using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dogquest : MonoBehaviour
{
    public Animator anim;
    public GameObject target, billboard;
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
        if(target != null) { nav.SetDestination(target.transform.position); }

        if(nav.velocity.magnitude > 1) anim.SetBool("IsMoving", true);
        else anim.SetBool("IsMoving", false);
    }

    void OnTriggerEnter (Collider dogtrigger) {
        if (dogtrigger.tag == "Dog Owner"){
            target = null;
            dogReturned = true;
        } else if (dogtrigger.tag == "Player"){
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
