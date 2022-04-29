using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dogquest : MonoBehaviour
{
    public GameObject target;
    private bool dogReturned;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        dogReturned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null) { nav.SetDestination(target.transform.position); }
        

    }
    void OnTriggerEnter (UnityEngine.Collider dogtrigger) {
        if (dogtrigger.tag == "Dog Owner"){
            target = null;
            dogReturned = true;
        } else if (dogtrigger.tag == "Player"){
            if (!dogReturned) { target = GameObject.FindGameObjectWithTag("Player"); }
        }
            
        
    }
/*void OnTriggerEnter (UnityEngine.Collider NPCtrigger){
    if (){            
            
    }
}*/
}
