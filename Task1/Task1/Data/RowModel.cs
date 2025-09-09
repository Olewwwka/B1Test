namespace Task1.Data
{
    public class RowModel
    {
        public Guid Id { get; set; }
        public string DateString { get; set; }
        public string LatinString { get; set; }
        public string RussianString { get; set; }
        public string IntString { get; set; }
        public string DoubleString { get; set; }

        public RowModel(string date, string latin, string russian, string intstr, string doublestr)
        {
            DateString = date;
            LatinString = latin;
            RussianString = russian;
            IntString = intstr;
            DoubleString = doublestr;
        }

        public RowModel()
        {
            
        }
    }
}
