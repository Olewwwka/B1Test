using Microsoft.EntityFrameworkCore;
using Task2.Domen.Abstractions;
using Task2.Domen.Models;

namespace Task2.Infrastructure.Repositories
{
    /// <summary>
    /// Repository with logic of working with reports from database
    /// </summary>
    public class ReportRepository : IReportRepository
    {
        /// <summary>
        /// Instanse of DbContext
        /// </summary>
        private readonly Task2DbContext _dbContext;
        /// <summary>
        /// Constructor which create new instance wih existring dbContext
        /// </summary>
        /// <param name="dbContext">existring dbContext from DI container</param>
        public ReportRepository(Task2DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Add new report in database
        /// </summary>
        /// <param name="report">Report to save</param>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>Id of saved report</returns>
        public async Task<int> AddAsync(Report report, CancellationToken cancellationToken)
        {
            await _dbContext.Reports.AddAsync(report, cancellationToken);

            await _dbContext.SaveChangesAsync();

            return report.ReportId;
        }
        /// <summary>
        /// Get all exising reports from database
        /// </summary>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>All collected reports</returns>
        public async Task<List<Report>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Reports
               .OrderByDescending(r => r.ReportDate)
               .ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Get existing report by id
        /// </summary>
        /// <param name="id">id of report</param>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>Collected report</returns>
        public async Task<Report> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Reports
                .Include(r => r.ReportLines)
                    .ThenInclude(rl => rl.Account)
                .FirstOrDefaultAsync(r => r.ReportId == id, cancellationToken);

            return result;
        }
    }
}
