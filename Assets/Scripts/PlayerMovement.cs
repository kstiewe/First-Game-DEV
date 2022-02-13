using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _crouchCameraAnimator;
    private float _movementSpeed = 6f;
    private float _jumpSpeed = 8f;
    private Vector3 _direction = new Vector3(0, 0, 0);
    private CharacterController _controller;
    private float _yVelocity = 0;
    private Animator _crouchCharControllerAnimator;

    [HideInInspector]static public float _rotationSpeed = 1000f;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _crouchCharControllerAnimator = GetComponent<Animator>();
    }

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
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

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _crouchCharControllerAnimator.SetBool("isCrouching", true);
            _crouchCameraAnimator.SetBool("isCrouching", true);
        }
        else
        {
            _crouchCharControllerAnimator.SetBool("isCrouching", false);
            _crouchCameraAnimator.SetBool("isCrouching", false);
        }
    }
}
