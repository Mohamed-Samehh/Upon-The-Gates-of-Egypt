using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoLvl1Scene2 : MonoBehaviour
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
            if (FindObjectOfType<LVL1Scene1PlayerStats>().MapFound == true && FindObjectOfType<LVL1Scene1PlayerStats>().coinsCollected == 35)
            {
                AudioManager.instance.RandomizeSfx(tele1, tele2);
                Application.LoadLevel(2);
                MessageUI.text = "";
                InfoUI.color = Color.white;
            }

            else if(FindObjectOfType<LVL1Scene1PlayerStats>().MapFound == false && FindObjectOfType<LVL1Scene1PlayerStats>().coinsCollected == 35)
            {
                MessageUI.text = "Alert: You still need to get the map";
                AudioManager.instance.RandomizeSfx(notele1, notele2);
                InfoUI.color = Color.red;
                MessageUI.color = Color.red;
            }

            else if (FindObjectOfType<LVL1Scene1PlayerStats>().MapFound == true && FindObjectOfType<LVL1Scene1PlayerStats>().coinsCollected < 35)
            {
                MessageUI.text = "Alert: You still need to collect more gems";
                AudioManager.instance.RandomizeSfx(notele1, notele2);
                InfoUI.color = Color.red;
                MessageUI.color = Color.red;
            }

            else
            {
                MessageUI.text = "Alert: You still need to get the map and collect more gems";
                AudioManager.instance.RandomizeSfx(notele1, notele2);
                InfoUI.color = Color.red;
                MessageUI.color = Color.red;
            }
        }
    }
}
