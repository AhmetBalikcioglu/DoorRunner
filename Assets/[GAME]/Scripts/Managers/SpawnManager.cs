using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private float _courseLength;
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

    private void SpawnCourse()
    {
        for (int i = 0; i < _courseLength; i++)
        {
            ObstacleManager.Instance.SpawnObstacles(i);
        }
    }

}
