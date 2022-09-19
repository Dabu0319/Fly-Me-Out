using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatGrow : MonoBehaviour
{
    public List<GameObject> eatObjects;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EatObjects"))
        {
            Destroy(col.gameObject);
            eatObjects.Remove(col.gameObject);
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

            GetComponent<SpriteRenderer>().color -= new Color(0.1f, 0.1f, 0.1f, 0f);

            //random color
            Camera.main.backgroundColor = UnityEngine.Random.ColorHSV();

            //speed up
            foreach (var obj in eatObjects)
            {
                obj.GetComponent<RandomMove>().speed += 0.5f;
            }
            
            //drag slow down
            GetComponent<Drag>()._speed -= 10f;
        }
    }
    
    //Change color darker

    
    
}
