using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera[] _cameras;
    [SerializeField]
    private int _currentCameraIndex;
    [SerializeField]
    private bool _isCurrentCameraActive;

    [SerializeField]
    private GameObject[] _shipViews;

    private CinemachineVirtualCamera _currentCamera;
    private void Awake()
    {
        foreach (var _VirtualCamera in _cameras)
        {
            _currentCamera = _VirtualCamera.GetComponent<CinemachineVirtualCamera>();

        }
    }

    void Start()
    {

        _currentCameraIndex = 0;
       
        SetPriorityDefault();
        SetCurrentCamera();
        _isCurrentCameraActive = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isCurrentCameraActive == true)
        {
            _shipViews[_currentCameraIndex].SetActive(false);
            _currentCameraIndex++;
            SetPriorityDefault();

            if (_currentCameraIndex >= _cameras.Length)
            {
                _currentCameraIndex = 0;
            }

            SetCurrentCamera();
        }
    }


    public void SetPriorityDefault()
    {
        Debug.Log("What is the problem");
            _currentCamera.Priority = 10;
            _currentCamera.Priority = 10;
        _isCurrentCameraActive = false;
    }

    public void SetCurrentCamera()
    {
        switch (_currentCameraIndex)
        {
            case 0:
                _shipViews[_currentCameraIndex].SetActive(true);
                _cameras[_currentCameraIndex].Priority = 15;
                _isCurrentCameraActive = true;
                break;
            case 1:
                _shipViews[_currentCameraIndex].SetActive(true);
                _cameras[_currentCameraIndex].Priority = 15;
                _isCurrentCameraActive = true;
                Debug.Log("Third Person Camera");
                break;
        }
    }
}
