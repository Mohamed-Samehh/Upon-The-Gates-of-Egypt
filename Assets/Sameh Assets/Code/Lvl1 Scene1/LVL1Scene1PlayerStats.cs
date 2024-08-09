using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL1Scene1PlayerStats : MonoBehaviour
{
    public int health = 3;
    public int lives = 1;

    public float flickerDuration = 0.1f;
    private float flickerTime = 0f;
    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    public float immunityDuration = 1.5f;
    private float immunityTime = 0f;

    public Text gemsUI;
    public Image healthBar;
    public Text LivesUI;

    public int coin_value = 5;
    public int coinsCollected = 0;

    public bool MapFound = false;

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        immunityTime = 0f;
    }

    void Update()
    {
        if (coinsCollected == 35)
        {
            gemsUI.color = Color.white;
        }
        else
        {
            gemsUI.color = Color.red;
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

        gemsUI.text = "" + coinsCollected;
        LivesUI.text = "" + (lives + 1);
    }

    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0)
                this.health = 0;
            if (this.lives > 0 && this.health == 0)
            {
                FindObjectOfType<Level_Manager>().RespawnPlayer();
                this.health = 3;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                (new NavigationController()).GoToGameOverScene();
                AudioManager.instance.musicSource.Stop();
            }

            PlayHitReaction();
        }

        healthBar.fillAmount = this.health / 3f;
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    void SpriteFlicker()
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

    public void CollectedCoin(int coinValue)
    {
        this.coinsCollected = this.coinsCollected + coinValue;

    }
}
