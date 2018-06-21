using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Day4
{
    public class ConversionTests
    {
        [Fact]
        public void ConvertsPositiveNumbersToWords()
        {
            Assert.Equal("eight hundred", NumberToWordConverter.Convert(800));
            Assert.Equal("one hundred million four hundred fifty six thousand three hundred ninety six", NumberToWordConverter.Convert(100456396));
            Assert.Equal("three hundred thousand thirteen", NumberToWordConverter.Convert(300013));
            Assert.Equal("one", NumberToWordConverter.Convert(1));
            Assert.Equal("one billion", NumberToWordConverter.Convert(1000000000));
        }

        [Fact]
        public void ConvertsNegativeNumbersToWords()
        {
            Assert.Equal("negative eight hundred", NumberToWordConverter.Convert(-800));
            Assert.Equal("negative one hundred million four hundred fifty six thousand three hundred ninety six", NumberToWordConverter.Convert(-100456396));
            Assert.Equal("negative three hundred thousand thirteen", NumberToWordConverter.Convert(-300013));
            Assert.Equal("negative one", NumberToWordConverter.Convert(-1));
            Assert.Equal("negative one billion", NumberToWordConverter.Convert(-1000000000));
        }

        [Fact]
        public void ConvertsWordsToPositiveNumbers()
        {
            Assert.Equal(900013, WordToNumberConverter.Convert("nine hundred thousand thirteen"));
            Assert.Equal(18476, WordToNumberConverter.Convert("eighteen thousand four hundred seventy six"));
            Assert.Equal(1345678919, WordToNumberConverter.Convert("one billion three hundred fourty five million six hundred seventy eight thousand nine hundred nineteen"));
            Assert.Equal(1, WordToNumberConverter.Convert("one"));
            Assert.Equal(36, WordToNumberConverter.Convert("thirty six"));
        }

        [Fact]
        public void ConvertsWordsToNegativeNumbers()
        {
            Assert.Equal(-900013, WordToNumberConverter.Convert("negative nine hundred thousand thirteen"));
            Assert.Equal(-18476, WordToNumberConverter.Convert("negative eighteen thousand four hundred seventy six"));
            Assert.Equal(-1345678919, WordToNumberConverter.Convert("negative one billion three hundred fourty five million six hundred seventy eight thousand nine hundred nineteen"));
            Assert.Equal(-1, WordToNumberConverter.Convert("negative one"));
            Assert.Equal(-36, WordToNumberConverter.Convert("negative thirty six"));
        }

        [Fact]
        public void ConvertsZeroes()
        {
            Assert.Equal("zero", NumberToWordConverter.Convert(0));
            Assert.Equal(0, WordToNumberConverter.Convert("zero"));
        }

        [Fact]
        public void DealsWithImproperInputs()
        {
            Assert.Equal(0, WordToNumberConverter.Convert(null));
            Assert.Equal(0, WordToNumberConverter.Convert(""));
        }
    }
}
