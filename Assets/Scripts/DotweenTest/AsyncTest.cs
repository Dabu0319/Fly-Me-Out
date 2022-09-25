using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class AsyncTest : MonoBehaviour
{
    public Transform[] squares;
    void Start()
    {
        BeginTest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator MoveSquares()
    {
        // foreach (Transform square in squares)
        // {
        //     square.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
        //     yield return new WaitForSeconds(1);
        // }

        for (int i = 0; i < squares.Length; i++)
        {
            squares[i].DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
            yield return new WaitForSeconds(1+i);
        }
    }

    public async void BeginTest()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            await RotateForSeconds(squares[i],i + 1);
        }
        
    }
    
    public async Task RotateForSeconds( Transform square, float duration)
    {
        var end = Time.time + duration;

        while (Time.time < end)
        {
            square.Rotate(0, 0, 1 *150 * Time.deltaTime);
            await Task.Yield();
        }

    }
    
    
}
