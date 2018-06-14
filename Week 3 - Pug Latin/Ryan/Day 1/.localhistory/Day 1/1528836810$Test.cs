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
            {"welcome", "ellcomeway"},
            { "how are you", "owhay arehay ouyay" },
            { "pig", "igpay"},
            { "latin", "atinlay"},
            { "banana", "ananabay"},
            { "cheers", "eerschay"},
            { "shesh", "eshshay"},
            { "smile", "ilesmay" },
            {"every", "eryevay"},
            { "omelet", "eletomay"},
            { "another", "otheranay" }
        };

        [Test]
        public void TestTranslation()
        {
            foreach (var pair in PigLatinTranslations)
            {
                Assert.AreEqual(Program.PigLatinTranslator(pair.Key), pair.Value);
            }
        }
    }
}
