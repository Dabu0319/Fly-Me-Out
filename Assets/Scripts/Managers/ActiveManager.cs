using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class ActiveManager : MonoBehaviour
{
    
    public void OnEnable()
    {
        EventHandler.ActiveGameObjectsEvent += ActiveAllEvent;
        EventHandler.InactiveGameObjectsEvent += InactiveAllEvent;
    }


    public void OnDisable()
    {
        EventHandler.ActiveGameObjectsEvent -= ActiveAllEvent;
        EventHandler.InactiveGameObjectsEvent -= InactiveAllEvent;
    }

    public void ActiveAllEvent(List<GameObject> activeObj,float delayTime)
    {

        StartCoroutine(ActiveGameObjects(activeObj, delayTime));
        

    }

    public void ActiveObj(GameObject activeObj)
    {
        activeObj.SetActive(true);
    }

    public IEnumerator ActiveGameObjects(List<GameObject> activeObj,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        foreach (var obj in activeObj)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
            
        }
    }

    public void InactiveObj(GameObject inacitiveObj)
    {
        inacitiveObj.SetActive(false);
    }
    
    
    public void InactiveAllEvent(List<GameObject> inacitiveObj, float delayTime)
    {

        StartCoroutine(InactiveGameObjects(inacitiveObj, delayTime));
        

    }
    
    public IEnumerator InactiveGameObjects(List<GameObject> inactiveObj,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        foreach (var obj in inactiveObj)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
            
        }
    }

}
