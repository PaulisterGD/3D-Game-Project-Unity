using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringFlowers : Interactable
{
    public ItemObject waterCheck;
    public FlowerWaterManager waterManager;
    private bool isWatered;

    // Start is called before the first frame update
    void Start()
    {
        isWatered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string GetDescription()
    {
        if (isWatered) return "You already watered this flower!";
        else if (!waterCheck.MeetsRequirements()) return "";
        return "Press to water the flower!";
    }

    public override void Interact()
    {
        if (waterCheck != null)
		{
            Debug.Log("Item Object is here, proceeding...");
            if (!isWatered)
            {
                Debug.Log("Flower hasn't been watered already, proceeding...");
                if (waterCheck.MeetsRequirements())
                {
                    Debug.Log("Player has water, proceeding...");
                    waterManager.IncrementWaterCount();
                    isWatered = true;
                }
            }
		}
    }
}
