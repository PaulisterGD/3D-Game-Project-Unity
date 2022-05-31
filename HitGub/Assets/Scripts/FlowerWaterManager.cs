using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerWaterManager : MonoBehaviour
{
    public int wateredFlowerCount;
    private int requiredCount = 5;

	public void Awake()
	{
		wateredFlowerCount = 0;
	}

	public void IncrementWaterCount()
	{
        wateredFlowerCount++;
	}

    public bool WaterCheck()
	{
        if (wateredFlowerCount >= requiredCount) return true;
        return false;
	}
}
