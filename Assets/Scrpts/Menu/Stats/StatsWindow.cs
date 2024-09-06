using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsWindow : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private StatsElement elementPrefab;

    private void OnEnable()
    {
        RefreshStats();
    }

    private void RefreshStats()
    {
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }
        SpawnStats();
    }

    private void SpawnStats()
    {
        var data = StatsHolder.GetStatDatas();
        for (int i = 0; i < data.Count; i++)
        {
            Instantiate(elementPrefab,content).Initiate(data[i].Date, data[i].Points.ToString());
        }
    }
}
