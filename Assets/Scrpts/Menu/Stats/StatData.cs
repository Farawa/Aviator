using System;

public class StatData
{
    private static readonly string[] monthNames = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    public StatData(DateTime date, int points)
    {
        Date = $"{date.Day} {monthNames[date.Month]}";
        Points = points;
    }

    public StatData(string date, int points)
    {
        Date = date;
        Points = points;
    }

    public string Date;
    public int Points;
}