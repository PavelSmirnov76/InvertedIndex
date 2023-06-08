namespace SortingAlgorithmsConsoleView.Services.ReaderService
{
    public class ConsoleReaderService: IReaderService
    {
        public string Read()
        {
            return Console.ReadLine() ?? throw new ArgumentNullException();
        }
    }
}
