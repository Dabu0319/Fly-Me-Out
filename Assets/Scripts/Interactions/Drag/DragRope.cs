using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragRope : Drag
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

    public GameObject targetImage;

    public Color targetColor;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (targetEvent && transform.position.x < targetXMax && transform.position.x > targetXMin &&
            transform.position.y < targetYMax && transform.position.y > targetYMin)
        {
            afterDrag?.Invoke();
            //GuideManager.instance.succeed = true;
            canDrag = false;
        }

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
        
        targetColor.a = (float)(0.5 +
                                (transform.position.y - scopeYMax) * 0.5 / (scopeYMax - scopeYMin));
        
        Debug.Log(targetColor.a);
        targetImage.GetComponent<SpriteRenderer>().color = targetColor;





    }
}