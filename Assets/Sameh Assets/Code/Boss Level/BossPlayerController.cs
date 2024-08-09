using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayerController : MonoBehaviour
{
    private Rigidbody2D Player;
    public float moveSpeed;
    public float jumpHeight;
    public float WallSlidingSpeed;
    public float wallJump_X;
    public float wallJump_Y;
    public float h;
    public bool isFacingRight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public Transform wallCheck;
    public float groundCheckRadius;
    public float WallCheckRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;
    private bool isTouchingWall;
    private bool grounded;
    private Animator anim;
    public KeyCode Return;
    public Transform firepoint;
    public GameObject bullet;
    public AudioClip shoot1;
    public AudioClip shoot2;
    public int numBullets = 3;
    public AudioClip NoAmmo1;
    public AudioClip NoAmmo2;
    public bool defeated = false;
    private bool StopCount = false;
    private float Count = 0f;
    public bool pressed = false;

    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        if (grounded)
        {
            Player.velocity = new Vector2(Player.velocity.x, jumpHeight);
        }
        else if (isTouchingWall && isFacingRight)
        {
            Player.velocity = new Vector2(-wallJump_X, wallJump_Y);
            flip();
            isFacingRight = false;
        }
        else if (isTouchingWall && !isFacingRight)
        {
            Player.velocity = new Vector2(wallJump_X, wallJump_Y);
            flip();
            isFacingRight = true;
        }
    }

    public void Shoot()
    {
        if (numBullets != 0)
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            numBullets--;
            if(Time.time >= Count)
            {
                AudioManager.instance.RandomizeSfx(shoot1, shoot2);
            }
        }

        else
        {
            Debug.Log("No Ammo");
            if (Time.time >= Count)
            {
                AudioManager.instance.RandomizeSfx(NoAmmo1, NoAmmo2);
            }
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, WallCheckRadius, whatIsWall);

        if (Input.GetKey(L) || Input.GetKey(R))
        {
            pressed = true;
        }
        else
        {
            pressed = false;
        }
    }

    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        Player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (FindObjectOfType<BossPlayerStats>().defeatedBoss == true)
        {
            if (StopCount == false)
            {
                Count = Time.time + 3.5f;
                StopCount = true;
            }
        }

        defeated = FindObjectOfType<BossPlayerStats>().defeatedd;

        h = Input.GetAxisRaw("Horizontal");

        if (!defeated)
        {
            if (!PauseResume.paused && !Info.paused)
            {
                if (isTouchingWall && !grounded && h != 0)
                {
                    Player.velocity = new Vector2(Player.velocity.x, Mathf.Clamp(Player.velocity.y, -WallSlidingSpeed, float.MaxValue));
                }
            }

            if (!PauseResume.paused && !Info.paused)
            {
                if (Input.GetKeyDown(Spacebar))
                {
                    Jump();
                }
            }

            if (!PauseResume.paused && !Info.paused)
            {
                if (Input.GetKey(L))
                {
                    Player.velocity = new Vector2(-moveSpeed, Player.velocity.y);
                    if (isFacingRight)
                    {
                        flip();
                        isFacingRight = false;
                    }
                }
            }

            if (!PauseResume.paused && !Info.paused)
            {
                if (Input.GetKey(R))
                {
                    Player.velocity = new Vector2(moveSpeed, Player.velocity.y);
                    if (!isFacingRight)
                    {
                        flip();
                        isFacingRight = true;
                    }
                }
            }

            if (!PauseResume.paused && !Info.paused)
            {
                if (Input.GetKeyDown(Return))
                {
                    Shoot();
                }
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(Player.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("defeated", defeated);
        anim.SetBool("Pressed", pressed);
    }
}
