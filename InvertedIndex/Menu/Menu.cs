using InvertedIndex;
using InvertedIndex.Services.ReaderService;
using SortingAlgorithmsConsoleView.Services.ReaderService;
using System.Reflection.PortableExecutable;

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
                    var invertedIndex = new SortedDictionary<string, List<StatisticalInformation>>();

                    menuWriterHelper.WriteChoiseDirectoryMenu();

                    var directory = readerService.Read();

                    foreach (var file in Directory.GetFiles(directory))
                    {                     
                        FillInvertedIndex(invertedIndex,
                               new FileReaderService(file).Read().Split(new char[] { ' ', '\n', '\t' }), file);

                    }

                    menuWriterHelper.WriteCoiseLexemeMenu();

                    var lexeme = readerService.Read();

                    menuWriterHelper.WriteSortedLexemeEntries(lexeme, invertedIndex);

                    menuWriterHelper.WriteChoisestring();
                    var line = int.Parse(readerService.Read()) - 1;

                    menuWriterHelper.WriteSortedLexemeEntriesDetails(lexeme, line, invertedIndex);
                }
                catch (Exception ex)
                {
                    menuWriterHelper.WriteException(ex.Message);
                }
            }
            while (true);
        }

        private static void FillInvertedIndex(SortedDictionary<string, List<StatisticalInformation>> invertedIndex, string[] text, string fileName)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (invertedIndex.ContainsKey(text[i]))
                {
                    var lexema = invertedIndex[text[i]].FirstOrDefault(e => e.FileName == fileName);

                    if (lexema is not null)
                    {

                        if (lexema.PositionsEntry == null)
                        {
                            lexema.PositionsEntry = new List<int> { i };
                            lexema.CountEntry++;
                        }
                        else
                        {
                            lexema.PositionsEntry.Add(i);
                            lexema.CountEntry++;
                        }
                    }
                    else
                    {
                        invertedIndex[text[i]].Add(new StatisticalInformation { FileName = fileName, CountEntry = 1, PositionsEntry = new List<int> { i } });
                    }
                }
                else
                {
                    invertedIndex.Add(text[i],
                        new List<StatisticalInformation>{
                            new StatisticalInformation { FileName = fileName, CountEntry = 1, PositionsEntry = new List<int> { i } } });
                }
            }
        }
    }
}
