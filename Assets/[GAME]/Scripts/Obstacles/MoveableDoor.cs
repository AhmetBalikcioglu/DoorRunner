using System;
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
    public float duration;
    private DoorDir _doorDir;
    private bool _doorOpened;

    private void OnEnable()
    {
        InitiateDoorPivot();
        _doorOpened = false;

    }
   
    public void Move(UserInput userInput, bool isPlayer)
    {
        if (_doorOpened)
            return;
        if (userInput.ToString() == _doorDir.ToString())
        {
            if (isPlayer)
                AudioManager.Instance.Play("CorrectSwipe");
            _doorOpened = true;
            if (_doorDir == DoorDir.Down || _doorDir == DoorDir.Up)
            {
                transform.parent.DOScaleY(0f, duration).OnComplete(() => Destroy(transform.parent.gameObject));
            }
            else if (_doorDir == DoorDir.Left || _doorDir == DoorDir.Right)
            {
                transform.parent.DOScaleX(0f, duration).OnComplete(() => Destroy(transform.parent.gameObject));
            }
        }
        else if(isPlayer)
            AudioManager.Instance.Play("WrongSwipe");


        //Debug.LogFormat("UserInput: {0}, DoorDir: {1}", userInput.ToString(), _doorDir.ToString());
    }

    public override IEnumerator AIInputSelection(AIController AIController)
    {
        while (!_doorOpened)
        {
            yield return new WaitForSeconds(AIController.AIInputTimeDelay);
            UserInput AIInput = AIController.RandomAIInput();
            Move(AIInput, false);
            //Debug.LogFormat("AIInput: {0}, DoorDir: {1}", AIInput.ToString(), _doorDir.ToString());
        }
        AIController.usedInput.Clear();
    }

    public override void PlayerInputSelection()
    {
        EventManager.OnSwipeDetected.AddListener(Move);
    }

    private void InitiateDoorPivot()
    {
        _doorDir = (DoorDir)UnityEngine.Random.Range(0, Enum.GetNames(typeof(DoorDir)).Length);
        Transform doorPivot = transform.GetChild(0);
        transform.DetachChildren();
        doorPivot.position = PivotVector3();
        transform.SetParent(doorPivot);
    }

    private Vector3 PivotVector3()
    {
        Vector3 tempVec3 = Vector3.zero;
        switch (_doorDir)
        {
            case DoorDir.Up:
                tempVec3 = transform.position + 3f * Vector3.up;
                break;
            case DoorDir.Down:
                tempVec3 = transform.position;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Character>() == null)
            return;

        EventManager.OnSwipeDetected.RemoveListener(Move);
        if(GameManager.Instance.isGameStarted)
            other.GetComponent<CharacterController>().IsRunning = true;
    }

}