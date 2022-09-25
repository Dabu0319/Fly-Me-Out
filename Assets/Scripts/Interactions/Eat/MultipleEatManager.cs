using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleEatManager : MonoBehaviour
{
    public static MultipleEatManager instance;

    public int eatCount = 0;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eatCount == 5)
        {
            GameManager.instance.NextLevelButton();
        }
    }



    
}
