using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treadmill : MonoBehaviour
{
    public float moveSpeed;
    public float valueSpeed;
    public float upSpeed = 0.02f;

    public float value;

    public Vector3 oriPos;
    public GameObject conveyor;

    public GameObject slider;

    public GameObject warning;
    public bool stop;
    void Start()
    {
        oriPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0.5)
        {
            warning.SetActive(true);
        }
        else
        {
            warning.SetActive(false);
        }

        if (transform.position.y > 4.5)
        {
            GameManager.instance.Restart();
        }
        
        if (value >= 1)
        {
            value = 1;
            stop = true;
            if (conveyor.GetComponent<Conveyor>().speed > 0)
            {
                conveyor.GetComponent<Conveyor>().speed -= 0.5f;
            }
            
            GameManager.instance.NextLevelButton();
            

        }
        
        
        if (value <= 0f)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if(value > 0 && transform.position.y >= oriPos.y)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        
        
        

        if (Input.GetMouseButtonDown(0))
        {
            value += upSpeed;
        }
        else if(value>=0 && !stop)
        {
            value -= valueSpeed * Time.deltaTime;
        }


        slider.GetComponent<Slider>().value = value;
        
        //传送带速度

        if (!stop)
        {
            conveyor.GetComponent<Conveyor>().speed = value * 10 + 3;
        }
        

    }
}
