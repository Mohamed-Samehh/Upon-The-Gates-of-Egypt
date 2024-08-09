using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public AudioClip Map1;
    public AudioClip Map2;

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
            FindObjectOfType<LVL1Scene1PlayerStats>().MapFound = true;
            AudioManager.instance.RandomizeSfx(Map1, Map2);
        }
    }
}
