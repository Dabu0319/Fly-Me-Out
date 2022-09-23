using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneNum;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToChapter()
    {
        SceneManager.LoadScene(sceneNum);
        //AudioController.instance.DestroyAudio();
        
    }
    
}
