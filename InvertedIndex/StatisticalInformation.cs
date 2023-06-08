namespace InvertedIndex
{
    public class StatisticalInformation: IComparable<StatisticalInformation>
    {
        public string? FileName { set; get; }
        public int CountEntry { set; get; }
        public List<int>? PositionsEntry { set; get; }

        public int CompareTo(StatisticalInformation? obj)
        {
            if (obj is null) throw new ArgumentException("Некорректное значение.");
            return CountEntry.CompareTo(obj.CountEntry);
        }
    }
}
