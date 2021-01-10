using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ambiance", order = 1)]
public class AmbianceScriptableBase : ScriptableObject
{
    [Header("CameraRelated")]
    public Color cameraColorTop;
    public Color cameraColorBottom;

    [Header("TrackRelated")]
    public Color trackColor1;
    public Color trackColor2;

    [Header("DoorRelated")]
    public Color doorColor;

}
