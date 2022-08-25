using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    public Vector3 offset;
    private Vector3 downPoint;
    public Camera _cam;

    public static Knob instance;

    public float a;

    public float angle;
    public float angle1;

    public Quaternion oriRotation;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        a = (Mathf.Abs(10*(offset.y +6)));
        //this.transform.rotation = Quaternion.Euler(new Vector3(0,0,oriRotation.eulerAngles.z-angle));
        this.transform.rotation = Quaternion.Euler(new Vector3(0,0,-angle));

        //Debug.Log(GetMousePos());
        
    }

    private void OnMouseDown()
    { 
        downPoint = GetMousePos();
        oriRotation = transform.rotation;

    }

    private void OnMouseDrag()
    {
        //offset =  GetMousePos() - downPoint;
        //angle = 


        angle = Angle360(GetMousePos(), downPoint);
        angle1 = Vector3.Angle(GetMousePos(),downPoint)  ;
        //angle1 = oriRotation.eulerAngles.z - angle;
        //Debug.Log(angle);
    }
    
    public virtual Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        var mouseoffset = mousePos - transform.position;
        return mouseoffset;
    }
    
    public static float Angle360(Vector2 p1, Vector2 p2, Vector2 o = default(Vector2))
    {
        Vector2 v1, v2;
        if (o == default(Vector2))
        {
            v1 = p1.normalized;
            v2 = p2.normalized;
        }
        else
        {
            v1 = (p1 - o).normalized;
            v2 = (p2 - o).normalized;
        }
        float angle = Vector2.Angle(v1, v2);
        return Mathf.Sign(Vector3.Cross(v1, v2).z) < 0 ? (360 - angle) % 360 : angle;
    }
}
