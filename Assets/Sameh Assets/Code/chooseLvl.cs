using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseLvl : MonoBehaviour
{
    public AudioClip DesertMusic;
    public AudioClip TempleMusic;
    public AudioClip BossMusic;
    public GameObject LvlScreen;
    public static bool opened;

    void Start()
    {
        opened = false;
        LvlScreen.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Open()
    {
        LvlScreen.SetActive(true);
        opened = true;
    }

    public void Close()
    {
        LvlScreen.SetActive(false);
        opened = false;
    }

    public void one()
    {
        Application.LoadLevel(1);
        AudioManagerIntro.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = DesertMusic;
        AudioManager.instance.musicSource.Play();
    }

    public void two()
    {
        Application.LoadLevel(2);
        AudioManagerIntro.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = DesertMusic;
        AudioManager.instance.musicSource.Play();
    }

    public void three()
    {
        Application.LoadLevel(3);
        AudioManagerIntro.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = TempleMusic;
        AudioManager.instance.musicSource.Play();
    }

    public void four()
    {
        Application.LoadLevel(4);
        AudioManagerIntro.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = TempleMusic;
        AudioManager.instance.musicSource.Play();
    }

    public void five()
    {
        Application.LoadLevel(5);
        AudioManagerIntro.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = TempleMusic;
        AudioManager.instance.musicSource.Play();
    }

    public void six()
    {
        Application.LoadLevel(6);
        AudioManagerIntro.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = BossMusic;
        AudioManager.instance.musicSource.Play();
    }
}
