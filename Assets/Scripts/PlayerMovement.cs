using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _movementSpeed = 6f;
    private float _jumpSpeed = 8f;
    private Vector3 _direction = new Vector3(0, 0, 0);
    private CharacterController _controller;
    private float _yVelocity = 0;
 
    [HideInInspector]static public float _rotationSpeed = 1000f;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        _controller = GetComponent<CharacterController>();
    }

    void Update(){
        if (_controller.isGrounded) _yVelocity = Physics.gravity.y * Time.deltaTime;
        else
        {
            _yVelocity += Physics.gravity.y * Time.deltaTime;
        }
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _direction = transform.TransformDirection(_direction);
        _direction *= _movementSpeed;
        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            _yVelocity = _jumpSpeed;
        }
        _direction.y += _yVelocity;
        _controller.Move(_direction * Time.deltaTime);
        transform.Rotate(0, (Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime), 0);
    }
}
