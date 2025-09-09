namespace Task1.Constants
{
    /// <summary>
    /// Static class which contatins constants to working with database
    /// </summary>
    public static class DbConstants
    {
        /// <summary>
        /// Connection string using to connect to database
        /// </summary>
        public static string ConnectionString = "Host=localhost;Port=5434;Database=B1DB;Username=db_admin;Password=db_password";

        /// <summary>
        /// SqlCommand(Task4) thats returns sum of int strings and median of double strings
        /// </summary>
        public static string SqlCommand = @"
            SELECT 
                SUM(""IntString""::bigint) AS sum_of_integers,
                (
                    SELECT REPLACE(""DoubleString"", ',', '.')::double precision
                    FROM ""Rows""
                    ORDER BY REPLACE(""DoubleString"", ',', '.')::double precision
                    LIMIT 1 OFFSET (
                        (SELECT COUNT(*) FROM ""Rows"") / 2
                    )
                ) AS median_of_floats
            FROM ""Rows"";
        ";
    }
}
