using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressUp : MonoBehaviour
{
public GameObject bar;
    public float barValue;
    public float speed;
    
    public bool isBreatheIn;

    public int stageNum;
    public List<float> stageBottom;

    public List<GameObject> stagesBg;
    public List<GameObject> stageSucceed;
    public List<GameObject> stageAlert;
    public List<float> stageMax;

    public bool autoZero;
    public GameObject barFill;
    public Color barOriColor;

    public GameObject breatheInImage;
    public GameObject breatheOutImage;
    public List<GameObject> finalActiveObj;
    public List<GameObject> finalInActiveObj;

    public SoundEffectManager breathInSoundManager;
    public SoundEffectManager breathOutSoundManager;
    public SoundEffectManager buttonSoundManager;


    void Start()
    {
        barOriColor = barFill.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        barValue = bar.GetComponent<Slider>().value;
        
        
        
        if (barValue>=stageBottom[stageNum] && !isBreatheIn )
        {
            barValue -= (speed +0.2f) * Time.deltaTime;
        }
        else if (barValue <= stageBottom[stageNum+1] && isBreatheIn)
        {
            barValue += speed * Time.deltaTime;
        }

        if (barValue <= stageBottom[stageNum])
        {
            isBreatheIn = true;
            autoZero = false;
            breatheOutImage.SetActive(false);
            breatheInImage.SetActive(true);
            if (breathInSoundManager) breathInSoundManager.PlaySoundOnce();

            if (stageNum == 3)
            {
                EventHandler.CallActiveGameObjects(finalActiveObj,0f);
                EventHandler.CallInactiveGameObjects(finalInActiveObj,0f);
            }
        }

        if (barValue>=stageBottom[stageNum+1])
        {
            isBreatheIn = false;
            breatheOutImage.SetActive(true);
            breatheInImage.SetActive(false);
            if (breathOutSoundManager) breathOutSoundManager.PlaySoundOnce();

        }

        bar.GetComponent<Slider>().value = barValue;

        if (autoZero)
        {
            //barFill.GetComponent<Image>().color = Color.green;
            isBreatheIn = false;
            breatheOutImage.SetActive(true);
            breatheInImage.SetActive(false);
            if (breathOutSoundManager) breathOutSoundManager.PlaySoundOnce();

        }


        else
        {
            barFill.GetComponent<Image>().color = barOriColor;
        }
        
        
        switch (stageNum)
        {
            case 0:
                if (  barValue > 0.3 && barValue < 0.36   && !autoZero)
                {

                    if (Input.GetMouseButtonDown(0))
                    {
                        stageNum++;
                        stagesBg[0].SetActive(false);
                        stageSucceed[0].SetActive(true);
                        stageAlert[0].SetActive(false);

                        isBreatheIn = false;
                        autoZero = true;

                        if (buttonSoundManager) buttonSoundManager.PlaySoundOnce();
                        //speed -= 0.05f;
                    }
                    else
                    {
                        stageAlert[0].SetActive(true);
                        stagesBg[0].SetActive(false);
                    }
                    


                }
                else
                {
                    stageAlert[0].SetActive(false);
                    stagesBg[0].SetActive(true);
                }
                break;
            
            case 1:
                if (  barValue > 0.63 && barValue < 0.69   && !autoZero)
                {

                    if (Input.GetMouseButtonDown(0))
                    {
                        stageNum++;
                        stagesBg[1].SetActive(false);
                        stageSucceed[1].SetActive(true);
                        stageAlert[1].SetActive(false);

                        isBreatheIn = false;
                        autoZero = true;

                        if (buttonSoundManager) buttonSoundManager.PlaySoundOnce();
                        //speed -= 0.05f;
                    }
                    else
                    {
                        stageAlert[1].SetActive(true);
                        stagesBg[1].SetActive(false);
                    }
                    


                }
                else
                {
                    stageAlert[1].SetActive(false);
                    stagesBg[1].SetActive(true);
                }
                break;
            case 2:
                if (  barValue > 0.97 && barValue < 1.03   && !autoZero)
                {

                    if (Input.GetMouseButtonDown(0))
                    {
                        stageNum++;
                        stagesBg[2].SetActive(false);
                        stageSucceed[2].SetActive(true);
                        stageAlert[2].SetActive(false);

                        isBreatheIn = false;
                        autoZero = true;

                        if (buttonSoundManager) buttonSoundManager.PlaySoundOnce();
                        //speed -= 0.05f;
                    }
                    else
                    {
                        stageAlert[2].SetActive(true);
                        stagesBg[2].SetActive(false);
                    }
                    


                }
                else
                {
                    stageAlert[2].SetActive(false);
                    stagesBg[2].SetActive(true);
                }
                break;
            // case 3:
            //     if (Input.GetMouseButtonDown(0) && barValue > 0.8 && barValue < 0.88   && !autoZero)
            //     {
            //         stageNum++;
            //         stagesBg[3].SetActive(false);
            //         stagesBg[4].SetActive(true);
            //         
            //         isBreatheIn = false;
            //         autoZero = true;
            //         speed -= 0.05f;
            //     }
            //     break;
             
            
            
        }
    }
}
