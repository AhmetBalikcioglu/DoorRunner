using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private float _courseLength;

    [Header("Finish Related")]
    [SerializeField] private GameObject _finishLine;
    public GameObject[] _targetPositions;

    public Vector3 finisLinePosition;
    
    //[SerializeField] private float _finishLineYIteration;

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

        finisLinePosition = ObstacleManager.Instance.lastObstaclePosition + Vector3.forward * _finishLine.transform.GetChild(0).localScale.z / 2f;
        Instantiate(_finishLine, finisLinePosition, Quaternion.identity);
        finisLinePosition += Vector3.back * _finishLine.transform.GetChild(0).localScale.z / 3f;
    }
    
    

}
