using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreatheArea : MonoBehaviour
{
    public Vector3 oriScale;
    public float targetScaleNum;

    public float speed = 0.1f;

    public bool isBreatheIn;
    void Start()
    {
        oriScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > oriScale.x  && !isBreatheIn )
        {
            transform.localScale -= speed * new Vector3(1,1,1);
        }
        else if (transform.localScale.x < targetScaleNum && isBreatheIn)
        {
            transform.localScale += speed * new Vector3(1,1,1);
        }

        if (transform.localScale.x <= oriScale.x)
        {
            isBreatheIn = true;
        }

        if (transform.localScale.x >= targetScaleNum)
        {
            isBreatheIn = false;
        }
        
    }

    private void OnMouseDrag()
    {

        isBreatheIn = true;  
        
    }

    private void OnMouseUp()
    {
        isBreatheIn = false;
    }
}
