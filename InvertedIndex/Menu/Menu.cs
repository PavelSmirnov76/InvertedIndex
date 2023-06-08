using InvertedIndex.Services.ReaderService;
using SortingAlgorithmsConsoleView.Services.ReaderService;

namespace SortingAlgorithmsConsoleView.Menu
{
    public class Menu
    {
        private readonly MenuWriterHelper menuWriterHelper;
        private readonly IReaderService readerService;


        public Menu(MenuWriterHelper menuWriterHelper, IReaderService readerService )
        {
            this.readerService = readerService;
            this.menuWriterHelper = menuWriterHelper;
        }
        public void OpenMenu()
        {
            do
            {
                try
                {
                    var invertedIndex = new InvertedIndex.InvertedIndex();

                    menuWriterHelper.WriteChoiseDirectoryMenu();

                    var directory = readerService.Read();

                    foreach (var file in Directory.GetFiles(directory))
                    {
                        invertedIndex.FillInvertedIndex(
                               new FileReaderService(file).Read().Split(new char[] { ' ', '\n', '\t' }), file);
                    }

                    menuWriterHelper.WriteCoiseLexemeMenu();

                    var lexeme = readerService.Read();

                    menuWriterHelper.WriteSortedLexemeEntries(lexeme, invertedIndex.InvertedIndexDictionary);

                    menuWriterHelper.WriteChoisestring();
                    var line = int.Parse(readerService.Read()) - 1;

                    menuWriterHelper.WriteSortedLexemeEntriesDetails(lexeme, line, invertedIndex.InvertedIndexDictionary);
                }
                catch (Exception ex)
                {
                    menuWriterHelper.WriteException(ex.Message);
                }
            }
            while (true);
        }     
    }
}
