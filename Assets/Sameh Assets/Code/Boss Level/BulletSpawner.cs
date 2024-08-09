using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform Bullet;

    void Start()
    {
        InvokeRepeating("BulletSpawn", 0f, 15f);
    }

    void Update()
    {
        if (FindObjectOfType<BossPlayerStats>().defeatedBoss == true)
        {
            CancelInvoke("BulletSpawn");
        }
    }

    public void BulletSpawn()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }
}