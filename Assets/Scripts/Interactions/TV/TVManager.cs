using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVManager : MonoBehaviour
{
    public static TVManager instance;

    public int tvNum = 0;

    public List<GameObject> tvImages;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < tvImages.Count; i++)
        {
            if (i==tvNum)
            {
                tvImages[i].SetActive(true);
            }
            else
            {
                tvImages[i].SetActive(false);
            }

            
        }
    }
}
