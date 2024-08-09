using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    public AudioClip hit1;
    public AudioClip hit2;

    void Start()
    {
        speed = -speed;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (FindObjectOfType<BossPlayerStats>().defeatedBoss == false)
            {
                if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
                {
                    AudioManager.instance.RandomizeSfx(hit1, hit2);
                }
                FindObjectOfType<BossPlayerStats>().TakeDamage(damage);
            }
        }

        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
