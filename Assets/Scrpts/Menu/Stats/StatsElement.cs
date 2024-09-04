using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI date;
    [SerializeField] private TextMeshProUGUI value;

    public void Initiate(string date, string value)
    {
        this.date.text = date;
        this.value.text = value;
    }
}
