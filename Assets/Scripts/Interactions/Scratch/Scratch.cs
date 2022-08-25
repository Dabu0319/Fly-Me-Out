using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scratch : MonoBehaviour
{

    public GameObject mask;

    public GameObject maskLayer;

    private bool pressed;

    public UnityEvent afterScratchEvent;
    public int layerNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        if (pressed == true)
        {
            GameObject ob = Instantiate(mask, pos, Quaternion.identity,transform);
            //ob.transform.parent = GameObject.Find("scratch").transform;
        }

        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }
        else if(Input.GetMouseButtonUp(0))

        {
            pressed = false;
        }

        if (transform.childCount>layerNum)
        {
            Destroy(maskLayer);
            
            afterScratchEvent?.Invoke();
        }
        
        //Debug.Log(transform.childCount);
        
    }
}
