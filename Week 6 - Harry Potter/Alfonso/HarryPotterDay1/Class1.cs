using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HarryPotterDay1;
namespace RomanNumeral___Day4
{
    public class Class1
    {
        [Fact]
        public void TranslatesToPigLatin()
        {
            Assert.Equal(30, Program.getPrice("book 1 book 2 book 3 book 4 book 5"));
            Assert.Equal(16, Program.getPrice("book 1 book 1"));
            Assert.Equal(15.2, Program.getPrice("book 2 book 3"));
            Assert.Equal(21.6, Program.getPrice("book 3 book 4 book 5"));
            
        }
    }
}
