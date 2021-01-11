using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagAssigner : MonoBehaviour
{ 
    public List<Sprite> FlagImages;
    private int _randomFlagSelector;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnSceneLoad.AddListener(SpawnFlag);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnSceneLoad.RemoveListener(SpawnFlag);
    }

    void SpawnFlag()
    {
        _randomFlagSelector = Random.Range(0, FlagImages.Count);
        GetComponent<Image>().sprite = FlagImages[_randomFlagSelector];
        
    }
}
