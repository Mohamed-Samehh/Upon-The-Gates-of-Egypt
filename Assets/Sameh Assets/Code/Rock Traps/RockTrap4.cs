using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrap4 : MonoBehaviour
{
    public Transform Enemy;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ThrowRocks()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}