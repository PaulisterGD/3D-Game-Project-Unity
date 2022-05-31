using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlanter : Interactable
{
    public Collider flowerBed;
    public GameObject flowerObject;
    public ItemObject seedCount;
    private float xRand, zRand, lowBound, highBound;

    // Start is called before the first frame update
    void Start()
    {
        lowBound = -5.0f;
        highBound = 5.0f;
    }

    void PlantFlower()
	{
        xRand = Random.Range(lowBound, highBound);
        zRand = Random.Range(lowBound, highBound);
        Instantiate(flowerObject, new Vector3(transform.position.x + xRand, 0, transform.position.z + zRand), transform.rotation);
    }

	public override void Interact()
	{
        if (seedCount.MeetsRequirements())
        {
            PlantFlower();
            seedCount.OnHandleDropOffItem();
            if (!seedCount.MeetsRequirements())
			{
                flowerBed.enabled = false;
			}
        } 
    }

	public override string GetDescription()
	{
        return "Press E to plant a flower!";
	}
}
