using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideManager : MonoBehaviour
{
    public static GuideManager instance;
    public GameObject hoverEffect;
    public List<Transform> guidePoints;
    public int guidePointNum = 0;
    
    public bool succeed;
    public float startTime;
    public float repeatTime;

    private void Awake()
    {
        instance = this;
        foreach (Transform point in transform )
        {
            guidePoints.Add(point);
        }
    }

    void Start()
    {
        InvokeRepeating("AddGuide",startTime,repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(succeed)
            CancelInvoke("AddGuide");
    }

    public void AddGuide()
    {
        //Debug.Log("add");
        Instantiate(hoverEffect, guidePoints[guidePointNum].position,hoverEffect.transform.rotation);

    }



    public void Succeed()
    {
        succeed = true;

    }

    public void NextGuidePoint()
    {
        guidePointNum++;
    }
    
}
