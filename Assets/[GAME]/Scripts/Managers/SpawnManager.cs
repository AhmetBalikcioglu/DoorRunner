using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private float _courseLength;

    [Header("Finish Related")]
    [SerializeField] private GameObject _finishLine;
    [SerializeField] private float _finishLineYIteration;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnSceneLoad.AddListener(SpawnCourse);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnSceneLoad.RemoveListener(SpawnCourse);
    }

    private void Start()
    {
        EventManager.OnSceneLoad.Invoke();
    }
    
    private void SpawnCourse()
    {
        for (int i = 0; i < _courseLength; i++)
        {
            ObstacleManager.Instance.SpawnObstacles(i);
        }
        Instantiate(_finishLine, ObstacleManager.Instance.lastObstaclePosition + Vector3.up * _finishLineYIteration, _finishLine.transform.rotation);
    }

}
