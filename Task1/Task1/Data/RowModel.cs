namespace Task1.Data
{
    /// <summary>
    /// Model to save generated strings in database
    /// </summary>
    public class RowModel
    {
        /// <summary>
        /// Unique ID of string in DB. Generated using EF Core 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Random date in string format
        /// </summary>
        public string DateString { get; set; }
        /// <summary>
        /// Random string that consist of latin characters
        /// </summary>
        public string LatinString { get; set; }
        /// <summary>
        /// Random string that consist of russian characters
        /// </summary>
        public string RussianString { get; set; }
        /// <summary>
        /// Random int number in string format
        /// </summary>
        public string IntString { get; set; }
        /// <summary>
        /// Random double number in string format
        /// </summary>
        public string DoubleString { get; set; }
        /// <summary>
        /// Constructor, create new instanse of class with given params
        /// </summary>
        /// <param name="date">Random string that consist of latin characters</param>
        /// <param name="latin">Random string that consist of russian characters</param>
        /// <param name="russian">Random string that consist of russian characters</param>
        /// <param name="intstr">Random int number in string format</param>
        /// <param name="doublestr">Random double number in string format</param>
        public RowModel(string date, string latin, string russian, string intstr, string doublestr)
        {
            DateString = date;
            LatinString = latin;
            RussianString = russian;
            IntString = intstr;
            DoubleString = doublestr;
        }
        /// <summary>
        /// Constructor which needed to create migration(EF Core)
        /// </summary>
        public RowModel()
        {
            
        }
    }
}
