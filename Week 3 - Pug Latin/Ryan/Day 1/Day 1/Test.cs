﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Day_1
{
    public class Test
    {
        public static readonly Dictionary<string, string> PigLatinTranslations = new Dictionary<string, string>
        {
            { "welcome", "ellcomeway"},
            { "how are you", "owhay areyay ouyay" },
            { "pig", "igpay"},
            { "latin", "atinlay"},
            { "banana", "ananabay"},
            { "cheers", "eerschay"},
            { "shesh", "eshshay"},
            { "smile", "ilesmay" },
            { "every", "eryeyay"},
            { "omelet", "eletoyay"},
            { "another", "anotheryay" }
        };

        [Fact]
        public void TestTranslation()
        {
            foreach (var pair in PigLatinTranslations)
            {
                Assert.Equal(Program.PigLatinTranslator(pair.Key), pair.Value);
            }
        }
    }
}