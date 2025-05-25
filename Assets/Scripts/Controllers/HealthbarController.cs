using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] IDamageable damageable;

    private void Start()
    {
        damageable = gameObject.GetComponent<IDamageable>();
    }

    private void Update()
    {
        slider.value = damageable.Health;
    }
}
