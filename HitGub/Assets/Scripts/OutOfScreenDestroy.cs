using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenDestroy : MonoBehaviour
{
    public float time = 10f;
    public float yBound = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("NutDestroyed", time);
    }

	private void Update()
	{
		if (transform.position.y < yBound)
		{
            transform.position = new Vector3 (transform.position.x, yBound, transform.position.z);
		}
	}

	// Update is called once per frame
	void NutDestroyed()
    {
        Destroy(gameObject);
    }
}
