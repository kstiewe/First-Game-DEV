using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _movementSpeed = 5f;
    [HideInInspector]static public float _rotationSpeed = 1000f;
    private Vector3 _direction = new Vector3(0, 0, 0);

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){
        if(Input.GetKey("w")){
            _direction += transform.forward;
        }
        if(Input.GetKey("s")){
            _direction += -transform.forward;
        }
        if(Input.GetKey("a")){
            _direction += -transform.right;
        }
        if(Input.GetKey("d")){
            _direction += transform.right;
        }
        transform.Rotate(0, (Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime), 0);
        transform.position += _direction * Time.deltaTime * _movementSpeed;
        _direction = new Vector3(0, 0, 0);
    }
}
