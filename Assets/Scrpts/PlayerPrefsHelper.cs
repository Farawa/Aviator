using UnityEngine;

public static class PlayerPrefsHelper
{
    public static bool IsWelcomBonusGain()
    {
        return GetBool("isWelcomeBonusGain");
    }

    public static void SetWelcomBonusGain()
    {
        SetBool("isWelcomeBonusGain", true);
    }

    public static bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) % 2 == 0 ? true : false;
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
}
