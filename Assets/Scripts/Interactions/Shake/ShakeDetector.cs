using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsController))]
public class ShakeDetector : MonoBehaviour
{
    public float shakeThreshold  ;
    public float minShakeInterval ;
    
    private float sqrShakeThreshold;
    private float lastShakeTime;
    
    private PhysicsController physicsController;
    void Start()
    {
        sqrShakeThreshold = Mathf.Pow(shakeThreshold, 2);
        physicsController = GetComponent<PhysicsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.acceleration.sqrMagnitude >= sqrShakeThreshold && Time.time - lastShakeTime > minShakeInterval)
        {
            lastShakeTime = Time.unscaledTime;
            physicsController.Shake(Input.acceleration);
        }
    }
}
