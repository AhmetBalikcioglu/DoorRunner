using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceManager : Singleton<AmbianceManager>
{
    [Header("AmbianceRelated")]
    [SerializeField] private List<AmbianceScriptableBase> _ambiances;
    public AmbianceScriptableBase chosenAmbiance;

    [Header("MaterialRelated")]
    [SerializeField] private List<Material> _trackMat;
    [SerializeField] private Material _doorMat;
    private bool _trackChange;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
    }

    private void Awake()
    {
        ChangeAmbiance();
    }
    private void ChangeAmbiance()
    {
        int randomAmbiance = Random.Range(0, _ambiances.Count);
        chosenAmbiance = _ambiances[randomAmbiance];
        Camera.main.backgroundColor = chosenAmbiance.cameraColor;
        _doorMat.color = chosenAmbiance.doorColor;
        _trackMat[0].color = chosenAmbiance.trackColor1;
        _trackMat[1].color = chosenAmbiance.trackColor2;
        _trackChange = false;
    }

    public Material ChangeTrackColor()
    {
        _trackChange = !_trackChange;
        if (_trackChange)
            return _trackMat[0];
        else
            return _trackMat[1];

    }
}
