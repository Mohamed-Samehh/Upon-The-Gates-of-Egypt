using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Scene2BulletController : MonoBehaviour
{
    private Transform p;
    public float speed;
    public float bulletDistance = 7f;

    void Start()
    {
        PlayerController player;

        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        p = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        if (Vector2.Distance(transform.position, p.transform.position) >= bulletDistance)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}