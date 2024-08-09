using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_1 : MonoBehaviour
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
            if (FindObjectOfType<Level_Manager>().CurrentCheckpoint != this.gameObject)
            {
                if (FindObjectOfType<PlayerStats>().lives >= 0 && FindObjectOfType<PlayerStats>().health > 0)
                {
                    FindObjectOfType<Flag1Sfx>().playSound();
                }
            }
            FindObjectOfType<Level_Manager>().CurrentCheckpoint = this.gameObject;
        }
    }
}
