using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatsHolder
{
    private static readonly string statsKey = "StatsResultList";
    public static List<StatData> GetStatDatas()
    {
        var data = JsonConvert.DeserializeObject<List<StatData>>(PlayerPrefsHelper.GetString(statsKey));
        return data == null ? new List<StatData>() : data;
    }

    public static void AddStatData(int value)
    {
        var data = GetStatDatas();
        data.Add(new StatData(DateTime.Now, value));
    }
}
