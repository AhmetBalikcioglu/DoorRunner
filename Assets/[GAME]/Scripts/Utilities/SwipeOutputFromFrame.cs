using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class SwipeOutputFromFrame : MonoBehaviour
{
    //public Material FrameMaterialTrue;
   // public Material FrameMaterialFalse;
    Material FrameMaterial;

    private void Awake()
    {
        FrameMaterial = GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        //EventManager.OnWrongSwipe.AddListener(Fra);
    }
    
    public IEnumerator FrameMaterialChangerFalse() 
    {
        FrameMaterial.SetColor("_Color", Color.red * 2);
        yield return new WaitForSeconds(0.5f);
        FrameMaterial.color = Color.white;
    }
    
    public IEnumerator FrameMaterialChangerTrue()
    {
        FrameMaterial.SetColor("_Color", Color.green * 2);
        yield return new WaitForSeconds(0.5f);
        FrameMaterial.color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Character>().CharacterControllerType != CharacterControllerType.Player)
            return;
        
        EventManager.OnWrongSwipe.AddListener(CoroutineStarterForFalse);
        EventManager.OnRightSwipe.AddListener(CoroutineStarterForRight);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Character>().CharacterControllerType != CharacterControllerType.Player)
            return;

        EventManager.OnWrongSwipe.RemoveListener(CoroutineStarterForFalse);
        EventManager.OnRightSwipe.RemoveListener(CoroutineStarterForRight);
    }

    void CoroutineStarterForRight()
    {
        StopAllCoroutines();
        StartCoroutine(FrameMaterialChangerTrue());
    }

    void CoroutineStarterForFalse()
    {
        StopAllCoroutines();
        StartCoroutine(FrameMaterialChangerFalse());
    }
}
