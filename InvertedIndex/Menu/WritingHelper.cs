using InvertedIndex;
using SortingAlgorithmsConsoleView.Services.PrinterService;
using System.Runtime.CompilerServices;

namespace SortingAlgorithmsConsoleView.Menu
{
    public class MenuWriterHelper
    {
        private readonly IPrinterService printerService;

        public MenuWriterHelper(IPrinterService printerService)
        {
            this.printerService = printerService;
        }

        public void WriteChoiseDirectoryMenu()
        {
            printerService.Print("Выберете директорию" );
        }

        public void WriteCoiseLexemeMenu()
        {
            printerService.Print("Введите лексему.");

        }

        public void WriteSortedLexemeEntries(string lexeme, SortedDictionary<string, List<StatisticalInformation>> invertedIndex)
        {
            var numberLine = 1;

            invertedIndex[lexeme] = invertedIndex[lexeme].OrderByDescending(e => e.CountEntry).ToList();

            foreach (var item in invertedIndex[lexeme])
            {
                printerService.Print($"{numberLine} {item.FileName} {item.CountEntry}");
                numberLine++;
            }
        }

        public void WriteChoisestring()
        {
            printerService.Print("Выберете строку");
        }

        public void WriteSortedLexemeEntriesDetails(string lexeme, int line, SortedDictionary<string, List<StatisticalInformation>> invertedIndex)
        {
            printerService.Print($"{invertedIndex[lexeme][line].FileName} {invertedIndex[lexeme][line].CountEntry}");
            printerService.Print("индексы вхождения в файл.");
            foreach (var entry in invertedIndex[lexeme][line].PositionsEntry)
            {
                printerService.Print($"{entry} ");
            }
        }

        public void WriteException(string message)
        {
            printerService.Print(message);
        }
    }
}
