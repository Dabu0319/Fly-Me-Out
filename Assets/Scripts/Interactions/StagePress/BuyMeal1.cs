using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMeal1 : MonoBehaviour
{
 public bool isBreathIn = true;
    public GameObject bar;
    public float barValue;
    public float speed;

    public int breathStage;

    public GameObject breatheInImage;
    public GameObject breatheOutImage;

    public List<GameObject> stageImages;
    public List<GameObject> stageClotheImage;

    public bool autoZero;

    public GameObject fillArea;
    public Color originColor;
    public Color succeedColor;
    public Color failCOlor;
    private bool succeedFall;

    public List<GameObject> final;
    public GameObject finalInactive;

    public GameObject scene01;
    public GameObject scene02;
    public GameObject uiSlider;

    public bool finalAuto;
    void Start()
    {
        //originColor = fillArea.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        barValue = bar.GetComponent<Slider>().value;
        
        breatheInImage.SetActive(isBreathIn);
        breatheOutImage.SetActive(!isBreathIn);
        
        
        // if ( barValue >= 0.99)
        // {
        //     stageImages[0].SetActive(false);
        //     stageImages[1].SetActive(true);
        //     //stageClotheImage[7].SetActive(true);
        //     barValue = 1.001f;
        //
        //
        //
        //     //GameManager.instance.NextLevelButton(2);
        // }

        if (barValue <= 1 && breathStage!=4)
        {


            // if (barValue >= 0 && barValue <= 1 && autoZero)
            // {
            //     barValue -= speed * Time.deltaTime;
            //
            //     
            //     //归零后重新控制
            //     if (barValue <= 0.01f)
            //     {
            //         autoZero = false;
            //         succeedFall = false;
            //         fillArea.GetComponent<Image>().color = originColor;
            //     }
            // }
            // if (Input.GetMouseButtonDown(0) && !autoZero)
            // {
            //     isBreathIn = true;
            //     
            // }

            if (Input.GetMouseButton(0)&& !autoZero)
            {

                barValue += speed * Time.deltaTime;
                isBreathIn = true;
                fillArea.GetComponent<Image>().color = originColor;
                bar.GetComponent<Slider>().value = barValue;
            }
            
            
            else if (barValue >= 0 && barValue <= 1 && !finalAuto)
            {

               
                isBreathIn = false;
                autoZero = true;
                barValue -= 1.5f *speed * Time.deltaTime;
                if(!succeedFall)
                    fillArea.GetComponent<Image>().color = failCOlor;
                
                bar.GetComponent<Slider>().value = barValue;
                
                //归零后重新控制
                if(barValue <=0.01f)
                {
                    autoZero = false;
                    succeedFall = false;
                    fillArea.GetComponent<Image>().color = originColor;
                }
            }

            
        }
        
        if (barValue>=1)
        {
            barValue = 1.001f;
            foreach (var item in final)
            {
                item .SetActive(true);
            }
            uiSlider.SetActive(false);
            finalInactive.SetActive(false);
        }


        


        


        
        
        


    }
}
