using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] private Slider _characterHealthSlider;

    protected override void DoAwake() { }

    private void FixedUpdate()
    {
        _characterHealthSlider.value = GetHealth() / baseHealth;
    }
}
