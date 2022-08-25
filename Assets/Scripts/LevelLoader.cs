using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Animation Transition")]
    public static LevelLoader instance;
    public Animator transition;
    public float transitionTime = 2f;
    
    [Header("Value Transition")]
    public bool isFade;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 10f;

    private void Awake()
    {
        instance = this;
        transition = GetComponentInChildren<Animator>();
        //fadeCanvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(fadeCanvasGroup.alpha); 
    }

    public void LoadAnim()
    {
        transition.SetTrigger("Start");
    }
    
    public IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        
        Debug.Log(fadeCanvasGroup.alpha); 
        

        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha,targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
        
        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;
    }
    
    
    
    
}
