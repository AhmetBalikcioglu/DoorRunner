using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Swipe
{
    None,
    Up,
    Down,
    Left,
    Right,
};


public class InputManager : Singleton<InputManager>
{
    public Swipe CurrentSwipe = Swipe.None;

    [SerializeField] private float _swipeResist = 70f;
    private float _swipeAngle = 0f;
    private Vector2 _firstTouchPosition;
    private Vector2 _finalTouchPosition;

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

    private void Update()
    {
        SwipeInput();
    }

    private void SwipeInput()
    {
        if (GetMouseInput())
        {
            float touchDiff = Vector2.Distance(_finalTouchPosition, _firstTouchPosition);
            if (touchDiff >= _swipeResist)
            {
                CalculateAngle();
            }
        }
    }

    void CalculateAngle()
    {
        _swipeAngle = Mathf.Atan2(_finalTouchPosition.y - _firstTouchPosition.y, _finalTouchPosition.x - _firstTouchPosition.x) * 180 / Mathf.PI;
        SwipeDir();
    }

    private bool GetMouseInput()
    {
        // Swipe/Click started
        if (Input.GetMouseButtonDown(0))
        {
            CurrentSwipe = Swipe.None;
            _firstTouchPosition = (Vector2)Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _finalTouchPosition = (Vector2)Input.mousePosition;
            return true;
            // Swipe/Click finished
        }

        return false;
    }
    
    private void SwipeDir()
    {
        if (_swipeAngle > -45 && _swipeAngle <= 45)
        {
            //Right Swipe
            CurrentSwipe = Swipe.Right;
            Debug.Log("Sağ");
        }
        else if (_swipeAngle > 45 && _swipeAngle <= 135)
        {
            //Up Swipe
            Debug.Log("Üst");
            CurrentSwipe = Swipe.Up;
        }
        else if (_swipeAngle > 135 || _swipeAngle <= -135)
        {
            //Left Swipe
            Debug.Log("Sol");
            CurrentSwipe = Swipe.Left;
        }
        else if (_swipeAngle <= -45 && _swipeAngle > -135)
        {
            //Down Swipe
            Debug.Log("Aşağı");
            CurrentSwipe = Swipe.Down;
        }
    }
}
