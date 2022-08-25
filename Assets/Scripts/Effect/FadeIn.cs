using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float speed =1f;
    public Color color;
    public bool isText;
    void Start()
    {
        if (isText)
        {
            color = GetComponent<Text>().color;
            color.a = 0;

        
            GetComponent<Text>().color = color;
        }
        else
        {
            color = GetComponent<SpriteRenderer>().color;
            color.a = 0;

        
            GetComponent<SpriteRenderer>().color = color;
        }


        //Debug.Log(color.a);
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a<1)
        {
            color.a += speed * Time.deltaTime;
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
