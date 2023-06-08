namespace InvertedIndex
{
    public class InvertedIndex
    {
        public SortedDictionary<string, List<StatisticalInformation>> InvertedIndexDictionary { set; get; }

        public InvertedIndex()
        {
            InvertedIndexDictionary = new SortedDictionary<string, List<StatisticalInformation>>();
        }
        public void FillInvertedIndex(string[] text, string fileName)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (InvertedIndexDictionary.ContainsKey(text[i]))
                {
                    var lexema = InvertedIndexDictionary[text[i]].FirstOrDefault(e => e.FileName == fileName);

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
                        InvertedIndexDictionary[text[i]].Add(new StatisticalInformation { FileName = fileName, CountEntry = 1, PositionsEntry = new List<int> { i } });
                    }
                }
                else
                {
                    InvertedIndexDictionary.Add(text[i],
                        new List<StatisticalInformation>{
                            new StatisticalInformation { FileName = fileName, CountEntry = 1, PositionsEntry = new List<int> { i } } });
                }
            }
        }
    }
}
