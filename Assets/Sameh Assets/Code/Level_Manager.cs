using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public Transform Enemy;

    void Start()
    {

    }

    void Update()
    {

    }

    public void RespawnPlayer()
    {
        FindObjectOfType<PlayerController>().transform.position = CurrentCheckpoint.transform.position;
    }

    public void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}