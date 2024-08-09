using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public AudioClip Vase1;
    public AudioClip Vase2;
    public GameObject Key;

    void Start()
    {
        Key.SetActive(false);
    }

    void Update()
    {

    }

    public void destroyVase()
    {
        Key.SetActive(true);
        FindObjectOfType<PlayerStats>().vaseDestroyed = true;

        if (FindObjectOfType<PlayerStats>().lives >= 0 && FindObjectOfType<PlayerStats>().health > 0)
        {
            AudioManager.instance.RandomizeSfx(Vase1, Vase2);
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            destroyVase();
        }
    }
}
