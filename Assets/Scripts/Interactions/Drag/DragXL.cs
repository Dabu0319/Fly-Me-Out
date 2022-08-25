using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragXL : Drag
{
// private Vector3 _dragOffset;
//     private Camera _cam;
//     
//
//     public Transform targetPos;
//
//     public bool finalPiece;
//
//     private bool canDrag = true;
//     
//
//     [SerializeField] private float _speed = 100;

    public int currentNum;

    public bool changeColor = true;

    public bool isRotating;
    public bool rotateCheck;

    public Vector3 originPos;
    
    public override void Awake() {
        // _cam = Camera.main;
        base.Awake();
    }

    private void Start()
    {
        originPos = transform.position;
    }

    private void Update()
    {

    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        // _dragOffset = transform.position - GetMousePos();
            
    }

    public override void OnMouseDrag() {
        

        base.OnMouseDrag();

        if (Input.GetMouseButton(0)& isRotating)
        {
            transform.RotateAround(GetMousePos(),Vector3.forward,60*Time.deltaTime);
        }
        

        
        //Debug.Log("DragXL");

    }

    private void OnMouseUp()
    {
        if (transform.position.x < -5.5 || transform.position.x > 5.5 || transform.position.y > 8.5f ||
            transform.position.y < -9.0f)
        {
            transform.position = originPos;
        }

        if (targetPos != null)
        {
            
            if (Vector2.Distance(transform.position, targetPos.position) < 1      &&   canDrag)
            {
                
                if (!rotateCheck || (Mathf.Abs(Quaternion.Euler(targetPos.transform.rotation.eulerAngles-transform.rotation.eulerAngles).eulerAngles.z) > 300 && Mathf.Abs(Quaternion.Euler(targetPos.transform.rotation.eulerAngles-transform.rotation.eulerAngles).eulerAngles.z)< 330))
                {
                    transform.position = targetPos.position;
                    //拖拽失效

                    //JigsawManager.instance.currentNum++;
                    JigsawManager.instance.currentNum++;
                    canDrag = false;
                    
                    targetPos.gameObject.SetActive(true);
                    gameObject.SetActive(false);
                    
                    
                    if (changeColor)
                    {
                        GetComponent<SpriteRenderer>().color = Color.cyan;
                    }
                    
                    //targetPos.gameObject.GetComponentInParent<DragXL>().canDrag = false;
                    
                }
                
                
                // else if ( JigsawManager.instance.currentNum == JigsawManager.instance.totalNum)
                // {
                //     transform.position = targetPos.position;
                //
                //     canDrag = false;
                //     //targetPos.gameObject.GetComponentInParent<DragXL>().canDrag = false;
                //     if (changeColor)
                //     {
                //         GetComponent<SpriteRenderer>().color = Color.cyan;
                //     }
                //     //this.GetComponent<Animator>().SetTrigger("Away");
                //     //targetPos.gameObject.GetComponentInParent<Animator>().SetTrigger("Away");
                //     
                //     EventHandler.CallActiveGameObjects(GameManager.instance.buttonList,1);
                // }

            }
        }

    }


}
