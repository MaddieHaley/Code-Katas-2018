using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Day3
{
    public class PigLatin
    {
        [Fact]
        public void TranslatesToPigLatin()
        {
            Assert.Equal("one hundred ninety-two thousand ", Program.Translate("192000"));
            Assert.Equal("thirty-four million nine hundred eighty-seven thousand three hundred twenty-one", Program.Translate("34987321"));
            Assert.Equal("34987321", Program.Translate("thirty-four million nine hundred eighty-seven thousand three hundred twenty-one"));
            Assert.Equal("192000", Program.Translate("one hundred ninety-two thousand"));
        }
    }
}
