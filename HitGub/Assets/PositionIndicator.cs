using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionIndicator : MonoBehaviour
{
    public GameObject playerModel;
    private float MapX, MapY, xCoefficient, yCoefficient, xOffset, yOffset, screenX, screenY;
    //Resolution[] resolution = Screen.resolutions;

    // Start is called before the first frame update
    void Start()
    {
        xCoefficient = -3.103f;
        xOffset = 498.319f;
        yCoefficient = 2.642f; 
        yOffset = -229.019f;
        screenX = Screen.width / 2;
        screenY = Screen.height / 2;
        //playerModel = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MapX = (yCoefficient * playerModel.transform.position.z) + yOffset + screenY;
        MapY = (xCoefficient * playerModel.transform.position.x) + xOffset + screenX;

        transform.position = new Vector3(MapX, MapY, transform.position.z);
    }
}
