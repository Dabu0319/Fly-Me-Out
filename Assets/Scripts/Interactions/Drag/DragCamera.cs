using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragCamera : Drag
{
    public float scopeXMax;
    public float scopeXMin;
    public float scopeYMax;
    public float scopeYMin;
    
    public float targetXMax;
    public float targetXMin;
    public float targetYMax;
    public float targetYMin;

    public GameObject activeFrame;

    public GameObject defaultFrame;
    public bool targetDetect = true;

    public bool targetEvent = false;
    public UnityEvent afterDrag;
    
    

   
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

        if (canDrag)
        {
            if (transform.position.x>scopeXMax)
            {
                transform.position=new Vector2(scopeXMax,transform.position.y);
            }
            if (transform.position.x<scopeXMin)
            {
                transform.position=new Vector2(scopeXMin,transform.position.y);
            }
            if (transform.position.y>scopeYMax)
            {
                transform.position=new Vector2(transform.position.x,scopeYMax);
            }
            if (transform.position.y<scopeYMin)
            {
                transform.position=new Vector2(transform.position.x,scopeYMin);
            }
        }


        if (targetDetect)
        {
            if (transform.position.x < targetXMax && transform.position.x > targetXMin &&
                transform.position.y < targetYMax && transform.position.y > targetYMin)
            {
                activeFrame.SetActive(true);
                defaultFrame.SetActive(false);
            }
            else
            {
                activeFrame.SetActive(false);
                defaultFrame.SetActive(true);
            }
        }

        if (targetEvent && transform.position.x < targetXMax && transform.position.x > targetXMin &&
            transform.position.y < targetYMax && transform.position.y > targetYMin)
        {
            afterDrag?.Invoke();
            GuideManager.instance.succeed = true;
            canDrag = false;
        }

    }
}
