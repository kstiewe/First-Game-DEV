using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _playerHead;

    private Camera _camera;
    private float _weaponMaxRange = 100f;
    private Vector3 _eyeHeight;
    private Color _debugRayColor;
    private float _rayDurationTime;

    private void Awake()
    {
        _camera = Camera.main;
        _eyeHeight = new Vector3(0, _playerHead.position.y, 0);
    }

    private void Update()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _debugRayColor = Color.red;
            _rayDurationTime = 0.1f;
            Shoot(ray);
        }
        else
        {
            _debugRayColor = Color.green;
            _rayDurationTime = 0.0f;
        }

        DrawDebugRay(ray, _debugRayColor, _rayDurationTime);
    }

    private void Shoot(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(
            origin: ray.origin + _eyeHeight,
            direction: ray.direction,
            hitInfo: out hit,
            maxDistance: _weaponMaxRange))
        {
            print("Object hit. Tag: " + hit.collider.tag + " Layer: " + hit.collider.gameObject.layer);
        }
    }

    private void DrawDebugRay(Ray ray, Color rayColor, float durationTime)
    {
        Debug.DrawRay(
            start: ray.origin + _eyeHeight,
            dir: ray.direction * _weaponMaxRange,
            color: rayColor,
            duration: durationTime);
    }
}
