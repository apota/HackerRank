using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// https://www.hackerrank.com/challenges/camelcase/
/// </summary>
namespace HackerRank.Solutions.Strings
{
    public class CamelCase
    {

        public static void Run()
        {
            string s = Console.ReadLine();
            int sLength = s.Length;

            Regex pattern = new Regex("[A-Z]{1}([a-z]+)");

            Match m = pattern.Match(s);

            int wordCount = 0;
            int matchLength = 0;

            while (m.Success)
            {

                ++wordCount;
                matchLength += m.Length;
                m = m.NextMatch();
            }

            if (matchLength < sLength) wordCount += 1;

            Console.WriteLine(wordCount);

        }
    }
}
