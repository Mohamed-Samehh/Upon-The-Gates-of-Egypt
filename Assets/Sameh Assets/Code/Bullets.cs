using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public AudioClip Bullet1;
    public AudioClip Bullet2;
    public int Bullet_value = 2;
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
            FindObjectOfType<PlayerController>().numBullets += Bullet_value;
            Destroy(this.gameObject);

            if (FindObjectOfType<PlayerStats>() != null)
            {
                if (FindObjectOfType<PlayerStats>().lives >= 0 && FindObjectOfType<PlayerStats>().health > 0)
                {
                    AudioManager.instance.RandomizeSfx(Bullet1, Bullet2);
                }
            }

            else if (FindObjectOfType<Lvl1Scene2PlayerStats>() != null)
            {
                if (FindObjectOfType<Lvl1Scene2PlayerStats>().lives >= 0 && FindObjectOfType<Lvl1Scene2PlayerStats>().health > 0)
                {
                    AudioManager.instance.RandomizeSfx(Bullet1, Bullet2);
                }
            }
        }
    }
}
