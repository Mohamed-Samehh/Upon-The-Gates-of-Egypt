using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBoss : MonoBehaviour
{
    public Rigidbody2D Dead;
    public AudioClip PurpleGem1;
    public AudioClip PurpleGem2;
    private float Count;

    void Start()
    {
        Dead.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        Count = Time.time + 1f;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Dead.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (other.tag == "Player")
        {
            FindObjectOfType<BossPlayerStats>().PurpleGem = true;
            Destroy(this.gameObject);

            if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
            {
                if (Time.time >= Count)
                {
                    AudioManager.instance.RandomizeSfx(PurpleGem1, PurpleGem2);
                }
            }
        }
    }
}
