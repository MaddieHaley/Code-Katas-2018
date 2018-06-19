using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Day2
{
    public class NumbersToWords
    {
        [Fact]
        public void TranslatesToNumbersandWords()
        {
            Assert.Equal("one hundred thirty-seven thousand dollars", Program.Translator("137000"));
            Assert.Equal("one million four hundred ninety thousand dollars", Program.Translator("1490000"));
            Assert.Equal("137000 dollars", Program.Translator ("one hundred thirty-seven thousand"));
            Assert.Equal("3489000 dollars", Program.Translator("three million four hundred eighty-nine thousand"));
        }
    }
}
