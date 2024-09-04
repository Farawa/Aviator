using System;

public static class PointsController
{
    private const string pointsKey = "PointsEarned";
    public static Action<int> OnUpdatePoints;

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
