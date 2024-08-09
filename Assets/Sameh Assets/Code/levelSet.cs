using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSet : MonoBehaviour
{
    public static int level;

    void Start()
    {
        if(FindObjectOfType<GoLvl2Scene1>() != null)
        {
            level = 2;
        }
        else if (FindObjectOfType<GoLvl2Scene2>() != null)
        {
            level = 3;
        }
        else if (FindObjectOfType<GoLvl3Scene1>() != null)
        {
            level = 4;
        }
        else if (FindObjectOfType<GoLvl3Scene2>() != null)
        {
            level = 5;
        }
        else if (FindObjectOfType<Win>() != null)
        {
            level = 6;
        }
    }

    void Update()
    {
        
    }
}
