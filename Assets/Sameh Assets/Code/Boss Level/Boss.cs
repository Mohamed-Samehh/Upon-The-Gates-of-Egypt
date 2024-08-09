using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator anim;
    public bool defeated = false;
    public int HitsLeft = 7;

    public int damage = 1;
    public float maxSpeed = 3f;

    private Transform player;

    public Transform Firepoint;
    public GameObject FireBall;

    public BoxCollider2D boxCollider;
    public BoxCollider2D boxCollider2;
    private Rigidbody2D rb;

    public float timeBetweenShots = 5f;
    private float nextShotTime;
    public float FirstShootDelay = 0.5f;

    private float timeBetweenKills = 0.1f;
    private float nextKillTime;

    private float timeBetweenDamage = 2f;
    private float nextDamageTime = 0f;

    public AudioClip BossShoot1;
    public AudioClip BossShoot2;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip Defeat1;
    public AudioClip Defeat2;

    public bool attack = false;

    float distance;

    void Start()
    {
        anim = GetComponent<Animator>();
        nextShotTime = 0f;
        rb = GetComponent<Rigidbody2D>();
        nextShotTime = Time.time + FirstShootDelay;
        nextKillTime = 0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);

        anim.SetBool("defeated", defeated);

        if (HitsLeft == 0)
        {
            FindObjectOfType<BossPlayerStats>().defeatedBoss = true;
            defeated = true;
            boxCollider.enabled = false;
            boxCollider2.enabled = false;
            Destroy(rb);
            if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
            {
                AudioManager.instance.RandomizeSfx(Defeat1, Defeat2);
            }
            Destroy(gameObject, 1.8f);
        }

        if (Time.time >= nextShotTime && ! defeated)
        {
            Shoot();
            nextShotTime = Time.time + timeBetweenShots;
        }

        FindObjectOfType<BossPlayerStats>().BossHealth = HitsLeft;

        if (distance <= 2.5 && !defeated)
        {
            if (FindObjectOfType<BossPlayerStats>().defeatedd == false)
            {
                attack = true;
                if (attack == true && Time.time >= nextDamageTime)
                {
                    FindObjectOfType<BossPlayerStats>().TakeDamage(damage);
                    nextDamageTime = Time.time + timeBetweenDamage;
                    if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
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
    }

    public void Shoot()
    {
        Instantiate(FireBall, Firepoint.position, Firepoint.rotation);
        if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
        {
            AudioManager.instance.RandomizeSfx(BossShoot1, BossShoot2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (defeated == false)
        {
            if (other.tag == "Bullet" && Time.time >= nextKillTime)
            {
                Destroy(other.gameObject);
                HitsLeft -= 1;
                nextKillTime = Time.time + timeBetweenKills;
            }
        }
    }
}