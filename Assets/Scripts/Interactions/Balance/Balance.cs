using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Balance : MonoBehaviour
{
    public static Balance instance;
    public bool rotating;

    public int leftWeight;
    public int rightWeight;

    public bool isLeft;
    public bool isRight;
    private Transform target;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        target = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft && (rightWeight > leftWeight))
        {
            StartCoroutine(RotateObject(transform, target, Vector3.forward, -30f, 2f));
            isLeft = false;
            isRight = true;
            Debug.Log("111");
        }
        else if (isRight && leftWeight > rightWeight)
        {
            StartCoroutine(RotateObject(transform, target, Vector3.forward, 30f, 2f));
            isLeft = true;
            isRight = false;
            Debug.Log("111");
        }
    }
    
    private IEnumerator RotateObject(Transform camTransform, Transform targetTransform, Vector3 rotateAxis, float degrees, float totalTime)
    {
        if (rotating)
            yield return null;
        rotating = true;
 
        
        //利用直接旋转角度来计算rotation
        Quaternion startRotation = camTransform.rotation;
        Vector3 startPosition = camTransform.position;
        // Get end position;
        transform.RotateAround(targetTransform.position, rotateAxis, degrees);
        Quaternion endRotation = camTransform.rotation;
        Vector3 endPosition = camTransform.position;
        camTransform.rotation = startRotation;
        camTransform.position = startPosition;
 
        
        
        float rate = degrees / totalTime;
        //Start Rotate
        for (float i = 0.0f; Mathf.Abs(i) < Mathf.Abs(degrees); i += Time.deltaTime * rate)
        {
            camTransform.RotateAround(targetTransform.position, rotateAxis, Time.deltaTime * rate);
            yield return null;
        }
 
        camTransform.rotation = endRotation;
        camTransform.position = endPosition;
        rotating = false;
        

        
    }
    
}
