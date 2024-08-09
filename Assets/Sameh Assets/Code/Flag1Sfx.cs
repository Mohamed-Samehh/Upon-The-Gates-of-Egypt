using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag1Sfx : MonoBehaviour
{
    public AudioClip Check1;
    public AudioClip Check2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void playSound()
    {
        AudioManager.instance.RandomizeSfx(Check1, Check2);
    }
}
