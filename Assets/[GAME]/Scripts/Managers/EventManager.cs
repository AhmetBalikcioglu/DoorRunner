using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();
    public static UnityEvent OnSceneLoad = new UnityEvent();


    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelContine = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();

    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();

    public static InputEvent OnSwipeDetected = new InputEvent();
    public static UnityEvent OnTapDetected = new UnityEvent();
    public static UnityEvent OnSwipeFail = new UnityEvent();

    public static UnityEvent OnObstacleCreated = new UnityEvent();

    public static UnityEvent OnPlayerStartedRunning = new UnityEvent();

    public static UnityEvent OnSwipeNeeded = new UnityEvent();

}

public class InputEvent : UnityEvent<UserInput> { }