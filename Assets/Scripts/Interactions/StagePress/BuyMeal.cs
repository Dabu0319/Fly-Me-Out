using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMeal : MonoBehaviour
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


        if (Input.GetMouseButtonUp(0) && barValue > 0.16 && barValue < 0.24 && breathStage == 0 && !autoZero)
        {
            stageImages[0].SetActive(false);
            stageImages[1].SetActive(true);
            stageClotheImage[0].SetActive(true);
            stageClotheImage[1].SetActive(true);
            breathStage++;
            autoZero = true;
            succeedFall = true;
            fillArea.GetComponent<Image>().color = succeedColor;

        }

        if (Input.GetMouseButtonUp(0) && barValue > 0.36 && barValue < 0.44 && breathStage == 1 && !autoZero)
        {
            stageImages[2].SetActive(false);
            stageImages[3].SetActive(true);
            stageClotheImage[2].SetActive(true);
            stageClotheImage[3].SetActive(true);
            breathStage++;
            autoZero = true;
            succeedFall = true;
            fillArea.GetComponent<Image>().color = succeedColor;
            
            
            //scene01.SetActive(true);
            
            
        }
        
        if (Input.GetMouseButtonUp(0) && barValue >= 0.56 && barValue <= 0.64f && breathStage == 2 && !autoZero)
        {
            stageImages[4].SetActive(false);
            stageImages[5].SetActive(true);
            stageClotheImage[4].SetActive(true);
            stageClotheImage[5].SetActive(true);
            breathStage++;
            //autoZero = true;

            //barValue = 1.0f;
            fillArea.GetComponent<Image>().color = succeedColor;
            
            scene01.SetActive(true);
            finalAuto = true;
            this.gameObject.SetActive(false);
            
            
            
            //GameManager.instance.NextLevelButton(2);
        }
        
        if ( barValue >= 0.8 )
        {
            stageImages[6].SetActive(false);
            stageImages[7].SetActive(true);
            stageClotheImage[6].SetActive(true);

        }
        
        if ( barValue >= 0.99)
        {
            stageImages[8].SetActive(false);
            stageImages[9].SetActive(true);
            stageClotheImage[7].SetActive(true);

            
            
            //GameManager.instance.NextLevelButton(2);
        }

        if (barValue <= 1 && breathStage!=4)
        {
            if (breathStage == 3 && barValue <1 )
            {
                barValue += speed * Time.deltaTime;
                bar.GetComponent<Slider>().value = barValue;
            }

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
            barValue = 1;
            foreach (var item in final)
            {
                item .SetActive(true);
            }
            uiSlider.SetActive(false);
            finalInactive.SetActive(false);
        }


        


        


        
        
        


    }
}
