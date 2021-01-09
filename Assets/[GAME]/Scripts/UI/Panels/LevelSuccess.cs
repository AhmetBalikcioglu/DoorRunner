using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSuccess : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelSuccess.AddListener(ShowPanel);
        EventManager.OnSceneLoad.AddListener(HidePanel);
        
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelSuccess.RemoveListener(ShowPanel);
        EventManager.OnSceneLoad.RemoveListener(HidePanel);
    }
}
