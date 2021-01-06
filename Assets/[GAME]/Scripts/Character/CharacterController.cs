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

    }
    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(() => IsRunning = true);
    }

    private void Update()
    {
        if (!IsRunning)
            return;
        Run();
    }

    public void Run()
    {
        if (!GameManager.Instance.isGameStarted)
            return;
        
        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
    }

    public void Stay()
    {
        IsRunning = false;
    }
    
    
}
