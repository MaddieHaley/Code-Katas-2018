using Day2;
using Xunit;

namespace Day3
{
    public class PigLatin
    {
        [Fact]
        public void TranslatesToPigLatin()
        {
            Assert.Equal("awberrystray", Program.Translate("strawberry"));
            Assert.Equal("offeecay", Program.Translate("coffee"));
            Assert.Equal("adamyay", Program.Translate("adam"));
        }
    }
}
