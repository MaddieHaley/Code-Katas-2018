using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NumbersToWords_Day1
{
    public class Test
    {
        [Fact]
        public void shouldTranslateNumsToWords()
        {
            Assert.Equal("zero", Program.numsToWords("0"));
            Assert.Equal("one hundred", Program.numsToWords("100"));
            Assert.Equal("forty-six million, eight hundred twenty-three thousand, nine hundred seventy-five", Program.numsToWords("46823975"));
            Assert.Equal("five hundred forty-six decillion, four hundred fifty-six nonillion, five hundred fifteen octillion, six hundred forty-five septillion, six hundred forty-five sextillion, six hundred forty-five quintillion, six hundred forty-four quadrillion, six hundred forty-six trillion, eight hundred twenty-three billion, nine hundred seventy-five million, two hundred thirty-two thousand, three hundred twenty-three", Program.numsToWords("546456515645645645644646823975232323"));
        }

        [Fact]
        public void shouldTranslateWordsToNums()
        {
            Assert.Equal("0", Program.wordsToNums("zero"));
            Assert.Equal("100", Program.wordsToNums("one hundred"));
            Assert.Equal("46823975", Program.wordsToNums("forty-six million, eight hundred twenty-three thousand, nine hundred seventy-five"));
            Assert.Equal("546456515645645645644646823975232323", Program.wordsToNums("five hundred forty-six decillion, four hundred fifty-six nonillion, five hundred fifteen octillion, six hundred forty-five septillion, six hundred forty-five sextillion, six hundred forty-five quintillion, six hundred forty-four quadrillion, six hundred forty-six trillion, eight hundred twenty-three billion, nine hundred seventy-five million, two hundred thirty-two thousand, three hundred twenty-three"));
        }
    }
}
