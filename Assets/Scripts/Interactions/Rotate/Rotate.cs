using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //public Vector3 offset;
    private Vector3 downPoint;
    public Camera _cam;

    public static Rotate instance;

    public float a;

    public float angle;
    public float angle1;

    public Quaternion oriRotation;

    public Sprite finalSprite;

    public List<GameObject> finalObj;

    public float finalAngleMin;
    public float finalAngleMax;
    public bool canRotate;
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
        
        

        
        
    }

    private void OnMouseDown()
    { 
        downPoint = GetMousePos();
        oriRotation = transform.rotation;

    }

    private void OnMouseDrag()
    {



        angle = Angle360(GetMousePos(), downPoint);
        
        if(canRotate)
           transform.rotation = Quaternion.Euler(new Vector3(0,0,oriRotation.eulerAngles.z-angle));
        //angle1 = Vector3.Angle(GetMousePos(),downPoint);
        //Debug.Log(angle);
    }
    
    

    private void OnMouseUp()
    {
        if (transform.rotation.eulerAngles.z > finalAngleMin && transform.rotation.eulerAngles.z < finalAngleMax)
        {
            GetComponent<SpriteRenderer>().sprite = finalSprite;
            canRotate = false;
            EventHandler.CallActiveGameObjects(finalObj,0f);
        }
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
