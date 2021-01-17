using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BasicLevelManager : Singleton<BasicLevelManager>
{
    private int _sceneCount;

    private void Awake()
    {
        _sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    public void NextLevel()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneBuildIndex == _sceneCount-1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneBuildIndex+1);
        }
        
    }
}
