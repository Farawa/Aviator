using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HitableObject hitableObject;
    [SerializeField] private Slider slider;
    [SerializeField] private Image fill;

    private void Update()
    {
        var percent = hitableObject.Health / hitableObject.totalHealth;
        slider.value = percent;
        if (percent < 0.6f) fill.color = Color.yellow;
        else
        if (percent < 0.3f) fill.color = Color.red;
        else fill.color = Color.green;

    }
}
