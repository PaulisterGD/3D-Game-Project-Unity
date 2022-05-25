using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNuts : MonoBehaviour
{
    public GameObject projectile;

    public float xLevel, zLevel;
    public float yLevel = 11f;

    public void spawnNuts()
	{
        xLevel = Random.Range(-23.25f, -16.12f);
        zLevel = Random.Range(-20.22f, -13.34f);
        Instantiate(projectile, new Vector3(xLevel, yLevel, zLevel), projectile.transform.rotation);
    }
}
