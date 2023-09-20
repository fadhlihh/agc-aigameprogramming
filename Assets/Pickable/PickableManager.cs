using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PickableManager : MonoBehaviour
{
    [SerializeField]
    private Player _player; 

    private List<Pickable> _pickableList = new List<Pickable>();

    private void Start()
    {
        InitPickableList();
    }

    private void InitPickableList()
    {
        Pickable[] pickableObjects = GameObject.FindObjectsOfType<Pickable>();
        for (int i = 0; i < pickableObjects.Length; i++)
        {
            _pickableList.Add(pickableObjects[i]);
            pickableObjects[i].OnPicked += OnPickablePicked;
        }
    }

    private void OnPickablePicked(Pickable pickable)
    {
        if (pickable.PickableType == PickableType.PowerUp)
        {
            _player?.PickPowerUp();
        }
        _pickableList.Remove(pickable);
        Destroy(pickable.gameObject);
        if (_pickableList.Count <= 0)
        {
            Debug.Log("Win");
        }
    }
}
