using System;
using System.Collections;
using System.Collections.Generic;
using ScratchCardAsset;
using UnityEngine;

public class ScratchCheck : MonoBehaviour
{
    private EraseProgress EraseProgress; //EraseProgress component reference
    private bool finish;

    public float finishProgress = 0.6f;
    
    public List<GameObject> inActiveObj;
    public float inActiveDelayTime;
    
    
    public List<GameObject> activeObj;
    public float activeDelayTime;

    public bool needClear;

    //private float lastProgress;
    //private int soundHelper = 0;


    public SoundEffectManager soundEffectManager;


    void Awake()
    {
        EraseProgress = GetComponentInParent<EraseProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<EraseProgress>().GetProgress() > finishProgress && !finish )
        {
            EventHandler.CallInactiveGameObjects(inActiveObj,inActiveDelayTime);
            EventHandler.CallActiveGameObjects(activeObj,activeDelayTime);

            if (needClear)
            {
                GetComponentInParent<ScratchCard>().FillInstantly();
            }
            
            finish = true;
            
            if(GuideManager.instance != null)
                 GuideManager.instance.NextGuidePoint();
        }


      
        
    }

    private void OnEnable()
    {
        EraseProgress.OnProgress += OnEraseProgress;
    }

    //subscribe to OnProgress event, that invokes when texture scratches
    
    private void OnEraseProgress(float progress)

    {
        //if (progress > 0.8) soundHelper = 0;
        //if (progress > lastProgress)
        //{
        //    lastProgress = progress;
        //    if (soundEffectManager) soundEffectManager.PlaySoundLoop();
        //} else
        //{
        //    if (soundHelper < 10) return;
        //    if (soundEffectManager)
        //    {
        //        soundEffectManager.StopSound();
        //        soundHelper = 0;
        //    }
        //}


    }

    


}
