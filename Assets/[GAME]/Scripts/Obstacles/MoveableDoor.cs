﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum DoorDir
{
    Up,
    Down,
    Left,
    Right,
};

public class MoveableDoor : DoorBase, IMoveable
{
    private DoorDir _doorDir;

    private void OnEnable()
    {
        _doorDir = (DoorDir)UnityEngine.Random.Range(0, Enum.GetNames(typeof(DoorDir)).Length);
        Transform doorPivot = transform.GetChild(0);
        transform.DetachChildren();
        doorPivot.position = PivotVector3();
        transform.SetParent(doorPivot);
    }

    public void Move(UserInput userInput)
    {
        if (userInput.ToString() == _doorDir.ToString())
        {
            if (_doorDir == DoorDir.Down || _doorDir == DoorDir.Up)
            {
                transform.parent.DOScaleY(0f, 2f);
            }
            else if (_doorDir == DoorDir.Left || _doorDir == DoorDir.Right)
            {
                transform.parent.DOScaleX(0f, 2f);
            }
        }
        //Debug.LogFormat("UserInput: {0}, DoorDir: {1}", userInput.ToString(), _doorDir.ToString());

    }

    protected override void Animation()
    {
        throw new System.NotImplementedException();
    }

    public override void InputSelection()
    {
        EventManager.OnSwipeDetected.AddListener(Move);
    }

    private Vector3 PivotVector3()
    {
        Vector3 tempVec3 = Vector3.zero;
        switch (_doorDir)
        {
            case DoorDir.Up:
                tempVec3 = transform.position + Vector3.up;
                break;
            case DoorDir.Down:
                tempVec3 = transform.position + Vector3.down;
                break;
            case DoorDir.Left:
                tempVec3 = transform.position + Vector3.left;
                break;
            case DoorDir.Right:
                tempVec3 = transform.position + Vector3.right;
                break;
            default:
                break;
        }
        return tempVec3;
    }
}