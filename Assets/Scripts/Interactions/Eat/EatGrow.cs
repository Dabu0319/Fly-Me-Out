using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatGrow : MonoBehaviour
{
    public List<GameObject> eatObjects;
    
    public float growRate = 0.1f;
    public float maxScale = 10f;

    public int i;
    void Start()
    {
        StartCoroutine(Test());
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("111");
        //     i += 1;
        // }
    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EatObjects"))
        {
            Destroy(col.gameObject);
            eatObjects.Remove(col.gameObject);
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

            GetComponent<SpriteRenderer>().color -= new Color(growRate, growRate, growRate, 0f);

            //random color
            Camera.main.backgroundColor = UnityEngine.Random.ColorHSV();

            //speed up
            foreach (var obj in eatObjects)
            {
                obj.GetComponent<RandomMove>().speed += 0.5f;
            }
            
            //drag slow down
            GetComponent<Drag>()._speed -= maxScale;
        }
    }
    
    




    IEnumerator Test()
    {
        i = 0;

        yield return new WaitForSeconds(3);
        
        Debug.Log(i);
    }
    
    
    
    
    

    
    
}
