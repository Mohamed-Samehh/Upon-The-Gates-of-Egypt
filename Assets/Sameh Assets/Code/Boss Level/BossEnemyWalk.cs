using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyWalk : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 1;
    public AudioClip hit1;
    public AudioClip hit2;

    public bool defeated = false;
    public bool idle;

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
        if (FindObjectOfType<BossPlayerStats>().defeatedd == false)
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
        anim.SetBool("defeated", defeated);
        anim.SetBool("idle", idle);

        if (FindObjectOfType<BossPlayerStats>().defeatedBoss == true)
        {
            Defeated();
        }

            if (FindObjectOfType<BossPlayerStats>().defeatedd == true)
        {
            idle = true;
        }

        if (defeated == true)
        {
            if (this.tag == "Mummy")
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }

    public void Defeated()
    {
        defeated = true;
        boxCollider.enabled = false;
        boxCollider2.enabled = false;
        Destroy(rb);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!defeated)
        {
            if (other.tag == "Bullet" && Time.time >= nextKillTime)
            {
                Destroy(other.gameObject);
                FindObjectOfType<BossPlayerStats>().enemyCounter += 1;
                Defeated();
                nextKillTime = Time.time + timeBetweenKills;
            }

            if ((other.tag == "Mummy" || other.tag == "Boss") || other.tag == "Wall")
            {
                if (Time.time >= nextFlipTime)
                {
                    Flip();
                    nextFlipTime = Time.time + timeBetweenFlips;
                }
            }

            if (other.tag == "Player")
            {
                if (FindObjectOfType<BossPlayerStats>().defeatedd == false)
                {
                    FindObjectOfType<BossPlayerStats>().TakeDamage(damage);
                    Flip();

                    if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
                    {
                        AudioManager.instance.RandomizeSfx(hit1, hit2);
                    }
                }
            }
        }
    }
}
