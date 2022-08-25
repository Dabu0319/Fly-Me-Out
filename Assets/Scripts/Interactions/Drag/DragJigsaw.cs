using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragJigsaw : Drag
{
    public float targetDis = 1;
    public UnityEvent afterDrag;

    public bool needBack;
    public Vector3 oriPos;
    
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
        if (Vector2.Distance(transform.position, targetPos.position) < targetDis   &&  canDrag)
        {
            targetPos.gameObject.SetActive(true);
            canDrag = false;

            JigsawManager.instance.currentNum++;
            gameObject.SetActive(false);
            afterDrag?.Invoke();
            
        }
        else if (needBack)
        {
            transform.localPosition = oriPos;
        }

    }
}
