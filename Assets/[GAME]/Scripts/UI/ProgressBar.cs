using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UIElements;

public class ProgressBar : MonoBehaviour
{
    public List<Transform> playerPositions;
    public List<RectTransform> pins;
    public List<Transform> startPosition;

    private float[] _distanceCalculations;
    private Vector3 _pinStartPosition;
    private List<Vector3> _courseFinishPosition;
    private float _maxDistance;
    


    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        
        EventManager.OnGameStart.AddListener(Initiate);
        
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(Initiate);
    }


    void Initiate()
    {
        _courseFinishPosition = new List<Vector3>();
        _pinStartPosition = pins[0].transform.position;
        _courseFinishPosition.Add(SpawnManager.Instance.finisLinePosition + Vector3.left * 3f);
        _courseFinishPosition.Add(SpawnManager.Instance.finisLinePosition);
        _courseFinishPosition.Add(SpawnManager.Instance.finisLinePosition+ Vector3.right * 3f);
        
        _distanceCalculations = new float[_courseFinishPosition.Count];
        _maxDistance = Vector3.Distance(_courseFinishPosition[1], startPosition[1].position + Vector3.back * 7f);
        Debug.LogFormat("MaxDistance: {0}", _maxDistance);
    }

    private void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
            ProgressPin();
        }
        
    }

    void ProgressPin()
    {
        
        CalculateDistance();

        for (int i = 0; i < pins.Count; i++)
        {
            //pins[i].transform.SetPositionAndRotation(new Vector3(100f * distanceCalculations[i], 0f, 0f),Quaternion.identity );
            pins[i].transform.position = _pinStartPosition + Vector3.right * 100f * _distanceCalculations[i] * 14f;
        }
        
    }

    void CalculateDistance()
    {
        for (int i = 0; i < _distanceCalculations.Length; i++)
        {
            _distanceCalculations[i] = Vector3.Distance(playerPositions[i].position, startPosition[i].position + Vector3.back * 7f) / _maxDistance;
        }
    }
    
    

}
