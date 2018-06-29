using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace RomanNumeral___Day4
{
    public class Class1
    {
        [Fact]
        public void TranslatesToPigLatin()
        {
            Assert.Equal("MMMMCCCLII", Program.converter("4352"));
            Assert.Equal("MMMMMMMMDCCXLII", Program.converter("8742"));
            Assert.Equal("MMDXCV", Program.converter("2595"));
            Assert.Equal("4352", Program.converter("MMMMCCCLII"));
            Assert.Equal("8742", Program.converter("MMMMMMMMDCCXLII"));
            Assert.Equal("2595", Program.converter("MMDXCV"));
        }
    }
}
