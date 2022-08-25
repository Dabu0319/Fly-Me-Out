using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDestroyUI : MonoBehaviour,IPointerClickHandler
{
       public Camera mainCamera;
      

       void Update ()
    {
            // RaycastHit2D hit;
            //
            // Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //
            // if(hit = Physics2D.Raycast(ray.origin, new Vector2(0,0)))
            //     Destroy(gameObject);
    }

       public void OnPointerClick(PointerEventData eventData)
       {
           Destroy(gameObject);
       }
}
