using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : Singleton<ObstacleManager>
{
    [Header("Door Related")]
    [SerializeField] private List<GameObject> _doorPrefabs;
    [SerializeField] private GameObject _doorFrame;
    [SerializeField] private float _doorYIteration;

    [Header("Track Related")]
    [SerializeField] private GameObject _track;
    [SerializeField] private float _trackZIteratation;
    [SerializeField] private float _trackLength;

    [Header("Lane Related")]
    [SerializeField] private List<Transform> _lanes;

    public Vector3 lastObstaclePosition;

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

    public void SpawnObstacles(float iteration)
    {
        int randomDoor = Random.Range(0, _doorPrefabs.Count);
        for (int i = 0; i < _lanes.Count; i++)
        {
            Vector3 doorPosition = _lanes[i].position + Vector3.up * _doorYIteration + Vector3.forward * iteration * _trackLength;
            GameObject currentDoor = Instantiate(_doorPrefabs[randomDoor], doorPosition, Quaternion.identity);
            //currentDoor.transform.position += Vector3.up * _doorYIteration + Vector3.forward * iteration * _trackLength;
            Instantiate(_doorFrame, currentDoor.transform.position + (1.5f * Vector3.down), Quaternion.identity);
            randomDoor = Random.Range(0, _doorPrefabs.Count);
        }
        GameObject currentTrack = Instantiate(_track, _lanes[1].position, Quaternion.identity);
        currentTrack.GetComponent<Renderer>().material = AmbianceManager.Instance.ChangeTrackColor();
        currentTrack.transform.position += Vector3.forward * iteration * _trackLength - Vector3.forward * _trackZIteratation;

        lastObstaclePosition = currentTrack.transform.position + Vector3.forward * _trackLength / 2f;
    }

}
