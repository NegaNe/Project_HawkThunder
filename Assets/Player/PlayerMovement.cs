using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 dragStartPosition;

    private float _charaStartPosition;

    private bool _isDragging = false;

    public GameObject _leftBoundary;
    public GameObject _rightBoundary;


    private Vector3 _lastInputPosition;

    void Update()
    {
        HandleInput();
        AndroidHandleInput();
    }

    //AndroidHandleInput
    void AndroidHandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _isDragging = true;

                    dragStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                    dragStartPosition.z = 0; // memastikan hanya X dan Y yang berjalan 
                    _charaStartPosition = transform.position.x; // memasukkan letak posisi karakter
                    break;

                case TouchPhase.Moved:
                    if (_isDragging)
                    {
                        MovePlayer(touch);
                    }
                    break;

                case TouchPhase.Ended:
                    _isDragging = false;
                    Vector3 touchEndPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                    touchEndPositionWorld.z = 0;

                    break;
            }
        }

        void MovePlayer(Touch touch)
        {
            Vector3 currentPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
            currentPositionWorld.z = 0;
            Vector3 _deltaPostion = currentPositionWorld - _lastInputPosition;

            float _newPositionX = currentPositionWorld.x - dragStartPosition.x + _charaStartPosition;

            float _minX = _leftBoundary.transform.position.x;
            float _maxX = _rightBoundary.transform.position.x;

            float _clamped = Mathf.Clamp(_newPositionX, _minX, _maxX);
            transform.position = new Vector3(_clamped, transform.position.y, transform.position.z);

            _lastInputPosition = currentPositionWorld;
        }
    }


    //mouseType
    void HandleInput()
    {
        Vector3 currentInputPosition = Input.mousePosition;
        float cameraZDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            dragStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(currentInputPosition.x, currentInputPosition.y, cameraZDistance));
            dragStartPosition.z = 0;
            _charaStartPosition = transform.position.x;
        }

        if (_isDragging && Input.GetMouseButton(0))
        {
            MovePlayer(currentInputPosition, cameraZDistance);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            Vector3 currentUpPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(currentInputPosition.x, currentInputPosition.y, cameraZDistance));
            currentUpPositionWorld.z = 0;

        }
    }
    void MovePlayer(Vector3 currentInputPosition, float cameraZDistance)
    {
        Vector3 currentPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(currentInputPosition.x, currentInputPosition.y, cameraZDistance));
        Vector3 _deltaPostion = currentPositionWorld - _lastInputPosition;
        currentPositionWorld.z = 0;

        float _newPositionX = currentPositionWorld.x - dragStartPosition.x + _charaStartPosition;

        float _minX = _leftBoundary.transform.position.x;
        float _maxX = _rightBoundary.transform.position.x;

        float _clamped = Mathf.Clamp(_newPositionX, _minX, _maxX);
        transform.position = new Vector3(_clamped, transform.position.y, transform.position.z);

        _lastInputPosition = currentPositionWorld;
    }
}
