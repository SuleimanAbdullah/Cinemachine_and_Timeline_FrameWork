using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private int _currentCameraIndex;
    [SerializeField]
    private bool _isCurrentCameraActive;

    [SerializeField]
    private GameObject[] _shipViews;
    [SerializeField]
    private CinemachineVirtualCamera[] _cameras;
    private CinemachineVirtualCamera _currentCamera;

    private Vector3 _temporaryMousePos;

    private float _canPlayCinematicCamera = 10.0f;
    private float _timeRate = 10.0f;
    [SerializeField]
    private PlayableDirector _cameracinematicDirector;
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
        _temporaryMousePos = Input.mousePosition;
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

        if (_temporaryMousePos == Input.mousePosition && Time.time >_canPlayCinematicCamera
        || !Input.anyKeyDown && Time.time > _canPlayCinematicCamera)
        {
            if (_cameracinematicDirector.state == PlayState.Playing)
            {
                _canPlayCinematicCamera = Time.time + _timeRate;
                return;
            }
            else
            {
                _cameracinematicDirector.gameObject.SetActive(true);
                _shipViews[0].SetActive(true);
                _cameracinematicDirector.Play();
                _canPlayCinematicCamera = Time.time + _timeRate;
                Debug.Log("Play Director:");
            }
        }


        if (_temporaryMousePos != Input.mousePosition || Input.anyKeyDown)
        {
            _cameracinematicDirector.gameObject.SetActive(false);
            _temporaryMousePos = Input.mousePosition;
            _canPlayCinematicCamera = Time.time + _timeRate;
        }

        //when player hasnot moved the mouse 
        //or pressed a key within 5 seconds
        //have cinematic camera
    }


    public void SetPriorityDefault()
    {
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
                break;
        }
    }
}
