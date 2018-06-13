using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Day_1
{
    [TestFixture]
    class Test
    {
        public static readonly Dictionary<string, string> PigLatinTranslations = new Dictionary<string, string>
        {
            {"Welcome", "Ellcomeway"},
            { "How are you", "Owhay arehay ouyay" },
            { "pig", "igpay"},
            { "latin", "atinlay"},
            { "banana", "ananabay"},
            {"cheers", "eerschay"},
            { "shesh", "eshshay"},
            { "smile", "ilesmay" },
            {"every", "eryevay"},
            { "omelet", "eletomay"},
            { "another", "otheranay" }
        };

        [Test]
        public void TestTranslation()
        {
            Assert.AreEqual(Program.PigLatinTranslator("hello world"), "ellohay orldway");
            Assert.AreEqual(Program.PigLatinTranslator(""));
        }
    }
}
