namespace Task2.Domen.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountCode { get; set; } = null!;
        public string ClassCode { get; set; } = null!;
        public string ClassName { get; set; } = null!;
        public ICollection<ReportLine> ReportLines { get; set; } = new List<ReportLine>();

        public Account()
        {
            
        }
    }
}
