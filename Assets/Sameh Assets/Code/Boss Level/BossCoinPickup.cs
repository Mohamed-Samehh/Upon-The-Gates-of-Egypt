using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCoinPickup : MonoBehaviour
{
    private bool StopCount = false;
    private float Count = 0f;
    public AudioClip Gem1;
    public AudioClip Gem2;
    public int coin_value = 5;
    void Start()
    {
        
    }

    void Update()
    {
        if (FindObjectOfType<BossPlayerStats>().defeatedBoss == true)
        {
            if (StopCount == false)
            {
                Count = Time.time + 3.5f;
                StopCount = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<BossPlayerStats>().coinsCollected += coin_value;
            Destroy(this.gameObject);

            if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
            {
                if (Time.time >= Count)
                {
                    AudioManager.instance.RandomizeSfx(Gem1, Gem2);
                }
            }
        }
    }
}
