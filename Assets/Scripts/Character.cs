using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private float _health;
    private float _baseModelHeight;

    public float baseHealth;
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;

    public void Awake()
    {
        _health = baseHealth;
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
}