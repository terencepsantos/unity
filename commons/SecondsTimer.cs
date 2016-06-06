using UnityEngine;
using System.Collections;

public static class SecondsTimer
{
    public static string TimeFloatToString(float time)
    {
        int hoursTime = (int)Mathf.Floor(time / 3600);
        int minutesTime = (int)Mathf.Floor(time / 60);
        int secondsTime = (int)time % 60;
        string hours = hoursTime.ToString("00");
        string minutes = minutesTime.ToString("00");
        string seconds = secondsTime.ToString("00");

        return string.Concat(hours, "h ", minutes, "m ", seconds, "s");
    }
}
