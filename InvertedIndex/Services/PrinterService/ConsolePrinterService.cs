namespace SortingAlgorithmsConsoleView.Services.PrinterService
{
    internal class ConsolePrinterService : IPrinterService
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
