using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreatheManager : MonoBehaviour
{
    public Text breatheInText;
    public Text breatheOutText;
    public Text timerText;
    public Text startText;
    
    public float defaultTime = 4;
    public float currentTime;
    public bool isStart;
    public bool isBreatheIn;
    private void Start()
    {
        currentTime = defaultTime;
    }

    private void Update()
    {
        if (!isStart)
        {
            if (Input.GetMouseButton(0))
                isStart = true;
        }
        if (isStart)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                if(!isBreatheIn)
                  defaultTime++;
                currentTime = defaultTime;
                isBreatheIn = !isBreatheIn;
            }
            
            
            startText.gameObject.SetActive(false);
            breatheInText.gameObject.SetActive(isBreatheIn);
            breatheOutText.gameObject.SetActive(!isBreatheIn);
        }

        timerText.text = Mathf.Ceil(currentTime).ToString("0");
        
        

    }
}
