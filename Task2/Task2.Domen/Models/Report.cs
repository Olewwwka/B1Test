namespace Task2.Domen.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string BankName { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReportDate { get; set; }
        public string Currency { get; set; } = null!;
        public ICollection<ReportLine> ReportLines { get; set; } = new List<ReportLine>();

        public Report()
        {
            
        }
    }
}
