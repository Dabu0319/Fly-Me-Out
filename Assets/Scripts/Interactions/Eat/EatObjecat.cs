using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EatObjecat : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isShaking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!isShaking)
        {
            Shake();
        }
    }


    public void Shake()
    {
        MultipleEatManager.instance.eatCount++;
        isShaking = true;
        const float duration = 3f;
        const float strength = 0.5f;

        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength).onComplete += () => MultipleEatManager.instance.eatCount--;
        transform.DOShakeScale(duration, strength).onComplete = () => isShaking = false;

    }
}
