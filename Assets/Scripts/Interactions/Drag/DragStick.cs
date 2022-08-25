using System;
using UnityEngine;

public class DragStick : Drag 
{

    // private Vector3 _dragOffset;
    // private Camera _cam;
    //
    //
    // public Transform targetPos;

    public bool finalPiece;

    // private bool canDrag = true;
    //
    //
    // [SerializeField] private float _speed = 100;



    private void Start()
    {
        
    }




    private void OnMouseUp()
    {

        if (targetPos != null)
        {
            
            if (Vector2.Distance(transform.position, targetPos.position) < 5)
            {
                if (!finalPiece&&canDrag)
                {
                    transform.position = targetPos.position;
                    //拖拽失效

                    JigsawManager.instance.currentNum++;
                    canDrag = false;
                    targetPos.gameObject.GetComponentInParent<DragStick>().canDrag = false;
                }
                else if (finalPiece && JigsawManager.instance.currentNum == JigsawManager.instance.totalNum)
                {
                    transform.position = targetPos.position;

                    canDrag = false;
                    targetPos.gameObject.GetComponentInParent<DragStick>().canDrag = false;
                    
                    this.GetComponent<Animator>().SetTrigger("Away");
                    targetPos.gameObject.GetComponentInParent<Animator>().SetTrigger("Away");
                    
                    EventHandler.CallActiveGameObjects(GameManager.instance.buttonList,3);
                }

                
                
                

            }
        }

    }

}