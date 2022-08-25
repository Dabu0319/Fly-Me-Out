using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeighPress : MonoBehaviour
{
    public GameObject pressObj;
    public GameObject unPressObj;

    public float startAngle = 359f;
    public float speed = 0.1f;

    public GameObject rotateObj;

    public float targetAngle;

    public GameObject alarmObj;
    public List<GameObject> finalObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rotateObj.transform.rotation.eulerAngles.z);
        if ( rotateObj.transform.rotation.eulerAngles.z < targetAngle)
        {
            if (Input.GetMouseButton(0))
            {
                
                rotateObj.transform.rotation  =  Quaternion.Euler( rotateObj.transform.rotation.eulerAngles + new Vector3(0,0,speed));
                
            }
            else if(rotateObj.transform.rotation.eulerAngles.z > startAngle)
            {
                
                rotateObj.transform.rotation =  Quaternion.Euler(rotateObj. transform.rotation.eulerAngles - new Vector3(0,0,speed  ));
            }


            if (rotateObj.transform.rotation.eulerAngles.z > targetAngle / 1.5)
            {
                alarmObj.SetActive(true);
            }
        }
        else
        {
            alarmObj.SetActive(false);
            foreach (var obj in finalObj)
            {
                obj.SetActive(true);
            }
        }
        
        pressObj.SetActive(Input.GetMouseButton(0));
        unPressObj.SetActive(!Input.GetMouseButton(0));
        


    }
}
