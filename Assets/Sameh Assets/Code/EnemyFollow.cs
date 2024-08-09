using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float maxSpeed = 3f;
    public int damage = 1;
    public AudioClip hit1;
    public AudioClip hit2;

    public bool defeated = false;
    public bool idle;
    public bool activee;

    private float timeBetweenKills = 0.1f;
    private float nextKillTime = 0f;

    private float timeBetweenDamage = 2f;
    private float nextDamageTime = 0f;

    private Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    public BoxCollider2D boxCollider2;
    public BoxCollider2D boxCollider3;
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    public bool attack = false;

    float distance;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        activee = FindObjectOfType<Dialogue>().active;

        anim.SetBool("defeated", defeated);
        anim.SetBool("idle", idle);
        anim.SetBool("attack", attack);

        if (activee == false && attack == false)
        {
            if (defeated == false && idle == false)
            {
                if (FindObjectOfType<PlayerStats>().defeatedd == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
                }
            }
        }

        if (activee == false)
        {
            if (defeated == false && idle == false)
            {
                if (FindObjectOfType<PlayerStats>().defeatedd == false)
                {
                    if (transform.position.x < player.position.x)
                    {
                        spriteRenderer.flipX = true;
                    }
                    else
                    {
                        spriteRenderer.flipX = false;
                    }
                }
            }
        }

        if (defeated == true)
        {
            Destroy(gameObject, 0.45f);
            boxCollider.enabled = false;
            boxCollider2.enabled = false;
            boxCollider3.enabled = false;
            Destroy(rb);
        }

        if (distance <= 2.5 && !defeated)
        {
            if (FindObjectOfType<PlayerStats>().defeatedd == false)
            {
                attack = true;
                if (attack == true && Time.time >= nextDamageTime)
                {
                    FindObjectOfType<PlayerStats>().TakeDamage(damage);
                    nextDamageTime = Time.time + timeBetweenDamage;
                    if(FindObjectOfType<PlayerStats>().lives >= 0 && FindObjectOfType<PlayerStats>().health > 0)
                    {
                        AudioManager.instance.RandomizeSfx(hit1, hit2);
                    }
                }
            }
            else
            {
                attack = false;
            }
        }
        else
        {
            attack = false;
        }

        if (FindObjectOfType<PlayerStats>().defeatedd == true || activee == true)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (defeated == false)
        {
            if (other.tag == "Bullet" && Time.time >= nextKillTime)
            {
                defeated = true;
                FindObjectOfType<PlayerStats>().enemyCounter += 1;
                Destroy(other.gameObject);
                nextKillTime = Time.time + timeBetweenKills;
            }
        }
    }
}
