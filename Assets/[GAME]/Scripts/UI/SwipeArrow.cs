using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ArrowState
{
    Hide,
    Show,
    Flash,
};

public class SwipeArrow : MonoBehaviour
{
    public ArrowState _currentArrowState = ArrowState.Hide;
    public MoveableDoor currentDoor;

    private MeshRenderer _arrowMesh;
    private void Start()
    {
        _arrowMesh = GetComponent<MeshRenderer>();
        _arrowMesh.enabled = false;
        
        if (transform.position.x <= 0.5f && transform.position.x >= -0.5f)
        {
            if (LevelManager.Instance.isHelpNeededArrow)
            {
                _currentArrowState = ArrowState.Show;
                ArrowStateChecker();
            }
            else
            {
                _currentArrowState = ArrowState.Flash;
            }
        }
    }
    public void ArrowStateChecker()
    {
        if (_currentArrowState == ArrowState.Hide)
        {
            _arrowMesh.enabled = false;
        }
        else if (_currentArrowState == ArrowState.Show)
        {
            _arrowMesh.enabled = true;
        }
        else if (_currentArrowState == ArrowState.Flash)
        {
            StartCoroutine(FlashArrow());
        }
    }

    private IEnumerator FlashArrow()
    {
        _arrowMesh.enabled = true;
        yield return new WaitForSeconds(UIManager.Instance.arrowFlashTime);
        _arrowMesh.enabled = false;
        yield return new WaitForSeconds(UIManager.Instance.arrowFlashTime * 2f);
        if (!currentDoor.doorOpened)
            ArrowStateChecker();
    }

    public void TurnArrow(DoorDir doorDirection)
    {
        if (doorDirection == DoorDir.Down)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 270f);
        }
        else if (doorDirection == DoorDir.Left)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 180f);
        }
        else if (doorDirection == DoorDir.Up)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 90f);
        }
    }
}
