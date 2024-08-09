using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlag_1 : MonoBehaviour
{
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
                    FindObjectOfType<Flag1Sfx>().playSound();
                }
            }
            FindObjectOfType<BossLevel_Manager>().CurrentCheckpoint = this.gameObject;
        }
    }
}
