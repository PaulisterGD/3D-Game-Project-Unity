using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNuts : MonoBehaviour
{
    public GameObject projectile;

    public float xConst, zConst;
    public float xLevel, zLevel;
    public float yLevel = 11f;

    public void spawnNuts()
	{
        xLevel = Random.Range(-4.00f, 4.00f);
        zLevel = Random.Range(-4.00f, 4.00f);
        Instantiate(projectile, new Vector3(xConst + xLevel, yLevel, zConst + zLevel), projectile.transform.rotation);
    }
}
