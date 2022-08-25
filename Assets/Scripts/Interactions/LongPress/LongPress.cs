using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LongPress : MonoBehaviour
{
    public GameObject pressObj;
    public float speed = 10f;
    public Color colorA;

    public float activeDelayTime;
    
    public List<GameObject> activeTargetObjs;
    public List<GameObject> inactiveTargetObjs;

    public bool camMove;
    public GameObject camTarget;
    public bool camTransition;
    public float camSpeed=.1f;
    public List<GameObject> afterCamObj;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Debug.Log(pressObj.GetComponent<SpriteRenderer>().color);
        colorA = pressObj.GetComponent<SpriteRenderer>().color;
        
        
        if (Input.GetMouseButton(0) && colorA.a <= 1.0f )
        {
            
            
            colorA.a += speed * Time.deltaTime;
            
        }
        else if(colorA.a >= 0 && colorA.a <= 1.0f)
        {
            colorA.a -= speed * Time.deltaTime;
            
        }
        else if (colorA.a>=1.0f)
        {
            //targetObj.SetActive(true);
            EventHandler.CallActiveGameObjects(activeTargetObjs,activeDelayTime);
            EventHandler.CallInactiveGameObjects(inactiveTargetObjs,activeDelayTime);
            if(camMove)
               CamTrans();

            GuideManager.instance.succeed = true;
        }
        
        
        pressObj.GetComponent<SpriteRenderer>().color = colorA;
        
        
        
    }
    
    public void CamTrans(){
        EventHandler.CallCameraTransEvent(camTarget,camSpeed,afterCamObj);
    
    }


}
