using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioClip Key1;
    public AudioClip Key2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<PlayerStats>().keyFound = true;

            if (FindObjectOfType<PlayerStats>().lives >= 0 && FindObjectOfType<PlayerStats>().health > 0)
            {
                AudioManager.instance.RandomizeSfx(Key1, Key2);
            }
        }
    }
}
