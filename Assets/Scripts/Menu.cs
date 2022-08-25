using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject aboutPage;
    public GameObject settingPage;

    public GameObject startButton;
    public GameObject continueButton;
    public GameObject newGameButton;

    public GameObject chapterSelectPage;

    public bool mainMenu;


    void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (mainMenu)
        {
            if (SaveSystem.LoadLevel() != null)
            {
                continueButton.SetActive(true);
                newGameButton.SetActive(true);
                startButton.SetActive(false);
            }
            else
            {
                startButton.SetActive(true);
            }
        }


    }


    public void AboutPage()
    {
        aboutPage.SetActive(true);
    }

    public void AboutPageBack()
    {
        aboutPage.SetActive(false);
    }

    public void SettingPage()
    {
//        Debug.Log("111");
        settingPage.SetActive(true);
        Time.timeScale = 0;
    }

    public void SettingPageBack()
    {
        settingPage.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
        
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

    public void ChapterSelectPage()
    {
        chapterSelectPage.SetActive(true);
        
    }

    public void ChapterSelectPageBack()
    {
        chapterSelectPage.SetActive(false);
    }
 

    
    
}
