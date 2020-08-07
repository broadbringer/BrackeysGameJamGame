using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _shopPosition;
    [SerializeField] private Transform _garagePosition;
    
    
    public void MoveToShop()
    {
        _camera.transform.position = _shopPosition.position;
    }

    public void MoveToGarage()
    {
        _camera.transform.position = _garagePosition.position;
    }
}
