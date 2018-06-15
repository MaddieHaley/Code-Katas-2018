using Day4;
using Xunit;

namespace Day3
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
