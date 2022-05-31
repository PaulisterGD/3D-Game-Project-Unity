using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour
{
    // public GameObject projectile;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void OnCollisionEnter(Collision collision)
    // {
    //     Destroy(collision.collider.gameObject);
    //     Destroy(gameObject);
    // }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("does this wokr");
        if (collision.gameObject.tag == "BreadCrumb")
        {
            Debug.Log("Do something here");
        }
    }

}

