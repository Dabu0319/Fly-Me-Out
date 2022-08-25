using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionActive : MonoBehaviour
{
    public GameObject[] conditionObjects;

    public GameObject activeObj;

    public bool isActive = false;

    public bool activeDetect;

    public bool inActiveDetect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ConditionAllActive());
        //Debug.Log(activeObj.name);
        if(activeObj==null)
            return;
        if (ConditionAllActive()  &&  activeObj.activeSelf ==false && activeDetect)
        {
            activeObj.SetActive(true);
            //isActive = true;
            activeDetect = false;
        }
        
        if (ConditionAllInactive()  && activeObj.activeSelf ==false && inActiveDetect)
        {
            activeObj.SetActive(true);
            //isActive = true;
            inActiveDetect = false;
        }

        
        
        
        
    }

    public bool ConditionAllActive()
    {
        for (int i = 0; i < conditionObjects.Length; i++)
        {
            if (conditionObjects[i].activeSelf == false)
                return false;
        }

        
        return true;

        
    }

    public bool ConditionAllInactive()
    {
        for (int i = 0; i < conditionObjects.Length; i++)
        {
            if (conditionObjects[i].activeSelf == true)
                return false;
        }

        return true;
        
        
    }
    
}
