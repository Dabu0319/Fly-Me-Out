using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeMove : MonoBehaviour
{
    public GameObject oppositeObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oppositeObj.transform.position = new Vector3(-transform.position.x,transform.position.y,transform.position.z);
    }
}
