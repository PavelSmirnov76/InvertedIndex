using SortingAlgorithmsConsoleView.Menu;
using SortingAlgorithmsConsoleView.Services.PrinterService;
using SortingAlgorithmsConsoleView.Services.ReaderService;

namespace InvertedIndex
{
    internal class Program
    {
        static void Main()
        {
            var menu = new Menu(new MenuWriterHelper(new ConsolePrinterService()), new ConsoleReaderService());

            menu.OpenMenu();
        }      
    }
}