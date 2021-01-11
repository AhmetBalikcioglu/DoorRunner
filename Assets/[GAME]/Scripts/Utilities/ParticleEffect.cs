using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{

    void Awake()
    {
       gameObject.GetComponent<ParticleSystem>().Stop();
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelSuccess.AddListener(ParticlePlay);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelSuccess.RemoveListener(ParticlePlay);
    }

    private void ParticlePlay()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }
}
