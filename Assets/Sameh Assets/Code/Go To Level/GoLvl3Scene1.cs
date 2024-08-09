using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoLvl3Scene1 : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Rigidbody2D Door;
    public float OpenSpeed = 2f;

    public Text MessageUI;
    public Text InfoUI;

    public AudioClip notele1;
    public AudioClip notele2;

    public AudioClip move1;
    public AudioClip move2;

    void Start()
    {
        boxCollider.enabled = false;
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
                if ((FindObjectOfType<PlayerStats>().enemyCounter >= 5 && FindObjectOfType<PlayerStats>().keyFound == true) && FindObjectOfType<PlayerStats>().coinsCollected == 45)
                {
                    boxCollider.enabled = true;
                    Door.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                    Door.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, OpenSpeed);
                    AudioManager.instance.RandomizeSfx(move1, move2);
                    MessageUI.text = "";
                    InfoUI.color = Color.white;

                }

                else if ((FindObjectOfType<PlayerStats>().enemyCounter < 5 && FindObjectOfType<PlayerStats>().keyFound == true) && FindObjectOfType<PlayerStats>().coinsCollected == 45)
                {
                    MessageUI.text = "Alert: You still need to kill more enemies";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else if ((FindObjectOfType<PlayerStats>().enemyCounter >= 5 && FindObjectOfType<PlayerStats>().keyFound == true) && FindObjectOfType<PlayerStats>().coinsCollected < 45)
                {
                    MessageUI.text = "Alert: You still need to collect more gems";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else if ((FindObjectOfType<PlayerStats>().enemyCounter >= 5 && FindObjectOfType<PlayerStats>().keyFound == false) && FindObjectOfType<PlayerStats>().coinsCollected == 45)
                {
                    MessageUI.text = "Alert: You still need to find the key";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else if ((FindObjectOfType<PlayerStats>().enemyCounter < 5 && FindObjectOfType<PlayerStats>().keyFound == true) && FindObjectOfType<PlayerStats>().coinsCollected < 45)
                {
                    MessageUI.text = "Alert: You still need to collect more gems and kill more enemies";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else if ((FindObjectOfType<PlayerStats>().enemyCounter >= 5 && FindObjectOfType<PlayerStats>().keyFound == false) && FindObjectOfType<PlayerStats>().coinsCollected < 45)
                {
                    MessageUI.text = "Alert: You still need to collect more gems and find the key";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else if ((FindObjectOfType<PlayerStats>().enemyCounter < 5 && FindObjectOfType<PlayerStats>().keyFound == false) && FindObjectOfType<PlayerStats>().coinsCollected == 45)
                {
                    MessageUI.text = "Alert: You still need to kill more enemies and find the key";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }

                else
                {
                    MessageUI.text = "Alert: You still need to kill more enemies, collect more gems, and find the key";
                    AudioManager.instance.RandomizeSfx(notele1, notele2);
                    InfoUI.color = Color.red;
                    MessageUI.color = Color.red;
                }
            }
        }
    }
}
