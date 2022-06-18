using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        joystick = GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
