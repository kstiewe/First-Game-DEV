using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private GameObject _playerObject;
    private float _rangeView = 30.0f;
    private RaycastHit _hit;
    private Vector3 _RaycastDirection;
    private Ray _PlayerEnemyRay;
    protected override void DoAwake() { }

    private void FixedUpdate()
    {
        _RaycastDirection = _playerObject.transform.position - transform.position;
        _PlayerEnemyRay = new Ray(transform.position, _RaycastDirection);

        if (Physics.Raycast(_PlayerEnemyRay, out _hit, _rangeView))
        { 
            if(_hit.collider.tag == "Player")
            {
                Debug.Log("Enemy sees Player");
            }
        }
    }
}
