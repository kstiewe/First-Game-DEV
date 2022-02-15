using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Player _player;
    private float _xRotation = 0f;

    void Awake()
    {
        _player = GetComponentInParent<Player>();
    }

    void Update()
    {
        _xRotation -= Input.GetAxis("Mouse Y") * _player.rotationSpeed * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
