namespace Task1.Generator
{
    /// <summary>
    /// Class to generate one string, which contains of test strings datas
    /// </summary>
    public class StringGenerator
    {
        /// <summary>
        /// Class to generate random strings
        /// </summary>
        public GeneratorOfVariables _generator;
        /// <summary>
        /// Constructor to create new instance of class
        /// </summary>
        /// <param name="generator">Existing instance of Generator class</param>
        public StringGenerator(GeneratorOfVariables generator)
        {
            _generator = generator;
        }
        /// <summary>
        /// Generate one string from test random strings
        /// </summary>
        /// <returns>Generated string</returns>
        public string GetString()
        {
            return $"{_generator.GetRandomDate()}||" +
                   $"{_generator.GetRandomLatinString()}||" +
                   $"{_generator.GetRandomRussianString()}||" +
                   $"{_generator.GetRandomInt()}||" +
                   $"{_generator.GetRandomDouble()}";
        }
    }
}
