using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionNum : MonoBehaviour
{
    public GameObject bg1;

    public GameObject bg2;

    public GameObject bg3;

    public List<GameObject> foods;

    public int activeNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeNum = 0;
        for (int i = 0; i < foods.Count; i++)
        {
            if (foods[i].activeSelf ==true)
            {
                activeNum++;
            }
            
        }
        if (activeNum ==1)
        {
            bg2.SetActive(true);
        }

        if (activeNum == 0)
        {
            bg3.SetActive(true);
        }
    }
}
