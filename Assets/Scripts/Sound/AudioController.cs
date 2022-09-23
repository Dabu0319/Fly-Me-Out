using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public string stopBgm;
    public string newBgm;

    public bool mainMenu;

    private void Awake()
    {
        

        
        
    }

    void Start()
    {
        



        if (mainMenu)
        {
            AudioManager.instance.Stop(AudioManager.instance.bgm);
            //AudioManager.instance.Stop("Child");
            //AudioManager.instance.Stop("BackHome");
            //AudioManager.instance.Stop("Start");
            
        }
        
        AudioManager.instance.Stop(stopBgm);
        AudioManager.instance.Play(newBgm);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAudio()
    {
        
        Destroy(FindObjectOfType<AudioManager>().gameObject);
        
    }
}
