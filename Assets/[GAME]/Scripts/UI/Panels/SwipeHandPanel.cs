using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeHandPanel : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnSwipeNeeded.AddListener(ShowArrowPanel);
        EventManager.OnSwipeCompleted.AddListener(() => { HidePanel(); Reset(); });
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSwipeNeeded.RemoveListener(ShowArrowPanel); 
        EventManager.OnSwipeCompleted.RemoveListener(() => { HidePanel(); Reset(); });
    }

    private void ShowArrowPanel(DoorDir doorDirection)
    {
        if (doorDirection == DoorDir.Down)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -90f);
        }
        else if (doorDirection == DoorDir.Left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (doorDirection == DoorDir.Up)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 90f);
        }
        else if (doorDirection == DoorDir.Right)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        ShowPanel();
    }

    private void Reset()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
