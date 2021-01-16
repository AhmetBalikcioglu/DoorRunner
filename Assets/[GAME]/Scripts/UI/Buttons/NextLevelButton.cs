using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(() => { BasicLevelManager.Instance.NextLevel(); });
    }

    protected override void OnDisable()
    {
        base.OnEnable();
        onClick.RemoveListener(() => { BasicLevelManager.Instance.NextLevel(); });
    }

}
