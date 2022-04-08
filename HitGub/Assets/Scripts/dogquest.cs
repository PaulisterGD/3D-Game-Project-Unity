using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dogquest : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.transform.position);

    }
    void OnTriggerEnter (UnityEngine.Collider dogtrigger) {
        if (dogtrigger.tag == "Interactable"){
            target = null;
        } else if (dogtrigger.tag == "Player"){
            target = GameObject.FindGameObjectWithTag ("Player");
        }
            
        
    }
/*void OnTriggerEnter (UnityEngine.Collider NPCtrigger){
    if (){            
            
    }
}*/
}
