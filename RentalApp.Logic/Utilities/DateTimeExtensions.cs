namespace RentalApp.Logic.Utilities;

public static class DateTimeExtensions
{
    public static DateTime? SpecifyKindUTC(this DateTime? dateTime)
    {
        if (dateTime.HasValue)
            return dateTime.Value.SpecifyKindUTC();

        return null;
    }

    /// <summary>
    /// Returns the value converted to UTC if necessary.
    /// </summary>
    /// <param name="dateTime">DateTime</param>
    /// <returns></returns>
    public static DateTime SpecifyKindUTC(this DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Utc) 
            return dateTime;
        
        return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }

    public static void SetKindUTC(this ref DateTime? dateTime)
    {
        if (dateTime.HasValue)
            dateTime.Value.SpecifyKindUTC();
    }

    /// <summary>
    /// Converts the value to UTC if necessary.
    /// </summary>
    /// <param name="dateTime">DateTime</param>
    /// <returns></returns>
    public static void SetKindUTC(this ref DateTime dateTime)
    {
        dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }
}
