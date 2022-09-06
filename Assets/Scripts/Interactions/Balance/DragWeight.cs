using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWeight : Drag
{

    public float weight;
    
    public Sprite originSprite;
    public Sprite transSprite;

    public Vector3 originPos;

    private void Start()
    {
        originSprite = GetComponent<SpriteRenderer>().sprite;
        originPos = transform.position;
    }

    public override void OnMouseDown()
    {

        if (Balance.instance.rotating)
        {
            transform.position = originPos;
                
            return;
        }



            
        
        base.OnMouseDown();
        
        GetComponent<SpriteRenderer>().sprite = originSprite;
        
        if (targetPos.GetComponent<BalanceLine>().weights.Contains(gameObject))
        {
            targetPos.GetComponent<BalanceLine>().weights.Remove(this.gameObject);
            Balance.instance.lastWeight = Balance.instance.rightWeight;
            Balance.instance.rightWeight -= weight;
            

            Balance.instance.BalanceDetect();
        }
        
        

        

    }

    public override void OnMouseDrag()
    {

        if (Balance.instance.rotating)
        {
            transform.position = originPos;
            
            return;
        }

        base.OnMouseDrag();
    }

    public  void OnMouseUp()
    {

        if (Balance.instance.rotating)
        {
            
            return;
        }
        
        if (targetPos.GetComponent<BalanceLine>().weights.Contains(gameObject))
            return;
        
        if (Vector2.Distance(transform.position, targetPos.position) < 6)
        {
            
            targetPos.GetComponent<BalanceLine>().weights.Add(this.gameObject);
            GetComponent<SpriteRenderer>().sprite = transSprite;
            Balance.instance.lastWeight = Balance.instance.rightWeight;
            Balance.instance.rightWeight += weight;
            
            if(Balance.instance.rotating)
                return;
            
            Balance.instance.BalanceDetect();
        }
    }
}
