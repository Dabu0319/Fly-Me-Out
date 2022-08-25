using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breathe : MonoBehaviour
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

    public GameObject final;
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
        
        if (Input.GetMouseButtonUp(0) && barValue > 0.3 && barValue < 0.3666 && breathStage == 0 && isBreathIn)
        {
            stageImages[0].SetActive(false);
            stageImages[1].SetActive(true);
            stageClotheImage[0].SetActive(false);
            stageClotheImage[1].SetActive(true);
            breathStage++;
            autoZero = true;
            succeedFall = true;
            fillArea.GetComponent<Image>().color = succeedColor;

        }

        if (Input.GetMouseButtonUp(0) && barValue > 0.6 && barValue < 0.6888 && breathStage == 1 && isBreathIn)
        {
            stageImages[2].SetActive(false);
            stageImages[3].SetActive(true);
            stageClotheImage[1].SetActive(false);
            stageClotheImage[2].SetActive(true);
            breathStage++;
            autoZero = true;
            succeedFall = true;
            fillArea.GetComponent<Image>().color = succeedColor;
        }
        
        if (Input.GetMouseButtonUp(0) && barValue >= 0.99 && barValue <=1.0f && breathStage == 2 && isBreathIn)
        {
            stageImages[4].SetActive(false);
            stageImages[5].SetActive(true);
            stageClotheImage[2].SetActive(false);
            stageClotheImage[3].SetActive(true);
            breathStage++;
            //autoZero = true;

            barValue = 1.0f;
            fillArea.GetComponent<Image>().color = succeedColor;
            
            final.SetActive(true);
            
            //GameManager.instance.NextLevelButton(2);
        }

        if (barValue <= 1 && breathStage!=3)
        {
            if (Input.GetMouseButtonDown(0) && !autoZero)
            {
                isBreathIn = true;
                
            }

            if (Input.GetMouseButton(0)&& !autoZero)
            {
                barValue += speed * Time.deltaTime;
                isBreathIn = true;
                fillArea.GetComponent<Image>().color = originColor;
                bar.GetComponent<Slider>().value = barValue;
            }
            
            
            else if (barValue >= 0 && barValue <= 1)
            {
                isBreathIn = false;
                autoZero = true;
                
                barValue -= speed* 1.5f * Time.deltaTime;
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




        


        
        
        


    }
}
