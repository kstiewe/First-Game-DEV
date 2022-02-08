using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]private CharacterController _playerCharacterController;
    private float _xRotation = 0f;
    private float _yPosition = 0f;
    private float _playerHeight;

    void Start(){
        _playerHeight = _playerCharacterController.height;
    }

    void Update()
    {
        _xRotation -= Input.GetAxis("Mouse Y") * PlayerMovement._rotationSpeed * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _yPosition = transform.position.y;
        if(Input.GetKey(KeyCode.LeftControl)){
            _yPosition -= 0.01f;
        }
        else{
            _yPosition += 0.01f;
        }
        _yPosition = Mathf.Clamp(_yPosition, 0.6f*_playerHeight, _playerHeight);
        transform.position = new Vector3(transform.position.x,_yPosition, transform.position.z);
    }
}
