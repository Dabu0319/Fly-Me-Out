using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Draw02 : MonoBehaviour
{
    private Camera cam;

    private LineRenderer m_LineRenderer;
    
    public GameObject linePrefab;
    private GameObject currentLine;

    public const float RESOLUTION = 0.1f;
    
    void Start()
    {
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            currentLine = Instantiate(linePrefab, mousePos, quaternion.identity);

    }

    public void SetPosition(Vector2 pos)
    {
        if(!CanAppend(pos)) return;

        m_LineRenderer.positionCount++;
        m_LineRenderer.SetPosition(m_LineRenderer.positionCount-1,pos);
    }

    private bool CanAppend(Vector2 pos)
    {
        if (m_LineRenderer.positionCount == 0)
            return true;

        return Vector2.Distance(m_LineRenderer.GetPosition(m_LineRenderer.positionCount - 1), pos) > RESOLUTION;
    }
    
}
