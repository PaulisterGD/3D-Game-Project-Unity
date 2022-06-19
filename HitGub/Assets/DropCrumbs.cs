using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DropCrumbs : MonoBehaviour
{
    public ItemObject breadCrumbRequirement;
    public GameObject breadcrumb, playerModel;

    public bool breadCrumbFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        if (breadCrumbRequirement.MeetsRequirements())
        {
            breadCrumbFlag = true;
        }
        else 
        {
            breadCrumbFlag = false;
        }
        if(gamepad.buttonSouth.wasPressedThisFrame)
        {
            if(breadCrumbFlag)
            {
                Instantiate(breadcrumb, new Vector3(playerModel.transform.position.x - 1, playerModel.transform.position.y, playerModel.transform.position.z ),playerModel.transform.rotation); 
            }
        }

    }
}
