using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Day2
{
    public class Test
    {
        [Fact]
        public void GetsRightWord()
        {
            Assert.Equal("ymay", Program.PigLatinWord("my"));
        }
    }
}
