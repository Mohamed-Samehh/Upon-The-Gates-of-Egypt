using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl1Scene2PlayerStats : MonoBehaviour
{
    public int health = 3;
    public int lives = 1;

    public bool defeatedd = false;
    public float deathTime = 2f;
    public bool once = false;
    public AudioClip laugh1;
    public AudioClip laugh2;
    public BoxCollider2D boxCollider;
    public BoxCollider2D boxCollider2;

    public float flickerDuration = 0.1f;
    private float flickerTime = 0f;
    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    public float immunityDuration = 1.5f;
    private float immunityTime = 0f;

    public Text gemsUI;
    public Image healthBar;
    public Text killedUI;
    public Text BulletsUI;
    public Text LivesUI;

    public int coin_value = 5;
    public int coinsCollected = 0;

    public int enemyCounter = 0;

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        immunityTime = 0f;
    }

    void Update()
    {
        if (coinsCollected == 25)
        {
            gemsUI.color = Color.white;
        }
        else
        {
            gemsUI.color = Color.red;
        }

        if (enemyCounter >= 6)
        {
            killedUI.color = Color.white;
        }
        else
        {
            killedUI.color = Color.red;
        }

        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime += Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }

        if (once == true)
        {
            if (Time.time >= deathTime)
            {
                defeat();
            }
        }

        if (this.lives == 0 && this.health == 0)
        {
            lives = -1;
            LivesUI.color = Color.red;
        }

        if (FindObjectOfType<PlayerController>().numBullets == 0)
        {
            BulletsUI.color = Color.red;
        }
        else
        {
            BulletsUI.color = Color.white;
        }

        gemsUI.text = "" + coinsCollected;
        killedUI.text = "" + enemyCounter;
        LivesUI.text = "" + (lives + 1);
        BulletsUI.text = "" + FindObjectOfType<PlayerController>().numBullets;
    }

    public void TakeDamage(int damage)
    {
        if (!defeatedd)
        {
            if (this.isImmune == false)
            {
                this.health = this.health - damage;
                if (this.health < 0)
                    this.health = 0;
                if (this.lives > 0 && this.health == 0)
                {
                    FindObjectOfType<Lvl1Scene2Level_Manager>().RespawnPlayer();
                    this.health = 3;
                    this.lives--;
                }
                else if (this.lives == 0 && this.health == 0)
                {
                    GetComponent<Renderer>().sortingLayerName = "Bullet";
                    deathTime += Time.time;
                    defeatedd = true;
                    once = true;
                    AudioManager.instance.RandomizeSfx(laugh1, laugh2);
                    boxCollider.enabled = false;
                    boxCollider2.enabled = true;
                }

                PlayHitReaction();
            }

            healthBar.fillAmount = this.health / 3f;
        }
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    void SpriteFlicker()
    {
        if (!defeatedd)
        {
            if (this.flickerTime < this.flickerDuration)
            {
                this.flickerTime = this.flickerTime + Time.deltaTime;
            }
            else if (this.flickerTime >= this.flickerDuration)
            {
                spriteRenderer.enabled = !(spriteRenderer.enabled);
                this.flickerTime = 0;
            }
        }
    }

    public void defeat()
    {
        (new NavigationController()).GoToGameOverScene();
        AudioManager.instance.musicSource.Stop();
    }

    public void CollectedCoin(int coinValue)
    {
        this.coinsCollected = this.coinsCollected + coinValue;

    }
}
