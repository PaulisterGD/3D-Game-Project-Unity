using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlanter : MonoBehaviour
{
    public GameObject player, flowerObject;
    public ItemObject seedCount;
    public Interactable beeQuestManager;
    public float xRand, zRand, lowBound, highBound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
			if (seedCount.MeetsRequirements())
			{
                PlantFlower();
                seedCount.OnHandleDropOffItem();
            }
        }
    }

    void PlantFlower()
	{
        xRand = Random.Range(lowBound, highBound);
        zRand = Random.Range(lowBound, highBound);
        Instantiate(flowerObject, new Vector3(player.transform.position.x + xRand, player.transform.position.y, player.transform.position.z + zRand), transform.rotation);
    }
}
