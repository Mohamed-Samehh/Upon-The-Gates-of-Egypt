using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1Scene1PlayerCont : MonoBehaviour
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
    public bool pressed = false;


    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
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
            if (!PauseResume.paused && !Info.paused)
        {
            if (FindObjectOfType<Dialogue>().active == false && FindObjectOfType<MapDialogue>().active == false)
            {
                if (Input.GetKeyDown(Spacebar) && grounded)
                {
                    Jump();
                }
            }
        }

        if (!PauseResume.paused && !Info.paused)
        {
            if (FindObjectOfType<Dialogue>().active == false && FindObjectOfType<MapDialogue>().active == false)
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
            if (FindObjectOfType<Dialogue>().active == false && FindObjectOfType<MapDialogue>().active == false)
            {
                if (Input.GetKey(R))
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

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Pressed", pressed);
    }
}
