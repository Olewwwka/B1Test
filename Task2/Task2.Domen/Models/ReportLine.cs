using System.Text.Json.Serialization;

namespace Task2.Domen.Models
{
    public class ReportLine
    {
        public int Id { get; set; }
        
        public int ReportId { get; set; }
        public Report Report { get; set; } = null!;

        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public decimal OpeningBalanceActive { get; set; }
        public decimal OpeningBalancePassive { get; set; }
        public decimal TurnoverDebit { get; set; }
        public decimal TurnoverCredit { get; set; }
        public decimal ClosingBalanceActive { get; set; }
        public decimal ClosingBalancePassive { get; set; }

        public ReportLine()
        {
            
        }
    }
}
