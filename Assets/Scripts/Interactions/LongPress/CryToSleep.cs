using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryToSleep : LongPress
{
    public float stage01Num;
    public float stage02Num;
    
    public GameObject image00;
    public GameObject image01;
    public GameObject image02;
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
        if(colorA.a<stage01Num)
            image00.SetActive(true);
            
        if (colorA.a >= stage01Num && colorA.a<stage02Num)
        {
            image00.SetActive(false);
            image01.SetActive(true);
            image02.SetActive(false);
            
        }

        if (colorA.a >= stage02Num)
        {
            image01.SetActive(false);
            image02.SetActive(true);
        }
    }
}
