using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadPondQuestManager : Interactable
{
    private ItemObject itemObject;
    // Start is called before the first frame update
    void Start()
    {
        itemObject = GetComponent<ItemObject>();
    }

    // Update is called once per frame
    void UpdateToad()
    {
        itemObject.OnHandleDropOffItem();
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }

    public override string GetDescription()
	{
        return "Press E to return the toad!";
	}

    public override void Interact()
	{
        UpdateToad();
	}
}
