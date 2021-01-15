using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessOutputText : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        

        EventManager.OnSwipeCompleted.AddListener(AnimateSuccessOutput);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        

        EventManager.OnSwipeCompleted.RemoveListener(AnimateSuccessOutput);
        
    }
    

    public void AnimateSuccessOutput()
    {
        gameObject.GetComponent<Animator>().SetTrigger("SuccessOutput");
        gameObject.GetComponent<Animator>().SetTrigger("SuccessOutput");
    }
}
