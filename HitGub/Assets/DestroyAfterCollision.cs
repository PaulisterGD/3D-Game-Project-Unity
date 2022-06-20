using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour
{
    public bool destroymyCrumb;

    public GameObject crumb;

    private float initializationTime;

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

	// Start is called before the first frame update
	void Start()
	{
		initializationTime = Time.realtimeSinceStartup;
	}

	void Update()
    {
		float timeSinceInitialization = Time.realtimeSinceStartup - initializationTime;
        if (destroymyCrumb || timeSinceInitialization >= 3)
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

