using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSlider : MonoBehaviour
{
    public GameObject bar;
    public float barValue;
    public float speed;
    
    public bool isBreatheIn;

    public int stageNum;

    public List<GameObject> stagesBg;
    public List<float> stageMax;

    public bool autoZero;
    public GameObject barFill;
    public Color barOriColor;

    public GameObject breatheInImage;
    public GameObject breatheOutImage;
    public List<GameObject> finalActiveObj;
    public List<GameObject> finalInActiveObj;

    void Start()
    {
        barOriColor = barFill.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        barValue = bar.GetComponent<Slider>().value;
        
        
        
        if (barValue>0 && !isBreatheIn )
        {
            barValue -= speed * Time.deltaTime;
        }
        else if (barValue < stageMax[stageNum]+0.1 && isBreatheIn)
        {
            barValue += speed * Time.deltaTime;
        }

        if (barValue <= 0)
        {
            isBreatheIn = true;
            autoZero = false;
            breatheOutImage.SetActive(false);
            breatheInImage.SetActive(true);

            if (stageNum == 4)
            {
                EventHandler.CallActiveGameObjects(finalActiveObj,0f);
                EventHandler.CallInactiveGameObjects(finalInActiveObj,0f);
            }
        }

        if (barValue>=stageMax[stageNum]+0.1)
        {
            isBreatheIn = false;
            breatheOutImage.SetActive(true);
            breatheInImage.SetActive(false);
        }
        
        bar.GetComponent<Slider>().value = barValue;

        if (autoZero)
        {
            barFill.GetComponent<Image>().color = Color.green;
            isBreatheIn = false;
            breatheOutImage.SetActive(true);
            breatheInImage.SetActive(false);
        }
            
            
        else
        {
            barFill.GetComponent<Image>().color = barOriColor;
        }
        
        
        switch (stageNum)
        {
            case 0:
                if (Input.GetMouseButtonDown(0) && barValue > 0.2 && barValue < 0.23   && !autoZero)
                {
                    stageNum++;
                    stagesBg[0].SetActive(false);
                    stagesBg[1].SetActive(true);

                    isBreatheIn = false;
                    autoZero = true;
                    speed -= 0.05f;

                }
                break;
            
            case 1:
                if (Input.GetMouseButtonDown(0) && barValue > 0.4 && barValue < 0.44  && !autoZero)
                {
                    stageNum++;
                    stagesBg[1].SetActive(false);
                    stagesBg[2].SetActive(true);
                    
                    isBreatheIn = false;
                    autoZero = true;
                    speed -= 0.05f;
                }
                break;
            case 2:
                if (Input.GetMouseButtonDown(0) && barValue > 0.6 && barValue < 0.66   && !autoZero)
                {
                    stageNum++;
                    stagesBg[2].SetActive(false);
                    stagesBg[3].SetActive(true);
                    
                    isBreatheIn = false;
                    autoZero = true;
                    speed -= 0.05f;
                }
                break;
            case 3:
                if (Input.GetMouseButtonDown(0) && barValue > 0.8 && barValue < 0.88   && !autoZero)
                {
                    stageNum++;
                    stagesBg[3].SetActive(false);
                    stagesBg[4].SetActive(true);
                    
                    isBreatheIn = false;
                    autoZero = true;
                    speed -= 0.05f;
                }
                break;
             
            
            
        }
    }
}
