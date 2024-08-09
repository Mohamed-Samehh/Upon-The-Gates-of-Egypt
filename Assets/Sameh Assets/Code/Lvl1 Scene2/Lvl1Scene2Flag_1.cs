using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Scene2Flag_1 : MonoBehaviour
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
            if (FindObjectOfType<Lvl1Scene2Level_Manager>().CurrentCheckpoint != this.gameObject)
            {
                if (FindObjectOfType<Lvl1Scene2PlayerStats>().lives >= 0 && FindObjectOfType<Lvl1Scene2PlayerStats>().health > 0)
                {
                    FindObjectOfType<Flag1Sfx>().playSound();
                }
            }
            FindObjectOfType<Lvl1Scene2Level_Manager>().CurrentCheckpoint = this.gameObject;
        }
    }
}
