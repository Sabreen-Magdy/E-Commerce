namespace Persistence.Configurations
{
    public static class Unity
    {
        /// <summary>
        ///  Check that <paramref name="sourceDate"/> longer than or equal <paramref name="targetDate"/>
        /// </summary>

        /// <returns>Sql string query</returns>
        public static string CheckDate(string sourceDate,
            string targetDate = "GETDATE()") =>
            $"DATEPART(YEAR, {sourceDate}) >= DATEPART(YEAR, {targetDate}) and DATEPART(MONTH, {sourceDate}) >= DATEPART(MONTH, {targetDate}) and DATEPART(DAY, {sourceDate}) >= DATEPART(DAY, {targetDate})";
    
    }
}
