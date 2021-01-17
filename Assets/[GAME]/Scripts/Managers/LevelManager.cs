using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public bool isHelpNeededHand;
    public bool isHelpNeededArrow;
    public float AIDelayTime = 1f;

}
