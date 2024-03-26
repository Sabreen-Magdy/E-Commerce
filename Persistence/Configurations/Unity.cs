namespace Persistence.Configurations
{
    public static class Unity
    {
        public static string CheckDate(string date) =>
            $"DATEPART(YEAR, {date}) >= DATEPART(YEAR, GETDATE()) and DATEPART(MONTH, {date}) >= DATEPART(MONTH, GETDATE()) and DATEPART(DAY, {date}) >= DATEPART(DAY, GETDATE()) ";
    }
}
