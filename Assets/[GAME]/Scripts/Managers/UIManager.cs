using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelFinish.AddListener(LevelFinish);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
    }

    private void LevelFinish()
    {
        
    }
}
