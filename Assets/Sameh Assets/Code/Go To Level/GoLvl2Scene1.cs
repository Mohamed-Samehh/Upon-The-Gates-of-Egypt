using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoLvl2Scene1 : MonoBehaviour
{
    public AudioClip TempleMusic;

    public AudioClip tele1;
    public AudioClip tele2;

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
            if (FindObjectOfType<Lvl1Scene2PlayerStats>().defeatedd == false)
            {
                if (FindObjectOfType<Lvl1Scene2PlayerStats>().enemyCounter >= 6 && FindObjectOfType<Lvl1Scene2PlayerStats>().coinsCollected == 25)
                {
                    AudioManager.instance.RandomizeSfx(tele1, tele2);
                    AudioManager.instance.musicSource.clip = TempleMusic;
                    AudioManager.instance.musicSource.Play();
                    Application.LoadLevel(3);
                    MessageUI.text = "";
                    InfoUI.color = Color.white;
                }

                else if (FindObjectOfType<Lvl1Scene2PlayerStats>().enemyCounter < 6 && FindObjectOfType<Lvl1Scene2PlayerStats>().coinsCollected == 25)
                {
                    MessageUI.text = "Alert: You still need to kill more enemies";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else if (FindObjectOfType<Lvl1Scene2PlayerStats>().enemyCounter >= 6 && FindObjectOfType<Lvl1Scene2PlayerStats>().coinsCollected < 25)
                {
                    MessageUI.text = "Alert: You still need to collect more gems";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else
                {
                    MessageUI.text = "Alert: You still need to collect more gems and kill more enemies";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }
            }
        }
    }
}
