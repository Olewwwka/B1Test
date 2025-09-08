namespace Task1.Generator
{
    public class GeneratorOfVariables
    {
        private Random random = new();

        public GeneratorOfVariables()
        {
            
        }
        public string GetRandomDate()
        {
            var startDate = DateTime.Now.AddYears(-GeneratorConstants.lastYears);
            var range = (int)(DateTime.Now - startDate).TotalDays;

            var date = startDate.AddDays(random.Next(range));

            return date.ToString("dd.MM.yyyy");
        }

        public string GetRandomLatinString()
        {
            return new string(Enumerable.Range(0, GeneratorConstants.countOfLetters)
                  .Select(_ => GeneratorConstants.latinLetters[random.Next(GeneratorConstants.latinLetters.Length)])
                  .ToArray());
        }

        public string GetRandomRussianString()
        {
            return new string(Enumerable.Range(0, GeneratorConstants.countOfLetters)
                .Select(_ => GeneratorConstants.russianLetters[random.Next(GeneratorConstants.russianLetters.Length)])
                .ToArray());
        }

        public string GetRandomInt()
        {
            var result = random.Next(GeneratorConstants.minInt, GeneratorConstants.maxInt);

            return result % 2 == 0 ? result.ToString() : (result + 1).ToString();
        }

        public string GetRandomDouble()
        {
            var result = random.NextDouble() * (GeneratorConstants.maxDouble - GeneratorConstants.minDouble) + GeneratorConstants.minDouble;

            return result.ToString("F8");
        }
    }
}
