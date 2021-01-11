using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class NicknameText : MonoBehaviour
{
    
    private void Start()
    {
        ReadTextAndFillArray();
    }

    static void ReadTextAndFillArray()
    {
        //List<String> _nickNames = new List<String>();
        
        string fileName = "nicknames.txt";
        var sr = new StreamReader(Application.dataPath + "/" + fileName);
        
        var fileContents = sr.ReadToEnd();
        sr.Close();

        var lines = fileContents.Split("\n"[0]);

        foreach (var line in lines)
        {
            //_nickNames.Add(line);
            Debug.Log(line);
        }
    }

}
