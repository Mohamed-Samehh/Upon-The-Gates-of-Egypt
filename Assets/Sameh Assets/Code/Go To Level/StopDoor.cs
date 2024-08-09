using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDoor : MonoBehaviour
{
    public GameObject Next;

    void Start()
    {
        Next.SetActive(false);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Next.SetActive(true);
        }
    }
}
