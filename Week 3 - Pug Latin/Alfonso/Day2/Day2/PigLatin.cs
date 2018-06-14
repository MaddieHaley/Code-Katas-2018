using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Day2
{
    public class PigLatin
    {
        [Fact]
        public void TranslatesToPigLatin()
        {
            Assert.Equal("ymay", Program.Translate("my"));
            Assert.Equal("awberrystray", Program.Translate("strawberry"));
            Assert.Equal("offeecay", Program.Translate("coffee"));
            Assert.Equal("urrayhay", Program.Translate("hurray"));
            Assert.Equal("adamyay", Program.Translate("adam"));
        }
    }
}
