using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public GameObject image01;
    Color image1A;
    public GameObject image02;
    Color image2A;
    public GameObject image03;
    Color image3A;

    public bool toNextLevel = true;
    public float sliderValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log( (float)1/3);
        sliderValue = this.GetComponent<Slider>().value;
        if (0 < sliderValue && sliderValue < (float)1/3)
        {

            image1A = image01.GetComponent<SpriteRenderer>().color;
            image1A.a = 1 - 3 * (sliderValue);
            image01.GetComponent<SpriteRenderer>().color = image1A;
        }
        else if (sliderValue >= (float)1/3 && sliderValue < (float)2/3)
        {
            image2A = image02.GetComponent<SpriteRenderer>().color;
            image2A.a = 3 * sliderValue - 1;
            Debug.Log("222");
            image02.GetComponent<SpriteRenderer>().color = image2A;
        }
        else if (sliderValue >= (float)2/3 && sliderValue < 1)
        {
            image3A = image03.GetComponent<SpriteRenderer>().color;
            image3A.a = 3 * sliderValue - 2;
            image03.GetComponent<SpriteRenderer>().color = image3A;
        }
        else if(sliderValue == 1)
        {
            GetComponent<Slider>().interactable = false;
            
            if(toNextLevel)
                GameManager.instance.NextLevelButton();
        }
    }
}
