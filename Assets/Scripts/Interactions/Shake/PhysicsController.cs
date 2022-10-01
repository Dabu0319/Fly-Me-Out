using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float shakeForceMultiplier;
    public Rigidbody2D[] shakingObjects;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Shake(Vector3 deviceAcceleration)
    {
        foreach (Rigidbody2D rb in shakingObjects)
        {
            rb.AddForce(deviceAcceleration * shakeForceMultiplier,ForceMode2D.Impulse);
        }
    }
}
