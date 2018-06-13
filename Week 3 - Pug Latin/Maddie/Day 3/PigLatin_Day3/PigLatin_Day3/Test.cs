using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PigLatin_Day3
{
    public class Test
    {
        [Fact]
        public void ShouldTranslateConsonantWordsCorrectly()
        {
            Assert.Equal("igpay", Program.TranslateWord("pig"));
            Assert.Equal("ananabay", Program.TranslateWord("banana"));
            Assert.Equal("oveglay", Program.TranslateWord("glove"));
        }
        [Fact]
        public void ShouldTranslateVowelWordsCorrectly()
        {
            Assert.Equal("eggyay", Program.TranslateWord("egg"));
            Assert.Equal("eatyay", Program.TranslateWord("eat"));
        }
        [Fact]
        public void ShouldTranslateYWordsCorrectly()
        {
            Assert.Equal("ellowyay", Program.TranslateWord("yellow"));
            Assert.Equal("ymay", Program.TranslateWord("my"));
            Assert.Equal("ythmrhay", Program.TranslateWord("rhythm"));
        }
    }
}
