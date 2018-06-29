using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Xunit;

namespace Day4
{
    public class Tests
    {
        [Fact]
        public static void RomanToNumberTest()
        {
            Assert.Equal(442, Program.RomanToNumber("CDXLII"));
            Assert.Equal(1, Program.RomanToNumber("I"));
            Assert.Equal(1999, Program.RomanToNumber("MCMXCIX"));
        }

        [Fact]
        public static void NumberToRomanTest()
        {
            Assert.Equal("CCCLI", Program.NumberToRoman(351));
            Assert.Equal("MXXIII", Program.NumberToRoman(1023));
            Assert.Equal("MCMXCIX", Program.NumberToRoman(1999));
        }
    }
}
