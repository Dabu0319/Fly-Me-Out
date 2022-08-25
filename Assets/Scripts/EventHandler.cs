using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{

    public static event Action<List<GameObject>, float > ActiveGameObjectsEvent;
    public static void CallActiveGameObjects(List<GameObject> activeObjects,float delayTime)
    {
        ActiveGameObjectsEvent?.Invoke(activeObjects,delayTime);
    }
    
    public static event Action<List<GameObject>, float > InactiveGameObjectsEvent;
    public static void CallInactiveGameObjects(List<GameObject> inactiveObjects,float delayTime)
    {
        InactiveGameObjectsEvent?.Invoke(inactiveObjects,delayTime);
    }
    
    
    

    public static event Action<GameObject,float,List<GameObject>> CameraTransEvent;
    public static void CallCameraTransEvent(GameObject targetCam,float speed,List<GameObject> activeObj)
    {
        CameraTransEvent?.Invoke(targetCam,speed,activeObj);
    }
    

}
