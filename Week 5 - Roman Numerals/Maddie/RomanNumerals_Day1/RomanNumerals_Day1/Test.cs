using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RomanNumerals_Day1
{
    public class Test
    {
        [Fact]
        public void ShouldTranslateNumsToRomanNums()
        {
            Assert.Equal("XCIX", Program.NumsToRomanNums(99));
        }

        [Fact]
        public void ShouldTranslateRomanNumsToNums()
        {
            Assert.Equal(99, Program.RomanNumsToNums("XCIX"));
            Assert.Equal(88, Program.RomanNumsToNums("LXXXVIII"));
            Assert.Equal(49, Program.RomanNumsToNums("XLIX"));
        }
    }
}
