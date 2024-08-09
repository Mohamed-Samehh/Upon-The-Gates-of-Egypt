using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel_Manager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public Transform Enemy;

    void Start()
    {
        if (FindObjectOfType<Win>() != null)
        {
            InvokeRepeating("SpawnEnemy", 0f, 20f);
        }
    }

    void Update()
    {
        if (FindObjectOfType<Win>() != null)
        {
            if (FindObjectOfType<BossPlayerStats>().defeatedBoss == true)
            {
                CancelInvoke("SpawnEnemy");
            }
        }
    }

    public void RespawnPlayer()
    {
        FindObjectOfType<BossPlayerController>().transform.position = CurrentCheckpoint.transform.position;
    }

    public void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}