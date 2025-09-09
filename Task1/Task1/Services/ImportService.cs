using Task1.Data;

namespace Task1.Services
{
    public class ImportService
    {
        private readonly Task1Context _dbContext;
        private readonly List<RowModel> _buffer = new();

        public ImportService(Task1Context context)
        {
            _dbContext = context;
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task ImportFileAsync(string fileName)
        {
            var path = Path.Combine(FilesConstants.DirectoryName, fileName);

            if(!File.Exists(path))
            {
                return;
            }

            var data = File.ReadLines(path);
            var totalCount = data.Count();
            int process = 0;

            foreach ( var line in data)
            {
                var subParts = line.Split("||");

                if (subParts.Length != 5)
                {
                    continue;
                }

                var row = new RowModel(subParts[0], subParts[1], subParts[2], subParts[3], subParts[4]);

                _buffer.Add(row);
                process++;

                if(process % FilesConstants.RowsBuffer == 0)
                {
                    await _dbContext.Rows.AddRangeAsync(_buffer);
                    await _dbContext.SaveChangesAsync();

                    _buffer.Clear();
                    _dbContext.ChangeTracker.Clear();

                    Console.WriteLine($"Process: {process} lines. \n Exists: {totalCount - process}" );
                }
            }

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            Console.WriteLine($"Imported: {process} rows");
        }
    }
}
