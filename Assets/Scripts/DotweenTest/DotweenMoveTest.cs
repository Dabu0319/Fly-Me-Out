using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DotweenMoveTest : MonoBehaviour
{
    public float moveDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector2(0, 8), moveDuration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        transform.DORotate(new Vector3(0,0,360), moveDuration * 0.5f,RotateMode.FastBeyond360).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
