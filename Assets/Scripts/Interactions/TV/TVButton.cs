using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVButton : MonoBehaviour
{
    public bool left;
    public bool right;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (left && TVManager.instance.tvNum > 0)
        {
            TVManager.instance.tvNum--;
        }
        else if (right && TVManager.instance.tvNum < 3)
        {
            TVManager.instance.tvNum++;
        }
            
    }
}
