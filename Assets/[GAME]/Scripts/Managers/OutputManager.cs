using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputManager : Singleton<OutputManager>
{
    [SerializeField] private TextMeshProUGUI _rejected, _success;

    private Animator _rejectOutput, _successOutput;

    private void Start()
    {
        //_rejectOutput = _rejected.GetComponent<Animator>();
        //_successOutput = _success.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        //EventManager.OnWrongSwipe.AddListener(AnimateRejectedOutput);
        //EventManager.OnRightSwipe.AddListener(AnimateSuccessOutput);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        //EventManager.OnSwipeFail.RemoveListener(AnimateRejectedOutput);
        //EventManager.OnRightSwipe.RemoveListener(AnimateSuccessOutput);
        
        
    }
    
    private void AnimateSuccessOutput()
    {
        _successOutput.Rebind();
        _successOutput.SetTrigger("SuccessOutput");
    }
    
    private void AnimateRejectedOutput()
    {
        _rejectOutput.Rebind();
        _rejectOutput.SetTrigger("WrongOutput");
    }
}
