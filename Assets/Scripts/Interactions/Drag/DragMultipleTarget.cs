using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMultipleTarget : Drag
{
    public float targetDis;
    public List<Transform> targetPoses;
    
    public bool needBack;
    public Vector3 oriPos;
    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.localPosition;
        Debug.Log(transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        foreach (var target in targetPoses)
        {
            //Debug.Log(Vector2.Distance(transform.position, target.position));
            if (Vector2.Distance(transform.position, target.position) < targetDis && canDrag && target.childCount == 0)
            {
                transform.parent = target;
                transform.position = target.position;
                canDrag = false;
                GetComponent<BoxCollider2D>().enabled = false;

                JigsawManager.instance.currentNum++;
                return;
            }

            
        }
        
        if (canDrag && needBack)
        {
            transform.localPosition = oriPos;
        }



        

    }
}
