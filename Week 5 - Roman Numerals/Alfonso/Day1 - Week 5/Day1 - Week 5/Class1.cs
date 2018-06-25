using Day1___Week_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Day1
{
    public class PigLatin
    {
        [Fact]
        public void TranslatesToPigLatin()
        {
            Assert.Equal("MMMMCCCLII", Program.Translate(4352));
            Assert.Equal("MMMMMMMMDCCXLII", Program.Translate(8742));
            Assert.Equal("MMDXCV", Program.Translate(2595));
        }
    }
}
