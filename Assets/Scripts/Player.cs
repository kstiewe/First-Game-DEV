using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] private GameObject _containerWithSlider;
    private Slider _characterHealthSlider;

    protected override void DoAwake()
    {
        _characterHealthSlider = _containerWithSlider.GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        _characterHealthSlider.value = GetHealth()/baseHealth;
    }
}
