using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // My code
    static int birthdayCakeCandles(int[] ar) {
        int max = 0;
        int maxCount = 0;

        foreach (int candleHeight in ar) {
            if(candleHeight > max) {
                max = candleHeight;
                maxCount = 1;
            }
            else if(candleHeight == max) {
                maxCount++;
            }
        }

        return maxCount;
    }

    static void Main(string[] args) {

        int arCount = Convert.ToInt32(Console.ReadLine());

        int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

        int result = birthdayCakeCandles(ar);

        Console.WriteLine(result);
        
        /* For HackerRank IO (set OUTPUT_PATH for local use)
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
        */
    }
}