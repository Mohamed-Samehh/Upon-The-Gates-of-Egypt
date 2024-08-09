using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1Scene1CoinPickup : MonoBehaviour
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
            FindObjectOfType<LVL1Scene1PlayerStats>().coinsCollected += coin_value;
            Destroy(this.gameObject);
            AudioManager.instance.RandomizeSfx(Gem1, Gem2);
        }
    }
}
