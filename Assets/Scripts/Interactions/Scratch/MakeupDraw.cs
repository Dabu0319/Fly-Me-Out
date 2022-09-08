using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Brush
{
    None,Eyeliner, Eyeshadow, Blusher, Lipstick
}
public class MakeupDraw : MonoBehaviour
{
    public Camera m_camera;

    public GameObject lipstick;
    public GameObject eyeshadow;
    public GameObject eyeliner;
    public GameObject blusher;

    public GameObject currentBrush;
    

    private LineRenderer currentLineRenderer;
    
    private Vector2 lastPos;

    private Vector2 mousePos;
    private Camera cam;

    public Brush brushType = Brush.None;

    private void Start()
    {
        m_camera = Camera.main;
    }

    private void Update()
    {
        
        mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (brushType == Brush.Blusher)
        {
            Debug.Log("111");
            mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(currentBrush, mousePos, Quaternion.identity);
        }
        else
        {
            CreateBrush();
        }
        

        
        Debug.Log("222");
    }

    private void OnMouseDrag()
    {
        switch (brushType)
        {
            case Brush.Lipstick:
                
                DrawLine();
                break;
            
            
            case Brush.Eyeliner:
                
                DrawLine();
                break;
            
            
            
            case Brush.Eyeshadow:
                
                DrawLine();
                break;
        }
    }

    private void OnMouseUp()
    {
        currentLineRenderer = null;
    }

    void DrawLine()
    {
        // if (Input.GetKeyDown(KeyCode.Mouse0))
        // {
        //  
        //     CreateBrush();
        // }
        
        // if(Input.GetKey(KeyCode.Mouse0))
        // {
        //     Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        //     if (mousePos != lastPos)
        //     {
        //         AddPoint(mousePos);
        //         lastPos = mousePos;
        //     }
        // }
        
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos != lastPos)
        {
            AddPoint(mousePos);
            lastPos = mousePos;
        }
        // else
        // {
        //     currentLineRenderer = null;
        // }
    }
    
    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(currentBrush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        
        currentLineRenderer.SetPosition(0,mousePos);
        currentLineRenderer.SetPosition(1,mousePos);
    }

    void AddPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex,pointPos);
    }

    public void ChangeBrush(string brushName)
    {
        switch (brushName)
        {
            case "lipstick":
                currentBrush = lipstick;
                brushType = Brush.Lipstick;
                break;
            case "eyeshadow":
                currentBrush = eyeshadow;
                brushType = Brush.Eyeshadow;
                break;
            case "eyeliner":
                currentBrush = eyeliner;
                brushType = Brush.Eyeliner;
                break;
            case "blusher":
                currentBrush = blusher;
                brushType = Brush.Blusher;
                break;
        }
    }
}
