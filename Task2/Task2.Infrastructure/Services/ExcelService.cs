using ClosedXML.Excel;
using Task2.Domen.Abstractions;
using Task2.Domen.Models;

namespace Task2.Infrastructure.Services
{
    /// <summary>
    /// Service to working with excel files
    /// Contains methods to save excel files in database and export
    /// excel data from database to .xslx file
    /// </summary>
    public class ExcelService : IExcelService
    {
        /// <summary>
        /// Repository with logic of working with reports from database
        /// </summary>
        private readonly IReportRepository _reportRepository;
        /// <summary>
        /// Constructor thats initialize new instance of handler with concrete repossitory
        /// </summary>
        /// <param name="reportRepository">Existing instance of repository</param>
        public ExcelService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        /// <summary>
        /// method which parse data from excel file and save it in database
        /// </summary>
        /// <param name="excelStream">Stream to excel file</param>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>Saves report</returns>
        public async Task<Report> ParseReportAsync(Stream excelStream, CancellationToken cancellationToken)
        {
            using var workbook = new XLWorkbook(excelStream);
            var worksheet = workbook.Worksheet(1); 

            var bankName = worksheet.Cell(1, 1).GetString();
            var periodLine = worksheet.Cell(3, 1).GetString(); 
            var reportDateLine = worksheet.Cell(5, 1).GetString(); 
            var currency = worksheet.Cell(5, 5).GetString(); 

            var parts = periodLine.Split(' ');
            var periodStart = DateTime.SpecifyKind(DateTime.Parse(parts[3]), DateTimeKind.Utc);
            var periodEnd = DateTime.SpecifyKind(DateTime.Parse(parts[5]), DateTimeKind.Utc);
            DateTime reportDate;

            if (!DateTime.TryParse(worksheet.Cell(5, 1).GetString(), out reportDate))
            {
                reportDate = DateTime.SpecifyKind(reportDate, DateTimeKind.Utc);
            }

            var report = new Report
            {
                BankName = bankName,
                StartTime = periodStart,
                EndTime = periodEnd,
                ReportDate = reportDate,
                Currency = currency
            };

            foreach (var row in worksheet.RowsUsed().Skip(7))
            {
                var accountCode = row.Cell(1).GetString();
                if (string.IsNullOrWhiteSpace(accountCode) || !decimal.TryParse(row.Cell(2).GetString().Replace(" ", ""), out _))
                    continue; 

                var line = new ReportLine
                {
                    Account = new Account
                    {
                        AccountCode = accountCode,
                        ClassCode = accountCode.Substring(0, 1),
                        ClassName = "" 
                    },

                    OpeningBalanceActive = row.Cell(2).GetValue<decimal>(),
                    OpeningBalancePassive = row.Cell(3).GetValue<decimal>(),
                    TurnoverDebit = row.Cell(4).GetValue<decimal>(),
                    TurnoverCredit = row.Cell(5).GetValue<decimal>(),
                    ClosingBalanceActive = row.Cell(6).GetValue<decimal>(),
                    ClosingBalancePassive = row.Cell(7).GetValue<decimal>()
                };

                report.ReportLines.Add(line);
            }

            await _reportRepository.AddAsync(report, cancellationToken);

            return report;
        }
        /// <summary>
        /// Exports excel data from database to .xlsx file
        /// </summary>
        /// <param name="reportId">Id of report to export</param>
        /// <param name="cancellationToken">Token to cancell operation</param>
        /// <returns>Exported data</returns>
        /// <exception cref="Exception">Throws if report not found in database</exception>
        public async Task<MemoryStream> ExportReportAsync(int reportId, CancellationToken cancellationToken)
        {
            var report = await _reportRepository.GetByIdAsync(reportId, cancellationToken);
            if (report == null)
                throw new Exception($"Report with id {reportId} not found");

            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Report");

            ws.Cell(1, 1).Value = "Account";
            ws.Cell(1, 2).Value = "ClassCode";
            ws.Cell(1, 3).Value = "OpeningBalanceActive";
            ws.Cell(1, 4).Value = "OpeningBalancePassive";
            ws.Cell(1, 5).Value = "TurnoverDebit";
            ws.Cell(1, 6).Value = "TurnoverCredit";
            ws.Cell(1, 7).Value = "ClosingBalanceActive";
            ws.Cell(1, 8).Value = "ClosingBalancePassive";

            int row = 2;
            foreach (var rl in report.ReportLines)
            {
                ws.Cell(row, 1).Value = rl.Account.AccountCode;
                ws.Cell(row, 2).Value = rl.Account.ClassCode;
                ws.Cell(row, 3).Value = rl.OpeningBalanceActive;
                ws.Cell(row, 4).Value = rl.OpeningBalancePassive;
                ws.Cell(row, 5).Value = rl.TurnoverDebit;
                ws.Cell(row, 6).Value = rl.TurnoverCredit;
                ws.Cell(row, 7).Value = rl.ClosingBalanceActive;
                ws.Cell(row, 8).Value = rl.ClosingBalancePassive;
                row++;
            }

            ws.Columns().AdjustToContents();

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0; 
            return stream;
        }
    }
}
