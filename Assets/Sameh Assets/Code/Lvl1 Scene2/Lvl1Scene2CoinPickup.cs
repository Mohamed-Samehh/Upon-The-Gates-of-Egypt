using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Scene2CoinPickup : MonoBehaviour
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
            FindObjectOfType<Lvl1Scene2PlayerStats>().coinsCollected += coin_value;
            Destroy(this.gameObject);

            if (FindObjectOfType<Lvl1Scene2PlayerStats>().lives >= 0 && FindObjectOfType<Lvl1Scene2PlayerStats>().health > 0)
            {
                AudioManager.instance.RandomizeSfx(Gem1, Gem2);
            }
        }
    }
}
