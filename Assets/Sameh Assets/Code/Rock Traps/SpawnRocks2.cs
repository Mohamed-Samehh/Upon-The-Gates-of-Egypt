using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks2 : MonoBehaviour
{
    public AudioClip hit1;
    public AudioClip hit2;

    private float timeBetweenSpawns = 1f;
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
        if (other.gameObject.tag == "Player" && Time.time >= nextSpawnTime)
        {


            if (FindObjectOfType<BossPlayerStats>() != null)
            {
                if (FindObjectOfType<BossPlayerStats>().defeatedBoss == false)
                {
                    if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
                    {
                        AudioManager.instance.RandomizeSfx(hit1, hit2);
                        FindObjectOfType<RockTrap2>().ThrowRocks();
                        nextSpawnTime = Time.time + timeBetweenSpawns;
                    }
                }
            }


            if (FindObjectOfType<PlayerStats>() != null)
            {
                if (FindObjectOfType<PlayerStats>().lives >= 0 && FindObjectOfType<PlayerStats>().health > 0)
                {
                    AudioManager.instance.RandomizeSfx(hit1, hit2);
                    FindObjectOfType<RockTrap2>().ThrowRocks();
                    nextSpawnTime = Time.time + timeBetweenSpawns;
                }
            }
        }
    }
}
