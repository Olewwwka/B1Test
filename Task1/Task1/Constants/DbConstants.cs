namespace Task1.Constants
{
    public static class DbConstants
    {
        public static string ConnectionString = "Host=localhost;Port=5434;Database=B1DB;Username=db_admin;Password=db_password";

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
