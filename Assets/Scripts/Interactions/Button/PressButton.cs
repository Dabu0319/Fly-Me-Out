using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        target.SetActive(true);
        TextManager.instance.currentNum++;
    }

    private void OnMouseUp()
    {
        target.SetActive(false);
    }
}
