using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioClip Gem1;
    public AudioClip Gem2;
    public int coin_value = 5;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().coinsCollected += coin_value;
            Destroy(this.gameObject);

            if (FindObjectOfType<PlayerStats>().lives >= 0 && FindObjectOfType<PlayerStats>().health > 0)
            {
                AudioManager.instance.RandomizeSfx(Gem1, Gem2);
            }
        }
    }
}
