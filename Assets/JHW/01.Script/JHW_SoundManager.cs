using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHW_SoundManager : MonoBehaviour
{
    public static JHW_SoundManager instance;
    public AudioSource MyAudio;

    public AudioClip buttonClick;
    public AudioClip engineOn;
    public AudioClip[] Crash;
    public AudioClip accel;
    public AudioClip back;
    public AudioClip success;
    public AudioClip klaxon;



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
        MyAudio.PlayOneShot(buttonClick,0.5f);
    }

    public void PlayEngineOn()
    {
        MyAudio.PlayOneShot(engineOn);
    }
    public void PlayCrash()
    {
        int i = Random.Range(0, 4);
        MyAudio.PlayOneShot(Crash[i], 0.2f) ;
    }
    public void PlayAccel()
    {
        if (MyAudio.isPlaying!=accel)
        {
            MyAudio.PlayOneShot(accel, 0.1f);
        }
    }
    public void PlayBack()
    {
        if(MyAudio.isPlaying!=back)
        {
        MyAudio.PlayOneShot(back,0.2f);
        }
    }
    public void PlaySuccess()
    {
        MyAudio.PlayOneShot(success);
    }
    public void PlayKlaxon()
    {
        MyAudio.PlayOneShot(klaxon,0.5f);
    }
}
