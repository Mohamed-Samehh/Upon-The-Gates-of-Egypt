using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 1;
    public bool defeated = false;
    public bool grounded = false;

    public AudioClip hit1;
    public AudioClip hit2;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float amplitude;

    private float timeBetweenKills = 0.1f;
    private float nextKillTime;

    private float timeBetweenFlips = 0.1f;
    private float nextFlipTime;

    private Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    public BoxCollider2D boxCollider2;
    private Animator anim;

    private Vector3 temp_pos;
    PlayerController player;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        temp_pos = transform.position;
        nextKillTime = 0f;
        nextFlipTime = 0f;
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        anim.SetBool("defeated", defeated);
        anim.SetBool("grounded", grounded);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    private void FixedUpdate()
    {
        if (!defeated)
        {
            if (isFacingRight)
            {
                temp_pos.x += HorizontalSpeed * Time.deltaTime;
                temp_pos.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
                transform.position = temp_pos;
            }
            else
            {
                temp_pos.x -= HorizontalSpeed * Time.deltaTime;
                temp_pos.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
                transform.position = temp_pos;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!defeated)
        {
            if (other.tag == "Bird" || other.tag == "Wall")
            {
                if (Time.time >= nextFlipTime)
                {
                    Flip();
                    nextFlipTime = Time.time + timeBetweenFlips;
                }
            }

            if (other.tag == "Player")
            {

                FindObjectOfType<Lvl1Scene2PlayerStats>().TakeDamage(damage);
                Flip();

                if (FindObjectOfType<Lvl1Scene2PlayerStats>().lives >= 0 && FindObjectOfType<Lvl1Scene2PlayerStats>().health > 0)
                {
                    AudioManager.instance.RandomizeSfx(hit1, hit2);
                }
            }

            if (other.tag == "Bullet" && Time.time >= nextKillTime)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                GetComponent<Renderer>().sortingLayerName = "FG";
                defeated = true;
                FindObjectOfType<Lvl1Scene2PlayerStats>().enemyCounter += 1;
                boxCollider.enabled = false;
                rb.gravityScale = 1f;
                Destroy(other.gameObject);
                nextKillTime = Time.time + timeBetweenKills;

                if (player.transform.localScale.x < 0 && !isFacingRight || player.transform.localScale.x > 0 && isFacingRight)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
        }

        if (other.tag == "Ground")
        {
            grounded = true;
            Destroy(rb);
            boxCollider2.enabled = false;
        }
    }
}
