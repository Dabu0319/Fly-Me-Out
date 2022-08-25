using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPress : MonoBehaviour
{
    public GameObject pressImage;
    public GameObject releaseImage;

    public float pressImageTime = 3;
    public bool isPressImage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {

        if (Input.GetMouseButtonDown(0) && !isPressImage)
        {
            StartCoroutine(StartImage(pressImageTime));
        }
        
        
    }

    public IEnumerator StartImage(float time)
    {
        isPressImage = true;
        releaseImage.SetActive(false);
        pressImage.SetActive(true);

        yield return new WaitForSeconds(time);
        
        isPressImage = false;
        releaseImage.SetActive(true);
        pressImage.SetActive(false);
        
    }
}
