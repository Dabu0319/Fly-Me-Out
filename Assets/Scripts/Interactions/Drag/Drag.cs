using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    public Vector3 _dragOffset;
    public Camera _cam;
    public bool canDrag = true;
    
    public float _speed = 100;
    
    public Transform targetPos;
    public float targetRot;
    
    public virtual void Awake() {
         _cam = Camera.main;
    }

    public virtual void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
            
    }
    
    public virtual void OnMouseDrag() {

        if (canDrag)
        {
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime) ;
        }
            


       

    }
    
    
    
    
    public virtual Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }



}
