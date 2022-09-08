using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentalAnimation : MonoBehaviour
{
    public int animNum = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        NextAnim();
    }

    public void NextAnim()
    {
        animNum++;
        GetComponent<Animator>().SetInteger("animNum",animNum);
    }
}
