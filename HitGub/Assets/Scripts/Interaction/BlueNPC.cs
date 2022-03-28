using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueNPC : Interactable
{
    public Light m_light;
    public bool isOn;
    public GameObject[] playerModels;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateDialogue();
    }

    // Update is called once per frame
    void UpdateDialogue()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        /*
        m_light.enabled = isOn;
        foreach (GameObject modelObject in playerModels)
        {
            modelObject.GetComponent<Renderer>().enabled = !isOn;
        }
        */
    }

    public override string GetDescription()
    {
        //if (isOn) return "Press [E] to turn OFF the light\nand make me appear!";
        //return "Press [E] to turn ON the light\nand make me disappear!";
        return "";
    }

    public override void Interact()
    {
        isOn = !isOn;
        UpdateDialogue();
    }
}
