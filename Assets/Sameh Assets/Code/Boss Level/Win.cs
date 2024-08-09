using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    private bool StopCount = false;
    private float Count = 0f;

    public AudioClip notele1;
    public AudioClip notele2;

    public BoxCollider2D boxCollider;

    public Text MessageUI;
    public Text InfoUI;

    void Start()
    {

    }

    void Update()
    {
        if (FindObjectOfType<BossPlayerStats>().defeatedBoss == true)
        {
            if (StopCount == false)
            {
                Count = Time.time + 3f;
                StopCount = true;
            }

            if (Time.time >= Count)
            {
                boxCollider.enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (FindObjectOfType<BossPlayerStats>().defeatedd == false)
            {
                if (FindObjectOfType<BossPlayerStats>().PurpleGem == true && FindObjectOfType<BossPlayerStats>().coinsCollected == 45)
                {
                    (new NavigationController()).GoToVictoryScene();
                    MessageUI.text = "";
                    InfoUI.color = Color.white;
                }

                else if (FindObjectOfType<BossPlayerStats>().PurpleGem == false && FindObjectOfType<BossPlayerStats>().coinsCollected == 45)
                {
                    MessageUI.text = "Alert: You still need to collect the Purple Gem";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else if (FindObjectOfType<BossPlayerStats>().PurpleGem == true && FindObjectOfType<BossPlayerStats>().coinsCollected < 45)
                {
                    MessageUI.text = "Alert: You still need to collect more gems";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else
                {
                    MessageUI.text = "Alert: You still need to collect more gems and collect the Purple Gem";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }
            }
        }
    }
}
