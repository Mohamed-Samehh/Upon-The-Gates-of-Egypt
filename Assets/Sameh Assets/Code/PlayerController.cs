using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public bool isFacingRight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
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
    public bool pressed = false;

    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    public void Shoot()
    {
        if (numBullets != 0)
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            AudioManager.instance.RandomizeSfx(shoot1, shoot2);
            numBullets--;
        }

        else
        {
            Debug.Log("No Ammo");
            AudioManager.instance.RandomizeSfx(NoAmmo1, NoAmmo2);
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

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
    }

    void Update()
    {
        if (FindObjectOfType<PlayerStats>() != null)
        {
            defeated = FindObjectOfType<PlayerStats>().defeatedd;
        }

        else if(FindObjectOfType<Lvl1Scene2PlayerStats>() != null)
        {
            defeated = FindObjectOfType<Lvl1Scene2PlayerStats>().defeatedd;
        }

        if (!defeated)
        {
            if (!PauseResume.paused && !Info.paused)
            {
                if (FindObjectOfType<Dialogue>().active == false)
                {
                    if (Input.GetKeyDown(Spacebar) && grounded)
                    {
                        Jump();
                    }
                }
            }

            if (!PauseResume.paused && !Info.paused)
            {
                if (FindObjectOfType<Dialogue>().active == false)
                {
                    if (Input.GetKey(L))
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                        if (isFacingRight)
                        {
                            flip();
                            isFacingRight = false;
                        }
                    }
                }
            }

            if (!PauseResume.paused && !Info.paused)
            {
                if (Input.GetKey(R))
                {
                    if (FindObjectOfType<Dialogue>().active == false)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                        if (!isFacingRight)
                        {
                            flip();
                            isFacingRight = true;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(Return))
            {
                if (!PauseResume.paused && !Info.paused)
                {
                    if (FindObjectOfType<Dialogue>().active == false)
                    {
                        Shoot();
                    }
                }
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("defeated", defeated);
        anim.SetBool("Pressed", pressed);
    }
}
