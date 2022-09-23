using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : JigsawManager
{
    public List<GameObject> texts;
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if ( currentNum <= 8 && currentNum >=1)
        {
            texts[currentNum-1].SetActive(true);
        }
    }
}
