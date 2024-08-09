using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoLvl3Scene2 : MonoBehaviour
{
    public AudioClip tele1;
    public AudioClip tele2;

    public AudioClip BossMusic;

    public AudioClip notele1;
    public AudioClip notele2;

    public Text MessageUI;
    public Text InfoUI;

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
            if (FindObjectOfType<BossPlayerStats>().defeatedd == false)
            {
                if (FindObjectOfType<BossPlayerStats>().coinsCollected == 50)
                {
                    AudioManager.instance.RandomizeSfx(tele1, tele2);
                    AudioManager.instance.musicSource.clip = BossMusic;
                    AudioManager.instance.musicSource.Play();
                    Application.LoadLevel(6);
                    MessageUI.text = "";
                    InfoUI.color = Color.white;
                }

                else
                {
                    MessageUI.text = "Alert: You still need to collect more gems";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }
            }
        }
    }
}
