﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameStarted;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSceneLoad.Invoke();
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
    }

    public void StartGame()
    {
        if (isGameStarted)
            return;
        
        EventManager.OnGameStart.Invoke();
        isGameStarted = true;

    }

    public void GameEnd(Character champion)
    {
        foreach (var character in CharacterManager.Instance.Characters)
            character.Won = false;
        champion.Won = true;

        EventManager.OnLevelFinish.Invoke();
        isGameStarted = false;
    }
}
