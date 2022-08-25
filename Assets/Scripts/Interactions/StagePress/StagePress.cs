using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePress : MonoBehaviour
{
    public bool isUp;
    public GameObject bar;
    public float barValue;
    public float speed = 0.15f;
    public bool autoZero;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        barValue = bar.GetComponent<Slider>().value;
        
        if (barValue <= 1 )
        {
            if (Input.GetMouseButtonDown(0))
            {
                isUp = true;
                
            }

            if (Input.GetMouseButton(0)&& !autoZero)
            {
                barValue += speed * Time.deltaTime;
                bar.GetComponent<Slider>().value = barValue;
            }
            else if (barValue >= 0 && barValue <= 1)
            {
                isUp = false;
                
                barValue -= speed * Time.deltaTime;
                bar.GetComponent<Slider>().value = barValue;
                
                //归零后重新控制
                if(barValue <=0.01f)
                {
                    autoZero = false;
                    
                }
            }

            
        }
    }
}
