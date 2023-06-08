namespace InvertedIndex
{
    internal class Program
    {
        static void Main()
        {
            var invertedIndex = new SortedDictionary<string, List<StatisticalInformation>>();

            Console.WriteLine("Выберете директорию");

            var directory = Console.ReadLine();

            foreach (var file in Directory.GetFiles(directory))
            {
                using (var reader = new StreamReader(file))
                {
                    WriteInvertedIndex(invertedIndex, reader.ReadToEnd().Split(new char[] { ' ', '\n', '\t' }), file);
                }
            }

            Console.WriteLine("Введите лексему.");

            var lexem = Console.ReadLine();
            var numberLine = 1;

            foreach (var item in invertedIndex[lexem].OrderByDescending(e => e.CountEntry))
            {
                Console.WriteLine($"{numberLine} {item.FileName} {item.CountEntry}");
                numberLine++;
            }

            Console.WriteLine("Выберете строку.");
            var line = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine($"{invertedIndex[lexem][line].FileName} {invertedIndex[lexem][line].CountEntry}");
            foreach (var entry in invertedIndex[lexem][line].PositionsEntry)
            {
                Console.Write($"{entry} ");
            }
        }

       private static void WriteInvertedIndex(SortedDictionary<string, List<StatisticalInformation>> invertedIndex, string[] text, string fileName)
        {
            for(int i = 0; i < text.Length; i++)
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