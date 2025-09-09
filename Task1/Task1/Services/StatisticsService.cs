using Microsoft.EntityFrameworkCore;
using Task1.Constants;

namespace Task1.Services
{
    public class StatisticsService
    {
        private readonly Task1Context _dbContext;

        public StatisticsService(Task1Context context)
        {
            _dbContext = context;
        }

        public async Task GetStatistics()
        {
            using var command = _dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = DbConstants.SqlCommand;

            await _dbContext.Database.OpenConnectionAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                var sum = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader[0]);
                var median = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader[1]);

                Console.WriteLine($"Sum : {sum}; Median : {median}");
            }
        }
    }
}
