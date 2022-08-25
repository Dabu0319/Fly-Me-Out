using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JigsawManager : MonoBehaviour
{
    public static JigsawManager instance;

    public int totalNum;
    public int currentNum;
    
    private bool finish;

    public Transform jigsaws;



    public List<GameObject> inActiveObj;
    public float inActiveDelayTime;
    
    
    public List<GameObject> activeObj;
    public float activeDelayTime;

    public UnityEvent afterJigsaw;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (totalNum == currentNum && !finish)
        {
            EventHandler.CallInactiveGameObjects(inActiveObj,inActiveDelayTime);
            EventHandler.CallActiveGameObjects(activeObj,activeDelayTime);
            afterJigsaw?.Invoke();

            if (jigsaws != null)
            {
                foreach (Transform obj in jigsaws)
                {
                    obj.GetComponent<Collider2D>().enabled = false;
                
                }
            }
            else
            {
                
            }

            
            finish = true;
        }
    }
}
