namespace Task1.Generator
{
    /// <summary>
    /// Generator of strings with test data.
    /// Provides methods to generate strings tiwh random data
    /// </summary>
    public class GeneratorOfVariables
    {
        /// <summary>
        /// Random number generator for unique sequences
        /// </summary>
        private Random random = new();
        /// <summary>
        /// Constructor for creating new instance of class
        /// </summary>
        public GeneratorOfVariables()
        {
            
        }
        /// <summary>
        /// Generate random date between now and last N years
        /// </summary>
        /// <returns>Generated date in string format</returns>
        public string GetRandomDate()
        {
            var startDate = DateTime.Now.AddYears(-GeneratorConstants.lastYears);
            var range = (int)(DateTime.Now - startDate).TotalDays;

            var date = startDate.AddDays(random.Next(range));

            return date.ToString("dd.MM.yyyy");
        }
        /// <summary>
        /// Generate random string with latins upper and lower letters and
        /// constant lenght
        /// </summary>
        /// <returns>Generated random string</returns>
        public string GetRandomLatinString()
        {
            return new string(Enumerable.Range(0, GeneratorConstants.countOfLetters)
                  .Select(_ => GeneratorConstants.latinLetters[random.Next(GeneratorConstants.latinLetters.Length)])
                  .ToArray());
        }
        /// <summary>
        /// Generate random string with russian upper and lower letters and
        /// constant lenght
        /// </summary>
        /// <returns>Generated random string</returns>
        public string GetRandomRussianString()
        {
            return new string(Enumerable.Range(0, GeneratorConstants.countOfLetters)
                .Select(_ => GeneratorConstants.russianLetters[random.Next(GeneratorConstants.russianLetters.Length)])
                .ToArray());
        }
        /// <summary>
        /// Generate even random int number between const values
        /// </summary>
        /// <returns>Generated int number in string format</returns>
        public string GetRandomInt()
        {
            var result = random.Next(GeneratorConstants.minInt, GeneratorConstants.maxInt);

            return result % 2 == 0 ? result.ToString() : (result + 1).ToString();
        }
        /// <summary>
        /// Generate random double number between const values and 8 decimal places
        /// </summary>
        /// <returns>Generated double number in string format</returns>
        public string GetRandomDouble()
        {
            var result = random.NextDouble() * (GeneratorConstants.maxDouble - GeneratorConstants.minDouble) + GeneratorConstants.minDouble;

            return result.ToString("F8");
        }
    }
}
