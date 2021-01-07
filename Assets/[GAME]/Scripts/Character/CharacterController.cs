using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isRunning;
    public bool IsRunning { get { return _isRunning; } set { _isRunning = value; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelStart.AddListener(() => IsRunning = true);
        EventManager.OnLevelFinish.AddListener(() => IsRunning = false);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(() => IsRunning = true);
        EventManager.OnLevelFinish.RemoveListener(() => IsRunning = false);
    }

    private void Update()
    {
        if (!IsRunning)
            return;
        Run();
    }

    public void Run()
    {
        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
    }

    public void Stay()
    {
        IsRunning = false;
    }
    
    
}
