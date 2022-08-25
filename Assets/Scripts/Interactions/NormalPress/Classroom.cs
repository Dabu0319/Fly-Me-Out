using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Classroom : NormalPress
{
    public int successNum;
    
    public GameObject normalTeacher;
    public GameObject backTeacher;
    public bool isTeacherBack;

    public GameObject redAlert;

    public GameObject succeedImage;

    public List<GameObject> stageObj;

    public int checkNum=3;
    public GameObject bar;
    void Start()
    {
     
        InvokeRepeating("StartTeacherBack",0,10);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (isTeacherBack && !isPressImage)
        {
            GameManager.instance.Restart();
        }
        if (successNum == checkNum)
        {
            succeedImage.SetActive(true);
            StopAllCoroutines();
        }
    }

    public void StartTeacherBack()
    {
        StartCoroutine(TeacherBack());
    }
    
    public IEnumerator TeacherBack()
    {
        float randomTime = Random.Range(3, 6);
        Debug.Log(randomTime);
        yield return new WaitForSeconds(randomTime);
        
        
        redAlert.SetActive(true);
        yield return new WaitForSeconds(2);
        
        normalTeacher.SetActive(false);
        backTeacher.SetActive(true);
        isTeacherBack = true;
        
        redAlert.SetActive(false);


        yield return new WaitForSeconds(2);
        
        normalTeacher.SetActive(true);
        backTeacher.SetActive(false);
        isTeacherBack = false;



        //bar.GetComponent<Slider>().value += 0.333f;
        stageObj[successNum].SetActive(true);
        successNum++;
        
    }
    
    
    
}
