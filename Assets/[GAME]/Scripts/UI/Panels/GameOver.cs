using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelFinish.AddListener(ShowPanel);
        EventManager.OnSceneLoad.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.RemoveListener(ShowPanel);
        EventManager.OnSceneLoad.RemoveListener(HidePanel);
    }
}
