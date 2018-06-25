using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day5;
namespace Day5
{
    public class NumbersToWords
    {
        [Fact]
        public void TranslatesToNumbersandWords()
        {
            Assert.Equal("one hundred twenty-three million four hundred fifty-six thousand seven hundred eighty-nine", Program.converter("123456789"));
            Assert.Equal("nine hundred eighty-seven billion one hundred twenty-three million five hundred nineteen thousand three hundred thirteen", Program.converter("987123519313"));
            Assert.Equal("987123589313", Program.converter("nine hundred eighty-seven billion one hundred twenty-three million five hundred eighty-nine thousand three hundred thirteen"));
            Assert.Equal("123456789", Program.converter("one hundred twenty-three million four hundred fifty-six thousand seven hundred eighty-nine"));
        }
    }
}
