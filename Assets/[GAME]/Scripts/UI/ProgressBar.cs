using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UIElements;

public class ProgressBar : MonoBehaviour
{
    private float[] distanceCalculations;
    private Vector3 _pinStartPosition;
    public List<RectTransform> pins;
    public List<Transform> startPosition;
    private List<Vector3> finishPosition;
    public List<Transform> playerPositions;
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
        finishPosition = new List<Vector3>();
        _pinStartPosition = pins[0].transform.position;
        finishPosition.Add(SpawnManager.Instance.finisLinePosition + Vector3.left * 3f);
        finishPosition.Add(SpawnManager.Instance.finisLinePosition);
        finishPosition.Add(SpawnManager.Instance.finisLinePosition+ Vector3.right * 3f);
        
        distanceCalculations = new float[finishPosition.Count];
        _maxDistance = Vector3.Distance(finishPosition[1], startPosition[1].position + Vector3.back * 7f);
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
            pins[i].transform.position = _pinStartPosition + Vector3.right * 1000f * distanceCalculations[i];
        }
        
    }

    void CalculateDistance()
    {
        for (int i = 0; i < distanceCalculations.Length; i++)
        {
            distanceCalculations[i] = Vector3.Distance(playerPositions[i].position, startPosition[i].position + Vector3.back * 7f) / _maxDistance;
        }
    }
    
    

}
