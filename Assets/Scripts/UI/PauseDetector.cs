using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDetector : MonoBehaviour
{
    [SerializeField] private GameObject _pauseObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _pauseObject.SetActive(true);
        }
    }
}
