using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandControl : MonoBehaviour
{
    public List<GameObject> hands;
    private Camera _cam;
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetMousePos());
        this.transform.position = GetMousePos();
        //f(mous)

        if (GetMousePos().y < -3)
        {
            InactiveAll();
            hands[0].SetActive(true);
        }
        if (GetMousePos().y > -3 && GetMousePos().y < 0)
        {
            InactiveAll();
            hands[1].SetActive(true);
        }
        if (GetMousePos().y > 0 && GetMousePos().y < 3)
        {
            InactiveAll();
            hands[2].SetActive(true);
        }
        if (GetMousePos().y > 3 && GetMousePos().y < 6)
        {
            InactiveAll();
            hands[3].SetActive(true);
        }
        if (GetMousePos().y > 6 && GetMousePos().y < 9)
        {
            InactiveAll();
            hands[4].SetActive(true);
        }
        
    }


    public void InactiveAll()
    {
        foreach (var item in hands)
        {
            item.SetActive(false);
        }
    }
    
    public virtual Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}

