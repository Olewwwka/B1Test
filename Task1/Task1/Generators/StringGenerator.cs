namespace Task1.Generator
{
    public class StringGenerator
    {
        public GeneratorOfVariables _generator;

        public StringGenerator(GeneratorOfVariables generator)
        {
            _generator = generator;
        }

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
