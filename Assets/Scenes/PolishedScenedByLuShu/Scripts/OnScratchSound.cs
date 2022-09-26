using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScratchSound : MonoBehaviour
{
    public SoundEffectManager soundEffectManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            if (soundEffectManager) soundEffectManager.PlaySoundLoop();
        } else
        {
            if (soundEffectManager) soundEffectManager.StopSound();
        }
    }
}
