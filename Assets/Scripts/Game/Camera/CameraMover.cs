using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _shopPosition;
    [SerializeField] private Transform _garagePosition;
    private bool isMoving = false;
    private Vector3 destination;
    [SerializeField] private float camSpeed = 3f;
    private Vector3 velocity = Vector3.zero;

    public void Start()
    {
        velocity.z = -10;
    }

    public void MoveToShop()
    {
        isMoving = true;
        destination = _shopPosition.position;
    }

    public void MoveToGarage()
    {
        isMoving = true;
        destination = _garagePosition.position;
    }

    private void FixedUpdate()
    {




        if (isMoving)
        {
            //_camera.transform.position = Vector3.MoveTowards(transform.position, destination, camSpeed * Time.deltaTime);
            _camera.transform.position = Vector3.SmoothDamp(_camera.transform.position, destination, ref velocity, camSpeed);
            if (Vector3.Distance(_camera.transform.position, destination) <= 0.01f)
            {
                _camera.transform.position = destination;
                isMoving = false;
            }
        }
    }




    /*
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
    */
}
