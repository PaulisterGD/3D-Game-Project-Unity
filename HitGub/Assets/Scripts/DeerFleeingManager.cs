using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerFleeingManager : MonoBehaviour
{
    public float speed = 1f;
    public Transform playerObject;
    public bool fleeCheck;
    public GameObject billboard;
    public GameObject[] sensors;
    private Vector3 fleeDirection;
    private Vector3 lastPlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        fleeCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (fleeCheck)
		{
            billboard.SetActive(false);
            transform.Translate( Vector3.down * Time.deltaTime * speed );
		}
        if (transform.position.z > 500 || transform.position.z < 0)
		{
            Destroy(gameObject);
		}
    }

     //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            //fleeDirection = playerObject.position - lastPlayerPosition;
            fleeCheck = true;
            foreach(GameObject sensor in sensors)
			{
                sensor.SetActive(false);
            }
        }
    }
}
