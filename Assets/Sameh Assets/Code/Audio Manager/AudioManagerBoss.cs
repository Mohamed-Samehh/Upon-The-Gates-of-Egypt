using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerBoss : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static AudioManagerBoss instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;

        efxSource.clip = clips[randomIndex];

        efxSource.Play();
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }
}
