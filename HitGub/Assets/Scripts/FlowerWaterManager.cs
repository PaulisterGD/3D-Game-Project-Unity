using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerWaterManager : MonoBehaviour
{
    public int wateredFlowerCount;
    private int requiredCount = 5;


	private void Awake()
	{
		wateredFlowerCount = 0;
	}

	public void IncrementWaterCount()
	{
        wateredFlowerCount++;
		Debug.Log("Watered count is now... " + wateredFlowerCount);
	}

	public void WaterCountReset()
	{
		wateredFlowerCount = 0;
	}

    public bool WaterCheck()
	{
		if (wateredFlowerCount >= requiredCount) { return true; }
        return false;
	}
}
