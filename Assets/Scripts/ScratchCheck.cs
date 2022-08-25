using System.Collections;
using System.Collections.Generic;
using ScratchCardAsset;
using UnityEngine;

public class ScratchCheck : MonoBehaviour
{
    private bool finish;

    public float finishProgress = 0.6f;
    
    public List<GameObject> inActiveObj;
    public float inActiveDelayTime;
    
    
    public List<GameObject> activeObj;
    public float activeDelayTime;

    public bool needClear;
    void Start()
    {
        
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
}
