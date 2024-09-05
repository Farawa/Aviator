using System;

public static class ProgressHolder
{
    private const string pointsKey = "PointsEarned";
    private const string maxLevelKey = "MaxLevelEarned";
    public static Action<int> OnUpdatePoints;
    public const int MaxLevel = 25;
    public static int SelectedLevel = 1;
    public static int MaxLevelEarned
    {
        get
        {
            return PlayerPrefsHelper.GetInt(maxLevelKey, 1);
        }
        private set
        {
            PlayerPrefsHelper.SetInt(maxLevelKey, value);
        }
    }

    public static void AddMaxLevel()
    {
        MaxLevelEarned++;
    }

    public static int PointsEarned
    {
        get
        {
            return PlayerPrefsHelper.GetInt(pointsKey);
        }
        private set
        {
            PlayerPrefsHelper.SetInt(pointsKey, value);
        }
    }

    public static void AddPoints(int value)
    {
        PointsEarned += value;
        OnUpdatePoints(PointsEarned);
    }
}
