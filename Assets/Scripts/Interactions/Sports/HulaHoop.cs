using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class HulaHoop : MonoBehaviour
{
    public Vector3 oriPos;
    
    public Camera _cam;

    public bool isLeft;
    public bool isMid;
    public bool isRight;

    public int stageNum;

    public GameObject leftImage;
    public GameObject rightImage;
    public GameObject midImage;

    public List<GameObject> stageImages;

    public bool lastLeft;
    public bool lastRight;

    public List<GameObject> activeObj;
    public List<GameObject> inActiveObj;

    public float offset = 4.0f;
    
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        oriPos = GetMousePos();
    }

    private void OnMouseDrag()
    {
        // if (!isLeft && stageNum == 0 && GetMousePos().x - oriPos.x < -5.0f)
        // {
        //     stageNum++;
        //     oriPos = GetMousePos();
        //     isLeft = true;
        //     lastLeft = true;
        //     
        //     LeftImage();
        //     
        //     
        // }
        //
        // if (isLeft && stageNum == 1 && GetMousePos().x - oriPos.x > 5.0f)
        // {
        //     stageNum++;
        //     oriPos = GetMousePos();
        //     isLeft = false;
        //     
        //     MidImage();
        //     
        // }
        //
        // if (!isRight && stageNum == 2 && GetMousePos().x - oriPos.x > 5.0f )
        // {
        //     stageNum++;
        //     oriPos = GetMousePos();
        //     isRight = true;
        //     
        //     RightImage();
        // }
        //
        // if (isRight && stageNum == 3 && GetMousePos().x - oriPos.x < -5.0f)
        // {
        //     stageNum++;
        //     oriPos = GetMousePos();
        //     isRight = false;
        //     
        //     MidImage();
        // }
        //
        // if (!isRight && stageNum == 0 && GetMousePos().x - oriPos.x >5.0f)
        // {
        //     stageNum++;
        //     oriPos = GetMousePos();
        //     isRight = true;
        //     
        //     RightImage();
        //     
        //     
        // }
        //
        // if (isRight && stageNum == 1 && GetMousePos().x - oriPos.x < -5.0f)
        // {
        //     stageNum++;
        //     oriPos = GetMousePos();
        //     isRight = false;
        //     
        //     MidImage();
        //     
        // }
        //
        // if (!isLeft && stageNum == 2 && GetMousePos().x - oriPos.x < -5.0f)
        // {
        //     stageNum++;
        //     oriPos = GetMousePos();
        //     isLeft = true;
        //     
        //     LeftImage();
        // }
        //
        // if (isLeft && stageNum == 3 && GetMousePos().x - oriPos.x > 5.0f)
        // {
        //     stageNum++;
        //     oriPos = GetMousePos();
        //     isLeft = false;
        //     
        //     MidImage();
        // }

        //中向右
        if (isMid && lastLeft && GetMousePos().x - oriPos.x > offset)
        {
            stageNum++;
            oriPos = GetMousePos();
            isRight = true;
            isMid = false;
            lastRight = true;
            lastLeft = false;
        }

        //右向中
        if (isRight && GetMousePos().x - oriPos.x < -offset)
        {
            stageNum++;
            oriPos = GetMousePos();
            isRight = false;
            isMid = true;

        }

        //中向左
        if (isMid && lastRight && GetMousePos().x - oriPos.x < -offset)
        {
            stageNum++;
            oriPos = GetMousePos();
            isLeft = true;
            isMid = false;
            lastLeft = true;
            lastRight = false;
            
        }
        //左向中
        if (isLeft && GetMousePos().x - oriPos.x > offset)
        {
            stageNum++;
            oriPos = GetMousePos();
            isLeft = false;
            isMid = true;

        }

        //第一次向左
        if (isMid && !lastLeft && !lastRight && GetMousePos().x - oriPos.x < -offset)
        {
            stageNum++;
            oriPos = GetMousePos();
            isLeft = true;
            isMid = false;
            lastLeft = true;
        }
        //第一次向右
        if (isMid && !lastLeft && !lastRight && GetMousePos().x - oriPos.x > offset)
        {
            stageNum++;
            oriPos = GetMousePos();
            isRight = true;
            isMid = false;
            lastRight = true;
        }

        if (isLeft)
        {
            LeftImage();
        }

        if (isMid)
        {
            MidImage();
        }

        if (isRight)
        {
            RightImage();
        }
        

        switch (stageNum)
        {
            case 4:
                stageImages[0].SetActive(true);
                break;
            case 8:
                stageImages[1].SetActive(true);
                break;
            case 12:
                stageImages[2].SetActive(true);
                break;
            case 16:
                stageImages[3].SetActive(true);
                break;
        }
    }

    private void OnMouseUp()
    {
        if (stageNum < 16)
        {
            stageNum = 0;
            StageImageReset();
            MidImage();
            isLeft = false;
            isRight = false;
            lastLeft = false;
            lastRight = false;
            isMid = true;
        }
        else
        {
            EventHandler.CallActiveGameObjects(activeObj,0f);
            EventHandler.CallInactiveGameObjects(inActiveObj,0f);
        }
    }


    public virtual Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //var mouseoffset = mousePos - transform.position;
        return mousePos;
    }

    public void LeftImage()
    {
        leftImage.SetActive(true);
        midImage.SetActive(false);
        rightImage.SetActive(false);
    }

    public void MidImage()
    {
        leftImage.SetActive(false);
        midImage.SetActive(true);
        rightImage.SetActive(false);
    }

    public void RightImage()
    {
        leftImage.SetActive(false);
        midImage.SetActive(false);
        rightImage.SetActive(true);
    }

    public void StageImageReset()
    {
        for (int i = 0; i < 4; i++)
        {
            stageImages[i].SetActive(false);
        }
    }
}
