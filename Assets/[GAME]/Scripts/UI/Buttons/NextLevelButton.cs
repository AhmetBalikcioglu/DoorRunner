using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelButton : Button
{
    private int _sceneCount;

    private void Awake()
    {
        _sceneCount = SceneManager.sceneCountInBuildSettings;
    }
    
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(NextLevel);
    }

    protected override void OnDisable()
    {
        base.OnEnable();
        onClick.RemoveListener(NextLevel);
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
