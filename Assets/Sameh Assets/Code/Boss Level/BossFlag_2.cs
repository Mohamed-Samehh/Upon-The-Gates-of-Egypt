using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlag_2 : MonoBehaviour
{
    public AudioClip Check1;
    public AudioClip Check2;

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
            if (FindObjectOfType<BossLevel_Manager>().CurrentCheckpoint != this.gameObject)
            {
                if (FindObjectOfType<BossPlayerStats>().lives >= 0 && FindObjectOfType<BossPlayerStats>().health > 0)
                {
                    AudioManager.instance.RandomizeSfx(Check1, Check2);
                }
            }
            FindObjectOfType<BossLevel_Manager>().CurrentCheckpoint = this.gameObject;
        }
    }
}
