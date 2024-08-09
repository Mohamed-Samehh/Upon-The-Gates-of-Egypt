using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoLvl2Scene2 : MonoBehaviour
{
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
            if (FindObjectOfType<PlayerStats>().defeatedd == false)
            {
                if (FindObjectOfType<PlayerStats>().enemyCounter >= 6 && FindObjectOfType<PlayerStats>().coinsCollected == 70)
                {
                    AudioManager.instance.RandomizeSfx(tele1, tele2);
                    Application.LoadLevel(4);
                    MessageUI.text = "";
                    InfoUI.color = Color.white;
                }

                else if (FindObjectOfType<PlayerStats>().enemyCounter < 6 && FindObjectOfType<PlayerStats>().coinsCollected == 70)
                {
                    MessageUI.text = "Alert: You still need to kill more enemies";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else if (FindObjectOfType<PlayerStats>().enemyCounter >= 6 && FindObjectOfType<PlayerStats>().coinsCollected < 70)
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
