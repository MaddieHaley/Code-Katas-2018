using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4;
namespace Day4
{
    public class NumbersToWords
    {
        [Fact]
        public void TranslatesToNumbersandWords()
        {
            Assert.Equal("one million four hundred ninety-one thousand three hundred forty-two", Program.converter("1491342"));
            Assert.Equal("one hundred thirty-seven thousand ", Program.converter("137000"));
            Assert.Equal("137000", Program.converter("one hundred thirty-seven thousand"));
            Assert.Equal("3489000", Program.converter("three million four hundred eighty-nine thousand"));
        }
    }
}
