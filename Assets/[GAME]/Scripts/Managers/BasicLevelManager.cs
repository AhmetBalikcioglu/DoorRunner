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
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (++currentScene > _sceneCount)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene(currentScene);
        }
        
    }
}
