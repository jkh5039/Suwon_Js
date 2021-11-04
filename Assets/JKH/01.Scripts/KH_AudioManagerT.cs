using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_AudioManagerT : MonoBehaviour
{

    public AudioClip audioParkBG;
    public AudioClip audioDriveBG;
    public AudioClip audioBreak;
    public AudioClip audioAccel;
    public AudioClip audioBell;
    AudioSource Audiosource;

    private void Awake()
    {
        this.Audiosource = GetComponent<AudioSource>();
    }
    void PlaySound(string action)
    {

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
