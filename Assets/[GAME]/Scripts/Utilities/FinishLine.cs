using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.isGameStarted)
            return;

        Character champion = other.GetComponent<Character>();
        if (champion != null)
            GameManager.Instance.GameEnd(champion);
    }
}
