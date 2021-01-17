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

    private void Start()
    {
        gameObject.SetActive(false);
        
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
            gameObject.SetActive(false);
        }
        else if (_currentArrowState == ArrowState.Show)
        {
            gameObject.SetActive(true);
        }
        else if (_currentArrowState == ArrowState.Flash)
        {
            gameObject.SetActive(true);
            StartCoroutine(FlashArrow());
            
        }
    }

    private IEnumerator FlashArrow()
    {
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
