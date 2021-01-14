using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RejectOutputText : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnSwipeFail.AddListener(AnimateRejectedOutput);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnSwipeFail.RemoveListener(AnimateRejectedOutput);
        
        
    }
    
    private void AnimateRejectedOutput()
    {
        gameObject.GetComponent<Animator>().SetTrigger("WrongOutput");
        gameObject.GetComponent<Animator>().SetTrigger("WrongOutput");
    }

}
