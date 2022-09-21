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

    public SoundEffectManager springSoundManager; // 秤的弹簧声
    public SoundEffectManager alarmSoundManager; // 警报声
    public SoundEffectManager celebrateSoundManager; // 庆祝声
    private bool hasPlayedEndSound = false;
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
                if (springSoundManager)  springSoundManager.PlaySoundLoop();
                rotateObj.transform.rotation  =  Quaternion.Euler( rotateObj.transform.rotation.eulerAngles + new Vector3(0,0,speed));
                
            }
            else if(rotateObj.transform.rotation.eulerAngles.z > startAngle)
            {
                if (springSoundManager) springSoundManager.StopSound();
                if (alarmSoundManager) alarmSoundManager.StopSound();
                rotateObj.transform.rotation =  Quaternion.Euler(rotateObj. transform.rotation.eulerAngles - new Vector3(0,0,speed  ));
            }


            if (rotateObj.transform.rotation.eulerAngles.z > targetAngle / 1.5)
            {
                if (alarmSoundManager) alarmSoundManager.PlaySoundLoop();
                alarmObj.SetActive(true);
            }
        }
        else
        {
            if (springSoundManager) springSoundManager.StopSound();
            if (alarmSoundManager) alarmSoundManager.StopSound();
            if (celebrateSoundManager && !hasPlayedEndSound) celebrateSoundManager.PlaySoundOnce();
            hasPlayedEndSound = true;

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
