using System;
using System.ComponentModel.DataAnnotations;

namespace InvertedIndexTests
{
    public class InvertedIndexTests
    {
        [Fact]
        public void FillInvertedIndex_text_aaaaaa_filename_test___CheckCount_0()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var expected = 0;

            var actial = invertedIndex.InvertedIndexDictionary.Count;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaaaaa_filename_test___CheckCount_1()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaaaa" };
            var fileName = "test";
            var expected = 1;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary.Count;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaa_aa_filename_test___CheckCount_2()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaa", "aa" };
            var fileName = "test";
            var expected = 2;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary.Count;

            Assert.Equal(expected, actial);
        }
        [Fact]
        public void FillInvertedIndex_text_aa_aa_filename_test___CheckCount_1()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aa", "aa" };
            var fileName = "test";
            var expected = 1;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary.Count;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaa_aa_filename_test___CheckCountListEntries_1()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaa", "aa" };
            var fileName = "test";
            var expected = 1;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]].Count;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aa_aa_filename_test___CheckCountListEntries_1()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aa", "aa" };
            var fileName = "test";
            var expected = 1;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]].Count;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aa_aa_filename_test___CheckCountEntries_2()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aa", "aa" };
            var fileName = "test";
            var expected = 2;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]][0].CountEntry;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaa_aa_filename_test___CheckCountEntries_1()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaa", "aa" };
            var fileName = "test";
            var expected = 1;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]][0].CountEntry;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaa_aa_filename_test___CheckPositionsEntryCount_1()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaa", "aa" };
            var fileName = "test";
            var expected = 1;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]][0].PositionsEntry.Count;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aa_aa_filename_test___CheckPositionsEntryCount_2()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aa", "aa" };
            var fileName = "test";
            var expected = 2;

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]][0].PositionsEntry.Count;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaa_aa_filename_test___CheckPositionsEntryFor_aaa_0()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaa", "aa" };
            var fileName = "test";
            var expected = new List<int> { 0 };

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]][0].PositionsEntry;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaa_aa_filename_test___CheckPositionsEntryFor_aa_1()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaa", "aa" };
            var fileName = "test";
            var expected = new List<int> { 1 };

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[1]][0].PositionsEntry;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aa_aa_filename_test___CheckPositionsEntryFor_aa_0_1()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aa", "aa" };
            var fileName = "test";
            var expected = new List<int> { 0, 1 };

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]][0].PositionsEntry;

            Assert.Equal(expected, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaaaaa_fileName_test___CheckConteins_aaaaa()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaaaa" };
            var fileName = "test";

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary.ContainsKey(text[0]);

            Assert.True(actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aaaaaa_fileName_test___CheckFileName_test()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aaaaa" };
            var fileName = "test";

            invertedIndex.FillInvertedIndex(text, fileName);
            var actial = invertedIndex.InvertedIndexDictionary[text[0]][0].FileName;

            Assert.Equal(fileName, actial);
        }

        [Fact]
        public void FillInvertedIndex_text_aa_fileName_first_And_text_aa_fileName_second_CheckFileName_first_second()
        {
            var invertedIndex = new InvertedIndex.InvertedIndex();
            var text = new string[] { "aa" };
            var firstFileName = "first";
            var secondFileName = "second";

            invertedIndex.FillInvertedIndex(text, firstFileName);
            invertedIndex.FillInvertedIndex(text, secondFileName);

            Assert.Equal(firstFileName, invertedIndex.InvertedIndexDictionary[text[0]][0].FileName);
            Assert.Equal(secondFileName, invertedIndex.InvertedIndexDictionary[text[0]][1].FileName);
        }
    }
}