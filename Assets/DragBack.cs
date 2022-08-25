using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBack : Drag
{
    public Vector3 oriPos;
    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {

        transform.localPosition = oriPos;
        
    }
}
