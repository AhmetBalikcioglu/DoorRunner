using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelStart.AddListener(ShowPanel);
        EventManager.OnLevelFinish.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.RemoveListener(ShowPanel);
        EventManager.OnLevelFinish.RemoveListener(HidePanel);
        
    }
}
