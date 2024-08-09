using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private float timeBetweenSpawns = 5f;
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = 0f;
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && Time.time >= nextSpawnTime)
        {
            FindObjectOfType<Level_Manager>().SpawnEnemy();
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
