using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelSuccess.AddListener(CameraAction);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelSuccess.RemoveListener(CameraAction);
    }
    private void CameraAction()
    {
        Camera.main.transform.DOMove(new Vector3(transform.position.x +3f,transform.position.y - 2f,transform.position.z + 10f), 1.5f);
        Camera.main.transform.DORotate(new Vector3(transform.rotation.x + 15f,-135f,transform.rotation.z), 2f);
    }
}
