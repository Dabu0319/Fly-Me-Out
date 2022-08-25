using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool transition = true;

    public List<GameObject> buttonList;

    private void Awake()
    {
        instance = this;
        
        GameObject.FindObjectOfType<LevelLoader>(true).gameObject.SetActive(true);
        
        
        
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

    public void NextLevel()
    {
        if (transition)
        {
            //这里的0是不需要二次延时
            StartCoroutine(LoadNextLevel(0));
            
            //数值控制
            //LevelLoader.instance.StartCoroutine(LevelLoader.instance.Fade(1));
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    //加转场效果等待的下一关
    public void NextLevelWaitForSeconds(int time)
    {
        if (transition)
        {
            StartCoroutine(LoadNextLevel(0));
        }
        else
        {
            StartCoroutine(NextLevelWait(time));
        }
    }

    //等待后下一关 包括动画的时间
    IEnumerator LoadNextLevel(int time)
    {
        LevelLoader.instance.LoadAnim();
        yield return new WaitForSeconds(LevelLoader.instance.transitionTime);

        StartCoroutine(NextLevelWait(time));
    }

    //再次等待后下一关
    IEnumerator NextLevelWait(int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    //显示下一关按钮
    public void NextLevelButton()
    {
        EventHandler.CallActiveGameObjects(GameManager.instance.buttonList,.5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Int32.Parse(SaveSystem.LoadLevel()));
    }

    public void NewGame()
    {
        SaveSystem.SaveLevel(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    
    
}
