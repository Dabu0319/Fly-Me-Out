using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public int sceneNum;

    public static DataManager instance;

    

    private void Awake()
    {
        instance = this;
        
        SaveSystem.FileCheck();


    }

    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        if (sceneNum > 0)
        {
            SaveSystem.SaveLevel(sceneNum);
            //Debug.Log(sceneNum);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    
}
