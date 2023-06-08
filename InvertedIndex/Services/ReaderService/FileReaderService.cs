using SortingAlgorithmsConsoleView.Services.ReaderService;

namespace InvertedIndex.Services.ReaderService
{
    public class FileReaderService : IReaderService
    {
        private readonly string filePath;
        public FileReaderService(string DirectoryPath)
        {
            filePath = DirectoryPath;
        }
        public string Read()
        {
            var str = "";

            using (var reader = new StreamReader(filePath))
            {
                str = reader.ReadToEnd();
            }

            return str;
        }
    }
}
