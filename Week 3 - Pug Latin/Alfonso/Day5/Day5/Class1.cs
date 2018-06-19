using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Day5
{
    public class PigLatin
    {
        [Fact]
        public void TranslatesToPigLatin()
        {
            Assert.Equal("awberrystray", Program.PigLatin("strawberry"));
            Assert.Equal("offeecay", Program.PigLatin("coffee"));
            Assert.Equal("adamyay", Program.PigLatin("adam"));
        }
    }
}
