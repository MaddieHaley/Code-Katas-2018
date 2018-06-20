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
            Assert.Equal(Program.NumbersToWords(12345), "twelve thousand three hundred forty five dollars and zero cents");
        }
    }
}
