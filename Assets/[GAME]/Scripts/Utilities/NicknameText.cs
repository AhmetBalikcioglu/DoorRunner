using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class NicknameText : MonoBehaviour
{
    //[SerializeField] private TextMeshPro _nickText;
    private int _randomTextSelector;
    List<String> _nickNames = new List<String>();
    
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnSceneLoad.AddListener(AssignToPlayer);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnSceneLoad.RemoveListener(AssignToPlayer);
    }

    private void Awake()
    {
        ReadText();
    }

    public void AssignToPlayer()
    {
        _randomTextSelector = UnityEngine.Random.Range(0, ReadText().Count - 1);
        List<String> _nicks = ReadText();
        GetComponent<TextMeshProUGUI>().text = _nicks[_randomTextSelector];
    }
    public List<String> ReadText()
    {
        
        
        string fileName = "nicknames.txt";
        var sr = new StreamReader(Application.dataPath + "/" + fileName);
        
        var fileContents = sr.ReadToEnd();
        sr.Close();

        var lines = fileContents.Split("\n"[0]);

        foreach (var line in lines)
        {
            _nickNames.Add(line);
            //Debug.Log(line);
        }

        return _nickNames;
    }

}
