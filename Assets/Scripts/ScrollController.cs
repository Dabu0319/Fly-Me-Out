using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public GameObject scrollView;

    public GameObject image1;
    public float posX1;
        
    public GameObject image2;
    
    public GameObject image3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (scrollView.GetComponent<RectTransform>().anchoredPosition.y > -622f &&  image1.GetComponent<RectTransform>().anchoredPosition.x <= 20)
        {
            posX1 = scrollView.GetComponent<RectTransform>().anchoredPosition.y  ;
            image1.GetComponent<RectTransform>().anchoredPosition = new Vector3(
                posX1,
                image1.GetComponent<RectTransform>().anchoredPosition.y);
        }

        if (scrollView.GetComponent<RectTransform>().anchoredPosition.y > 0f &&
            image2.GetComponent<RectTransform>().anchoredPosition.x >= -20)
        {
            image2.GetComponent<RectTransform>().anchoredPosition = new Vector3(
                622- scrollView.GetComponent<RectTransform>().anchoredPosition.y,
                image2.GetComponent<RectTransform>().anchoredPosition.y);
        }
        
        if (scrollView.GetComponent<RectTransform>().anchoredPosition.y > 622f &&
            image3.GetComponent<RectTransform>().anchoredPosition.x <= 20)
        {
            image3.GetComponent<RectTransform>().anchoredPosition = new Vector3(
                -1260+ scrollView.GetComponent<RectTransform>().anchoredPosition.y,
                image3.GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
}
