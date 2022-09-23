using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DotweenGoupTest : MonoBehaviour
{
    public List<Transform> squares;

    
    void Start()
    {
        Debug.Log(squares.Count);
        
        var sequence = DOTween.Sequence();

        foreach (var square in squares)
        {
            
            
            sequence.Append(square.DOMoveX(3, Random.Range(1f, 2f)));
        }
        
        sequence.OnComplete((() =>
        {
            foreach (var square in squares)
            {
                square.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
            }
        })); 
        
        // squares[0].DOMoveX(1, Random.Range(1f, 2f)).OnComplete(() =>
        // {
        //     squares[1].DOMoveX(1, Random.Range(1f, 2f)).OnComplete(() =>
        //     {
        //         squares[2].DOMoveX(1, Random.Range(1f, 2f)).OnComplete((() =>
        //         {
        //             foreach (var square in squares)
        //             {
        //                 square.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
        //             }
        //             
        //         }));
        //     });
        // });
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
