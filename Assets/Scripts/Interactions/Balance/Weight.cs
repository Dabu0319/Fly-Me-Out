using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;

public class Weight : Drag
{
    public int weight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (targetPos.GetComponent<BalanceLine>().weights.Contains(gameObject))
        {
            targetPos.GetComponent<BalanceLine>().weights.Remove(this.gameObject);
            Balance.instance.rightWeight -= weight;
        }


    }

    public override void OnMouseDrag() {
        

        base.OnMouseDrag();
        
        



    }

    public  void OnMouseUp()
    {
        if (Vector2.Distance(transform.position, targetPos.position) < 5)
        {
            
            targetPos.GetComponent<BalanceLine>().weights.Add(this.gameObject);
            Balance.instance.rightWeight += weight;
        }
    }
}
