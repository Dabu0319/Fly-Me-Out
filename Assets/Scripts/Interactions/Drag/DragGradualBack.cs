using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGradualBack : Drag
{
    public float speed = 1;
    
    public Vector3 oriPos;

    public bool isDragging;
    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDragging)
        {
            transform.position = Vector3.MoveTowards(transform.position, oriPos, speed);
        }
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
