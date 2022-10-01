using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPour : Drag
{

    public GameObject liquid;
    public Transform pourPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void OnMouseDrag()
    {
        base.OnMouseDrag();
        transform.rotation = Quaternion.Euler(0, 0, 115);
        liquid.SetActive(true);
    }

    private void OnMouseUp()
    {
        
        liquid.SetActive(false);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    
    //rotate the transform degrees around the z axis
    public void Rotate(float degrees)
    {
        transform.Rotate(0, 0, degrees);
    }
}
