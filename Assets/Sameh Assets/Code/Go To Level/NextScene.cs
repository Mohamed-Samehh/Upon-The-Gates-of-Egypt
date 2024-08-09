using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public AudioClip tele1;
    public AudioClip tele2;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (FindObjectOfType<PlayerStats>().defeatedd == false)
            {
                AudioManager.instance.RandomizeSfx(tele1, tele2);
                Application.LoadLevel(5);
            }
        }
    }
}
