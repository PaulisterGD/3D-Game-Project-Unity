using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour
{
    public bool destroymyCrumb;

    public GameObject crumb;

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

    // void OnTriggerEnter(Collider collision)
    // {
    //     Debug.Log("does this work");
    //     if (collision.gameObject.tag == "BreadCrumb")
    //     {
    //         Debug.Log("Do something here");
    //     }
    // }

    void Update()
    {
        if (destroymyCrumb)
        {
            Destroy(crumb);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("duck"))
        {
            destroymyCrumb = true;
        }
    }
}

