using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private float _health;
    private float _baseModelHeight;
    private float _speed;

    public float baseHealth;
    public float baseSpeed;
    public float jumpSpeed;
    public float rotationSpeed;

    public void Awake()
    {
        _health = baseHealth;
        _speed = baseSpeed;
        DoAwake();
    }

    protected abstract void DoAwake();

    public void HitCharacter(float amount)
    {
        _health -= amount;
    }

    public void HealCharacter(float amount)
    {
        _health += amount;
    }

    public float GetHealth()
    {
        return _health;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public void IncreaseSpeedClamped(float amount)
    {
        _speed += amount;
        _speed = Mathf.Clamp(_speed, baseSpeed, baseSpeed * 2);
    }

    public void DecreaseSpeedClamped(float amount)
    {
        _speed -= amount;
        _speed = Mathf.Clamp(_speed, baseSpeed, baseSpeed * 2);
    }
}