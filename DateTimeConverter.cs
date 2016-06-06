using System;

public class DateTimeConverter
{
    public DateTime ConvertFromUnixTimestamp(double timestamp)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return origin.AddSeconds(timestamp);
    }

    public double ConvertToUnixTimestamp(DateTime date)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan diff = date.ToUniversalTime() - origin;
        return Math.Floor(diff.TotalSeconds);
    }

    public DateTime ConvertDateStringToDateTime(string fullDate)
    {
        return DateTime.ParseExact(fullDate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
    }

    public DateTime ConvertTimeStringToDateTime(string fullTime)
    {
        return DateTime.ParseExact(fullTime, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
    }
}
