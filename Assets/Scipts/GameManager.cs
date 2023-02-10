
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _restartCanvas;
    [SerializeField]
    private int _levelIndex;

    [SerializeField]
    private float _slowMotionDelay = 0.2f;

    private void Start()
    {
        _restartCanvas.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_levelIndex);
    }

    IEnumerator SlowMotionRoutine()
    {

        Time.timeScale = _slowMotionDelay;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void ActivateSlowMotion()
    {
        StartCoroutine(SlowMotionRoutine());
    }
}
