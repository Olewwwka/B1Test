using Task1.Data;

namespace Task1.Services
{
    /// <summary>
    /// Service which import data from file to database
    /// </summary>
    public class ImportService
    {
        /// <summary>
        /// Instance of DbConxext
        /// </summary>
        private readonly Task1Context _dbContext;
        /// <summary>
        /// Buffer that allows save data in database in partss 
        /// </summary>
        private readonly List<RowModel> _buffer = new();

        /// <summary>
        /// Constructor thats create instance of service and turns of ChangeTracker
        /// </summary>
        /// <param name="context">Existing instance of DbContext</param>
        public ImportService(Task1Context context)
        {
            _dbContext = context;
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        }
        /// <summary>
        /// Class thats read lines from .txt file and save them in database in parts with const zise
        /// </summary>
        /// <param name="fileName">Name of file which importing in database</param>
        /// <returns>Comlited task</returns>
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
