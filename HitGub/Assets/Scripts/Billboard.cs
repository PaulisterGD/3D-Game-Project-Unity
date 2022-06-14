using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera theCam;
    public GameObject attachedObject;
    public bool useStaticBillboard;
    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;   //asigning the camera
    }

    // positioning the 2d sprite to be facing the camera from every angle
    void LateUpdate()
    {
        if(!useStaticBillboard)
        {
            transform.LookAt(theCam.transform);
        } 
        else
        {
            transform.rotation = theCam.transform.rotation;
        }

		//if (attachedObject == null)
		//{
            //Destroy(gameObject);
		//}

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
