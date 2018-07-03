using HarryPotterDay2;
using Xunit;
namespace HarryPotterDay2
{
    public class Class1
    {
        [Fact]
        public void getsPriceofHarryPotter()
        {
            Assert.Equal(30, Program.GetPrice("book 1 book 2 book 3 book 4 book 5"));
            Assert.Equal(15.2, Program.GetPrice("book 2 book 3"));
            Assert.Equal(21.6, Program.GetPrice("book 3 book 4 book 5"));

        }
    }
}
