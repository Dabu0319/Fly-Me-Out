using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float speed =1f;
    public Color color;
    public bool isText;

    public bool startFadeOut = false;
    void Start()
    {
        if (isText)
        {
            color = GetComponent<Text>().color;
            color.a = 1;

        
            GetComponent<Text>().color = color;
        }
        else
        {
            color = GetComponent<SpriteRenderer>().color;
            color.a = 1;

        
            GetComponent<SpriteRenderer>().color = color;
        }


        //Debug.Log(color.a);
    }

    // Update is called once per frame
    void Update()
    {
        if (startFadeOut)
        {
            if (color.a>0)
            {
                color.a -= speed * Time.deltaTime;
                if (isText)
                {
                    GetComponentInParent<Text>().color = color;
                }
                else
                {
                    GetComponentInParent<SpriteRenderer>().color = color;
                }
            
            }
        }

    }

    public void StartFadeOut()
    {
        startFadeOut = true;
    }
}
