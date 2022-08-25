using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceLine : MonoBehaviour
{
    public Transform targetPoint;
    public bool isWeight;
    public List<GameObject> weights;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetPoint.position - new Vector3(0, 2f, 0);
        
        WeightPos();
    }

    public void WeightPos()
    {
        int pos = 0;
        for (int i = 0; i < weights.Count; i++)
        {
            weights[i].transform.position = transform.position - new Vector3(0, 2 + pos, 0);
            pos++;
        }
    }
}
