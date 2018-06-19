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
            Assert.Equal("zero", Program.NumbersToWords(0));
            Assert.Equal("one hundred twenty two trillion four hundred four thousand fifty five dollars and thirty four cents", Program.NumbersToWords("122000000404055.34"));
        }
    }
}
