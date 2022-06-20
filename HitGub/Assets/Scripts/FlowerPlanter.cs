using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlanter : Interactable
{
    public Collider flowerBed;
    public GameObject flowerObject;
    public ItemObject seedCount;
    public int flowerCount;
    //private float xRand, zRand, lowBound, highBound;
    public float[,] flowerCoords = new float[5,3]
    {
        { 144.54f, 41.36f, 402.32f },
        { 144.54f, 41.44f, 408.86f },
        { 151.9f, 41.36f, 409.3f },
        { 151.9f, 41.27f, 402.52f },
        { 148.51f, 41.35f, 405.88f }
    };

    // Start is called before the first frame update
    void Start()
    {
        //lowBound = -5f;
        //highBound = 5f;
        flowerCount = 0;
    }

    void PlantFlower(int i)
	{
        //xRand = Random.Range(lowBound, highBound);
        //zRand = Random.Range(lowBound, highBound);
        Instantiate(flowerObject, new Vector3( flowerCoords[i, 0] , flowerCoords[i, 1], flowerCoords[i, 2] ), transform.rotation);
    }

	public override void Interact()
	{
        if (seedCount.MeetsRequirements())
        {
            PlantFlower(flowerCount);
            flowerCount++;
            seedCount.OnHandleDropOffItem();
            if (!seedCount.MeetsRequirements())
			{
                flowerBed.enabled = false;
			}
        } 
    }

	public override string GetDescription()
	{
        if (seedCount.MeetsRequirements()) return "Interact to plant a flower!";
        return "";
	}
}
