using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Day2
{
    public class PigLatinTests
    {
        [Fact]
        public void TranslatesGeneralWords()
        {
            Assert.Equal("esttay", PigLatin.Translate("test"));
            Assert.Equal("atinlay", PigLatin.Translate("latin"));
            Assert.Equal("andalfgay", PigLatin.Translate("gandalf"));
            Assert.Equal("urrayhay", PigLatin.Translate("hurray"));
            Assert.Equal("ondolagay", PigLatin.Translate("gondola"));
        }

        [Fact]
        public void TranslatesPhrases()
        {
            Assert.Equal("urplepay eoplepay eateryay", PigLatin.Translate("purple people eater"));
            Assert.Equal("irefay uckstray", PigLatin.Translate("fire trucks"));
        }

        [Fact]
        public void TranslatesYWords()
        {
            Assert.Equal("ellowyay", PigLatin.Translate("yellow"));
            Assert.Equal("ybay", PigLatin.Translate("by"));
            Assert.Equal("yphenatedhay", PigLatin.Translate("hyphenated"));
            Assert.Equal("ymay", PigLatin.Translate("my"));
        }

        [Fact]
        public void TranslatesAllConsonants()
        {
            Assert.Equal("rbrray", PigLatin.Translate("brrr"));
        }

        [Fact]
        public void TranslatesVowelWords()
        {
            Assert.Equal("applesyay", PigLatin.Translate("apples"));
            Assert.Equal("ofyay", PigLatin.Translate("of"));
        }

        [Fact]
        public void TranslatesBlanks()
        {
            Assert.Equal("", PigLatin.Translate(""));
        }
    }
}
