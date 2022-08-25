using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class Click : MonoBehaviour
{
    public bool nextLevel;
    public bool active;
    public float activeDelayTime;
    public bool destroySelf;
    public bool inActive;
    public float inActiveDelayTime;
    public bool camTransition;
    public bool camTransNew;
    public float camSpeed=.1f;
    public bool nextLevelButton;
    public float buttonTime=0;
    public bool camZoomOut;
    public float zoomSpeed;
    public float targetSize;
    public List<GameObject> afterCamObj;
    public List<GameObject> inActiveObj;
    public List<GameObject> activeObj;

    public GameObject camTarget;

    public UnityEvent OnClick;

    private Transform cam;
    private bool isMove;

    public bool isZoom;

    void Start()
    {
        cam = GameObject.FindObjectOfType<CinemachineVirtualCamera>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (isMove)
        {
            CamTransNew(camTarget.transform, camSpeed, afterCamObj);
        }

        if (isZoom)
        {
            CamZoomOut(zoomSpeed,afterCamObj);
        }
    }

    private void OnMouseDown()
    {
        //if(EventSystem.current.IsPointerOverGameObject())
            //return;
            
        //Debug.Log("111");
        if (active)
        {
            EventHandler.CallActiveGameObjects(activeObj,activeDelayTime);


        }
        
        if (nextLevel)
        {
            GameManager.instance.NextLevel();
        }

        if (inActive)
        {
            EventHandler.CallInactiveGameObjects(inActiveObj,inActiveDelayTime);

        }

        if (camTransition)
        {
            EventHandler.CallCameraTransEvent(camTarget,camSpeed,afterCamObj);

        }
        
 

        if (nextLevelButton)
        {
            ActiveNextLevelButton(buttonTime);
            

        }
        
        OnClick?.Invoke();

        if (destroySelf)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
            


        if (camTransNew && !isMove)
        {

            isMove = true;
        }

        if (camZoomOut && !isZoom)
        {
            isZoom = true;
        }
        


        
    }

    public void Active()
    {
        EventHandler.CallActiveGameObjects(activeObj,activeDelayTime);
        if(destroySelf)
            Destroy(gameObject);
    }
    
        
    public void ActiveNextLevelButton(float time)
    {
        StartCoroutine(ActiveButton(time));
    }

    public IEnumerator ActiveButton(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.instance.NextLevelButton();
    }
    
    public void CamTrans(){
        EventHandler.CallCameraTransEvent(camTarget,camSpeed,afterCamObj);
    
    }

    public void CamTransNewEvent()
    {
        CamTransNew(camTarget.transform, camSpeed, afterCamObj);
    }
    
    public void CamTransNew(Transform targetObj, float speed, List<GameObject> afterCamObj)
    {
        cam.position = Vector3.MoveTowards(cam.transform.position, targetObj.transform.position -new Vector3(0,0,10), speed);
        
        if (Vector2.Distance(cam.transform.position, targetObj.transform.position)<0.01f   )
        {
            EventHandler.CallActiveGameObjects(afterCamObj,0);


            isMove = false;
        }   
        
    }

    public void CamZoomOut(float speed, List<GameObject> afterCamObj)
    {
        cam.GetComponentInParent<CinemachineVirtualCamera>().m_Lens.OrthographicSize += zoomSpeed ;
        
        if (cam.GetComponentInParent<CinemachineVirtualCamera>().m_Lens.OrthographicSize > targetSize)
        {
            EventHandler.CallActiveGameObjects(afterCamObj,0);
            isZoom = false;
        }

        
    }

    public void InActive()
    {
        EventHandler.CallInactiveGameObjects(inActiveObj,inActiveDelayTime);
    }

    public void DestroySelf()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    
    
}
