using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _crouchCameraAnimator;
    private Player _player;
    private Vector3 _direction = new Vector3(0, 0, 0);
    private CharacterController _controller;
    private float _yVelocity = 0;
    private Animator _crouchCharControllerAnimator;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _crouchCharControllerAnimator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.Rotate(0, (Input.GetAxis("Mouse X") * _player.rotationSpeed * Time.deltaTime), 0);
        GravityMechanics();
        CrouchingMechanics();
        RunningMechanics();
        JumpingMechanics();
        _controller.Move(_direction * Time.deltaTime);
    }

    void RunningMechanics()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _direction = transform.TransformDirection(_direction);
        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && _controller.isGrounded)
        {
            _player.IncreaseSpeedClamped(_player.GetSpeed() * Time.deltaTime);
        }
        else if (_controller.isGrounded)
        {
            _player.DecreaseSpeedClamped(_player.GetSpeed() * Time.deltaTime);
        }
        _direction *= _player.GetSpeed();
    }
    void JumpingMechanics()
    {

        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            _yVelocity = _player.jumpSpeed;
        }
        _direction.y += _yVelocity;
    }
    void GravityMechanics()
    {
        if (_controller.isGrounded) 
            _yVelocity = Physics.gravity.y * Time.deltaTime;
        else
            _yVelocity += Physics.gravity.y * Time.deltaTime;
    }
    void CrouchingMechanics()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.LeftShift))
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
