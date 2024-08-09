using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResume : MonoBehaviour
{
    public GameObject PauseScreen;
    public Button PauseButton;
    public static bool paused;

    public Text MessageUI;
    public Text InfoUI;

    public AudioClip notele1;
    public AudioClip notele2;

    public KeyCode ESC;

    void Start()
    {
        paused = false;
        PauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(ESC) && !paused)
        {
            Pause();
        }
    }

    public void Pause()
    {
        if ((IsMouseOverButton() || Input.GetKeyDown(ESC)) && Info.paused == false)
        {
            PauseScreen.SetActive(true);
            paused = true;
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        PauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }

    public void ShowKey()
    {
        if(FindObjectOfType<GoLvl3Scene1>() != null)
        {
            if ((FindObjectOfType<PlayerStats>().enemyCounter >= 5 && FindObjectOfType<PlayerStats>().coinsCollected == 45) && FindObjectOfType<PlayerStats>().vaseDestroyed == false){
                FindObjectOfType<Vase>().destroyVase();
                Resume();
            }

            else if (FindObjectOfType<PlayerStats>().vaseDestroyed == true)
            {
                MessageUI.text = "Alert: Key already revealed";
                InfoUI.color = Color.red;
                MessageUI.color = Color.red;
                Resume();
            }

            else
            {
                MessageUI.text = "Alert: Complete Kills and Gems target to unlock 'Reveal Key' option";
                AudioManager.instance.RandomizeSfx(notele1, notele2);
                InfoUI.color = Color.red;
                MessageUI.color = Color.red;
                Resume();
            }
        }
    }

    bool IsMouseOverButton()
    {
        RectTransform rectTransform = PauseButton.GetComponent<RectTransform>();
        Vector2 mousePosition = Input.mousePosition;

        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePosition, null, out localMousePosition);

        return rectTransform.rect.Contains(localMousePosition);
    }

    public void Lvl1Scene1Restart()
    {
        Application.LoadLevel(1);
        Resume();
    }

    public void Lvl1Scene2Restart()
    {
        Application.LoadLevel(2);
        Resume();
    }

    public void Lvl2Scene1Restart()
    {
        Application.LoadLevel(3);
        Resume();
    }

    public void Lvl2Scene2Restart()
    {
        Application.LoadLevel(4);
        Resume();
    }

    public void Lvl3Scene1Restart()
    {
        Application.LoadLevel(5);
        Resume();
    }

    public void Lvl3Scene2Restart()
    {
        Application.LoadLevel(6);
        Resume();
    }

    public void mainMenu()
    {
        Application.LoadLevel(0);
        Resume();
        AudioManager.instance.musicSource.Stop();
        AudioManagerIntro.instance.musicSource.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
