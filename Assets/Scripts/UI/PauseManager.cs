using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{   
    [SerializeField] private GameObject _optionsObject;
    [SerializeField] private GameObject _pauseObject;
    private bool _gamePaused = false;
    public void Resume()
    {
        Time.timeScale = 1;
        _pauseObject.SetActive(false);
        _gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Options()
    {
        _pauseObject.SetActive(false);
        _optionsObject.SetActive(true);
    }

    public void OptionsBack()
    { 
        _optionsObject.SetActive(false);
        _pauseObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _gamePaused == false)
        {
            Time.timeScale = 0;
            _pauseObject.SetActive(true);
            _gamePaused = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
