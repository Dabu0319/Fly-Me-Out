using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weigh : StagePress
{
    public GameObject sImage;
    public GameObject mImage;
    public GameObject lImage;

    public GameObject redLight;
    public GameObject finalImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (barValue > 0.33)
        {
            sImage.GetComponent<Text>().color = Color.red;
        }
        if (barValue > 0.66)
        {
            mImage.GetComponent<Text>().color = Color.red;
            redLight.SetActive(true);
            redLight.GetComponent<Animator>().SetTrigger("Start");
        }
        if (barValue > 0.95)
        {
            lImage.GetComponent<Text>().color = Color.red;
            barValue = 1;
            finalImage.SetActive(true);
            GameManager.instance.NextLevelButton();
            
        }
    }
}
