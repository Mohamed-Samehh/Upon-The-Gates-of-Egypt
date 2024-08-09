using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Scene2EnemyWalk : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 1;
    public AudioClip hit1;
    public AudioClip hit2;

    public bool defeated = false;
    public bool idle;
    public bool activee;

    private float timeBetweenKills = 0.1f;
    private float nextKillTime;

    private float timeBetweenFlips = 0.1f;
    private float nextFlipTime;

    private Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    public BoxCollider2D boxCollider2;
    private Animator anim;

    public void Flip()
    {
        if (FindObjectOfType<Lvl1Scene2PlayerStats>().defeatedd == false)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        if (!defeated && !idle)
        {
            if (this.isFacingRight == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        nextKillTime = 0f;
        nextFlipTime = 0f;
    }

    void Update()
    {
        activee = FindObjectOfType<Dialogue>().active;

        anim.SetBool("defeated", defeated);
        anim.SetBool("idle", idle);

        if (FindObjectOfType<Lvl1Scene2PlayerStats>().defeatedd == true || activee == true)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }

        if (defeated == true)
        {
            if (this.tag == "Nomad")
            {
                Destroy(gameObject, 0.4f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!defeated)
        {
            if (other.tag == "Bullet" && Time.time >= nextKillTime)
            {
                defeated = true;
                FindObjectOfType<Lvl1Scene2PlayerStats>().enemyCounter += 1;
                boxCollider.enabled = false;
                boxCollider2.enabled = false;
                Destroy(rb);
                Destroy(other.gameObject);
                nextKillTime = Time.time + timeBetweenKills;
            }

            if (other.tag == "Wall" || other.tag == "Nomad")
            {
                if (Time.time >= nextFlipTime)
                {
                    Flip();
                    nextFlipTime = Time.time + timeBetweenFlips;
                }
            }

            if (other.tag == "Player")
            {
                if (FindObjectOfType<Lvl1Scene2PlayerStats>().defeatedd == false)
                {
                    FindObjectOfType<Lvl1Scene2PlayerStats>().TakeDamage(damage);
                    Flip();

                    if (FindObjectOfType<Lvl1Scene2PlayerStats>().lives >= 0 && FindObjectOfType<Lvl1Scene2PlayerStats>().health > 0)
                    {
                        AudioManager.instance.RandomizeSfx(hit1, hit2);
                    }
                }
            }
        }
    }
}



