using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Day_2
{
    public class Test
    {
        [Fact]
        public void NumbersToWordsTest()
        {
            Assert.Equal("twelve thousand three hundred forty five dollars and zero cents", Program.NumbersToWords("12345"));
            Assert.Equal("zero", Program.NumbersToWords("0"));
            Assert.Equal("one hundred twenty two trillion four hundred four thousand fifty five dollars and thirty four cents", Program.NumbersToWords("122000000404055.34"));
        }

        [Fact]
        public void WordsToNumbersTest()
        {
            Assert.Equal("12345", Program.WordsToNumbers("twelve thousand three hundred forty five dollars and zero cents"));
            Assert.Equal(0, Program.WordsToNumbers("zero"));
            Assert.Equal(122000000404055.34, Program.WordsToNumbers("one hundred twenty two trillion four hundred four thousand fifty five dollars and thirty four cents"));
        }
    }
}
