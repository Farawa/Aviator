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

    private static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) % 2 == 0 ? true : false;
    }

    private static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
}
