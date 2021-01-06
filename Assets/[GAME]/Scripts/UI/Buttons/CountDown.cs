using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Text _counter;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.AddListener(DownCounter);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.RemoveListener(DownCounter);
    }
    
    void DownCounter()
    {
        StartCoroutine(SetCountDown());
    }

    private IEnumerator SetCountDown()
    {
        _counter.text = "GET READY";
        yield return new WaitForSeconds(1f);

        _counter.text = "SET";
        yield return new WaitForSeconds(1f);
        
        _counter.text = "GO";
        yield return new WaitForSeconds(1f);

        _counter.text = "";
    }
}
