using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class SaveSystem
{

    public static readonly string SaveFolder = Application.persistentDataPath + "/Saves/";

    public static void FileCheck()
    {
        if (!Directory.Exists(SaveFolder))
            Directory.CreateDirectory(SaveFolder);
    }
    public static void SaveLevel(int sceneNum)
    {



        Level level = new Level();
        level.levelNum = sceneNum;
        
        string json = JsonUtility.ToJson(level);
        // PlayerPrefs.SetString("GameLevel",json);
        // PlayerPrefs.Save();
        File.WriteAllText(SaveFolder + "/save.txt",json);
        
    }

    public static string LoadLevel()
    {
        if (File.Exists(SaveFolder + "/save.txt"))
        {
            string json = File.ReadAllText(SaveFolder + "/save.txt");
            Level level = JsonUtility.FromJson<Level>(json);

            return level.levelNum.ToString();
            
        }
        else
        {
            return null;
        }

    }
    
    public  class Level
    {
        public int levelNum;
    }
}
