using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage = 1;
    public AudioClip hit1;
    public AudioClip hit2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (FindObjectOfType<PlayerStats>().defeatedd == false)
            {
                FindObjectOfType<PlayerStats>().TakeDamage(damage);

                if (FindObjectOfType<PlayerStats>().lives >= 0 && FindObjectOfType<PlayerStats>().health > 0)
                {
                    AudioManager.instance.RandomizeSfx(hit1, hit2);
                }
            }
        }
    }
}
