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
        public void Should_Translate_To_Pig_Latin()
        {
            Assert.Equal("ymay",                       PigLatin.Translate("my")                 );
            Assert.Equal("esttay",                     PigLatin.Translate("test")               );
            Assert.Equal("atinlay",                    PigLatin.Translate("latin")              );
            Assert.Equal("rbrray",                     PigLatin.Translate("brrr")               );
            Assert.Equal("applesyay",                  PigLatin.Translate("apples")             );
            Assert.Equal("ofyay",                      PigLatin.Translate("of")                 );
            Assert.Equal("irefay uckstray",            PigLatin.Translate("fire trucks")        );
            Assert.Equal("andalfgay",                  PigLatin.Translate("gandalf")            );
            Assert.Equal("urrayhay",                   PigLatin.Translate("hurray")             );
            Assert.Equal("ondolagay",                  PigLatin.Translate("gondola")            );
            Assert.Equal("yphenatedhay",               PigLatin.Translate("hyphenated")         );
            Assert.Equal("urplepay eoplepay eateryay", PigLatin.Translate("purple people eater"));
            Assert.Equal("ybay",                       PigLatin.Translate("by")                 );
        }
    }
}
