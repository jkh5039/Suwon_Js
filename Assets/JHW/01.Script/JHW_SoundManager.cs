using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_SoundManager : MonoBehaviour
{
    public static JHW_SoundManager instance;
    AudioSource MyAudio;

    public AudioClip buttonClick;
    public AudioClip engineOn;
    public AudioClip[] Crash;
    public AudioClip accel;
    public AudioClip back;
    public AudioClip BGM;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MyAudio = GetComponent<AudioSource>();
    }

    public void PlayButtonClick()
    {
        MyAudio.PlayOneShot(buttonClick);
    }

    public void PlayEngineOn()
    {
        MyAudio.PlayOneShot(engineOn);
    }
    public void PlayCrash()
    {
        int i = Random.Range(0, 4);
        MyAudio.PlayOneShot(Crash[i]);
    }
    public void PlayAccel()
    {
        MyAudio.PlayOneShot(accel);
    }
    public void PlayBack()
    {
        MyAudio.PlayOneShot(back);
    }
    public void PlayBGM()
    {
        MyAudio.PlayOneShot(BGM);
    }
    
}
