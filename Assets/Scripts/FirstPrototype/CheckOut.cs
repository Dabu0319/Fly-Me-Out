using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckOut : MonoBehaviour
{
    public int food01Num;

    public int food02Num;

    public int food03Num=0;

    public int food01RightNum;
    public int food02RightNum;
    public int food03RightNum;

    public Text food01NumText;
    public Text food02NumText;
    public Text food03NumText;

    public GameObject RightButton;
    public GameObject NextLevelButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        food01NumText.text = food01Num.ToString();
        food02NumText.text = food02Num.ToString();
        food03NumText.text = food03Num.ToString();
    }

    public void Food01Add()
    {
        food01Num++;
    }
    
    public void Food02Add()
    {
        food02Num++;
    }
    
    public void Food03Add()
    {
        food03Num++;
    }
    
    public void Food01Abstract()
    {
        if(food01Num>0)
            food01Num--;
    }
    
    public void Food02Abstract()
    {
        if(food02Num>0)
            food02Num--;
    }
    
    public void Food03Abstract()
    {
        if(food03Num>0)
            food03Num--;
    }

    public void CheckOutAccount()
    {
        if (food01Num == food01RightNum && food02Num == food02RightNum && food03Num == food03RightNum)
        {
            RightButton .SetActive(false);
            NextLevelButton.SetActive(true);
        }
    }
    
}
