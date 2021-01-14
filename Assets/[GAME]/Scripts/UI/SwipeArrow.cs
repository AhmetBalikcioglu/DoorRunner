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
    ArrowState _currentArrowState = ArrowState.Hide;

    private void Start()
    {
        if (transform.position.x != 0 || !GameManager.Instance.isHelpNeeded)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);
    }

    public void ChangeArrowState(ArrowState arrowState)
    {
        _currentArrowState = arrowState;
        if (_currentArrowState == ArrowState.Hide)
        {
            gameObject.SetActive(false);
        }
        else if (_currentArrowState == ArrowState.Show)
        {
            gameObject.SetActive(true);
        }
        else if (_currentArrowState == ArrowState.Flash)
        {
            StartCoroutine(FlashArrow());
        }
    }

    private IEnumerator FlashArrow()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(UIManager.Instance.arrowFlashTime);
        gameObject.SetActive(false);
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
