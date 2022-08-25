using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
   

    Coroutine runningLerpCameraAnimation;


    private float elapsedTime;

    public bool camMove;
    public bool stopMove;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        EventHandler.CameraTransEvent += OnCameraTransEvent;
    }

    private void OnDisable()
    {
        EventHandler.CameraTransEvent -= OnCameraTransEvent;
    }

    private void OnCameraTransEvent(GameObject targetObj,float speed, List<GameObject> afterCamObj)
    {
        //GetComponent<CinemachineVirtualCamera>().Follow = targetObj.transform;
    
        //Vector2.MoveTowards(transform.position, targetObj.transform.position, 10000 * Time.deltaTime);

        

        
        
        if (runningLerpCameraAnimation != null)
             StopCoroutine(runningLerpCameraAnimation);
        
        runningLerpCameraAnimation = StartCoroutine(SlowMove(targetObj,speed,afterCamObj));

        
        
        
    }

    private IEnumerator SlowMove(GameObject targetObj,float speed,List<GameObject> afterCamObj)
    {
        //有个问题现在都是相对于初始相机，应该改为现在已经看向的
        //Debug.Log(Vector2.Distance(transform.position, targetObj.transform.position));
        
        while (Vector2.Distance(transform.position, targetObj.transform.position)>0.01f)
        {
            elapsedTime += Time.deltaTime;
            float percentage = elapsedTime / speed;
            
            transform.position = Vector3.Lerp(transform.position , new Vector3(targetObj.transform.position.x,targetObj.transform.position.y,transform.position.z),percentage  );
            yield return null;
        }
        
        EventHandler.CallActiveGameObjects(afterCamObj,0.5f);
        
        
       
        
        
    }

    // public void NormalMove(GameObject targetObj, float speed, List<GameObject> afterCamObj)
    // {
    //     StartCoroutine(NormalMoveStart(targetObj, speed, afterCamObj));
    // }
    // public IEnumerator NormalMoveStart(GameObject targetObj, float speed, List<GameObject> afterCamObj)
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, targetObj.transform.position, speed);
    //     
    //     
    //     
    // }
    
    // public void NormalMove(GameObject targetObj, float speed, List<GameObject> afterCamObj)
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, targetObj.transform.position -new Vector3(0,0,10), speed);
    //     if (Vector2.Distance(transform.position, targetObj.transform.position)<0.01f  && !camMove && !stopMove )
    //     {
    //         EventHandler.CallActiveGameObjects(afterCamObj,0);
    //
    //         camMove = true;
    //         stopMove = true;
    //         
    //         Debug.Log("111");
    //     }
    // }

    private void Update()
    {

    }
}
