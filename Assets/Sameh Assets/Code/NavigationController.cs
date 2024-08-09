using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public AudioClip DesertMusic;
    public AudioClip TempleMusic;
    public AudioClip BossMusic;

    public void GoToIntroScene()
    {
        Application.LoadLevel(0);
        AudioManagerIntro.instance.musicSource.Play();
    }

    public void GoToIntroFromVictory()
    {
        Application.LoadLevel(0);
        AudioManagerVictory.instance.musicSource.Stop();
        AudioManagerIntro.instance.musicSource.Play();
    }

    public void GoToIntroFromOver()
    {
        Application.LoadLevel(0);
        AudioManagerOver.instance.musicSource.Stop();
        AudioManagerIntro.instance.musicSource.Play();
    }

    public void GoToGamePlaySceneFromIntro()
    {
        Application.LoadLevel(1);
        AudioManagerIntro.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = DesertMusic;
        AudioManager.instance.musicSource.Play();
    }

    public void GoToGamePlaySceneFromVictory()
    {
        Application.LoadLevel(1);
        AudioManagerVictory.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = DesertMusic;
        AudioManager.instance.musicSource.Play();
    }

    public void GoToGamePlaySceneFromOver()
    {
        Application.LoadLevel(1);
        AudioManagerOver.instance.musicSource.Stop();
        AudioManager.instance.musicSource.clip = DesertMusic;
        AudioManager.instance.musicSource.Play();
    }

    public void GoToGameOverScene()
    {
        Application.LoadLevel(7);
        AudioManager.instance.musicSource.Stop();
        AudioManagerOver.instance.musicSource.Play();
    }

    public void GoToVictoryScene()
    {
        Application.LoadLevel(8);
        AudioManager.instance.musicSource.Stop();
        AudioManagerVictory.instance.musicSource.Play();
    }

    public void retryLevel()
    {
        if(levelSet.level == 2)
        {
            Application.LoadLevel(2);
            AudioManagerOver.instance.musicSource.Stop();
            AudioManager.instance.musicSource.clip = DesertMusic;
            AudioManager.instance.musicSource.Play();
        }

        else if (levelSet.level == 3)
        {
            Application.LoadLevel(3);
            AudioManagerOver.instance.musicSource.Stop();
            AudioManager.instance.musicSource.clip = TempleMusic;
            AudioManager.instance.musicSource.Play();
        }

        else if (levelSet.level == 4)
        {
            Application.LoadLevel(4);
            AudioManagerOver.instance.musicSource.Stop();
            AudioManager.instance.musicSource.clip = TempleMusic;
            AudioManager.instance.musicSource.Play();
        }

        else if (levelSet.level == 5)
        {
            Application.LoadLevel(5);
            AudioManagerOver.instance.musicSource.Stop();
            AudioManager.instance.musicSource.clip = TempleMusic;
            AudioManager.instance.musicSource.Play();
        }

        else if (levelSet.level == 6)
        {
            Application.LoadLevel(6);
            AudioManagerOver.instance.musicSource.Stop();
            AudioManager.instance.musicSource.clip = BossMusic;
            AudioManager.instance.musicSource.Play();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
