using UnityEngine;

public static class PlayerPrefsHelper
{
    public static bool IsWelcomBonusGain()
    {
        return GetBool("isWelcomeBonusGain",false);
    }

    public static void SetWelcomBonusGain()
    {
        SetBool("isWelcomeBonusGain", true);
        PlayerPrefs.Save();
    }

    public static bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) % 2 == 0 ? false : true;
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static int GetInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public static string GetString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }
}
