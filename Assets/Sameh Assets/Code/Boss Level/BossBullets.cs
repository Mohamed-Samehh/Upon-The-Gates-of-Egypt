using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullets : MonoBehaviour
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
            FindObjectOfType<BossPlayerController>().numBullets += Bullet_value;
            Destroy(this.gameObject);

            if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
            {
                AudioManager.instance.RandomizeSfx(Bullet1, Bullet2);
            }
        }
    }
}
