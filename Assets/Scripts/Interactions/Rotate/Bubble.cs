using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float x1;
    public float x2;

    public float offset;
    private Color color;

    public bool finalBubble;
    void Start()
    {
        
        color = GetComponent<SpriteRenderer>().color;
        Debug.Log(color.a);
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        
    }

    // Update is called once per frame
    void Update()
    {
        //color.a = (float)(5 * (Knob.instance.a) * 50 - 2.5 * x1 -2.5 * x2) /10000  + offset;





        color.a = ((float)(1.0f / 100f) * Knob.instance.angle1 + offset);
        //Debug.Log((float)(1f/2f));
        GetComponent<SpriteRenderer>().color = color;


        if (finalBubble)
        {
            if (GetComponent<SpriteRenderer>().color.a > 0.8)
                GetComponent<BoxCollider2D>().enabled = true;
            else
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }
}
