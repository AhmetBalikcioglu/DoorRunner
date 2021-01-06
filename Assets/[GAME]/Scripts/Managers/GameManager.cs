using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameStarted;

    public void StartGame()
    {
        if (isGameStarted)
            return;

        isGameStarted = true;
        
        EventManager.OnGameStart.Invoke();

    }

}
