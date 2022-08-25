using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dragger : MonoBehaviour
{
    public bool xRestriction;
    private Vector3 _dragOffset;
    private Camera _cam;
    private Rigidbody2D _rb;

    public float xPosMax;
    public float xPosMin;

    [SerializeField] private float _speed = 100;

    private Vector3 originPos;
    public bool inTarget;
    public UnityEvent targetEvent;

    public bool BacktoOrigin;
    private void Update()
    {
        if (xRestriction)
        {
            if (transform.position.x >= xPosMax)
            {
                transform.position = new Vector3(xPosMax, transform.position.y);
            }

            if (transform.position.x <= xPosMin)
            {
                transform.position = new Vector3(xPosMin, transform.position.y);
            }
        }

    }

    void Awake() {
        _cam = Camera.main;
        originPos = transform.position;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void OnMouseDown()
    {

        
        _dragOffset = transform.position - GetMousePos();
        //_rb.gravityScale = 0f;
        //_rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseDrag() {


        
       
        if (xRestriction)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(GetMousePos().x + _dragOffset.x,0,0), _speed * Time.deltaTime) ;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime) ;
        }
        
        
        

        //_rb.AddForce(_dragOffset*_speed,ForceMode2D.Force);
        //transform.position = GetMousePos() + _dragOffset;
        ;
        //_rb.gravityScale = 0f;
    }

    private void OnMouseUp()
    {
        if (BacktoOrigin)
        {
            if (inTarget)
            {
                gameObject.SetActive(false);
                targetEvent.Invoke();
            }
            else
            {
                transform.position = originPos;
            }
        }

        //_rb.bodyType = RigidbodyType2D.Dynamic;
        
        //_rb.gravityScale = 1;
    }

    Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Target"))
        {
            inTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            inTarget = false;
        }
    }
}
