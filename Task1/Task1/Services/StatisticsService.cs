using Microsoft.EntityFrameworkCore;
using Task1.Constants;

namespace Task1.Services
{
    /// <summary>
    /// Service wich collect statistics from database
    /// </summary>
    public class StatisticsService
    {
        /// <summary>
        /// Instance of DbConxext
        /// </summary>
        private readonly Task1Context _dbContext;
        /// <summary>
        /// Constructor thats create instance of service and turns of ChangeTracker
        /// </summary>
        /// <param name="context">Existing instance of DbContext</param>
        public StatisticsService(Task1Context context)
        {
            _dbContext = context;
        }
        /// <summary>
        /// Execute sql query and output result
        /// </summary>
        /// <returns>Completed task</returns>
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
