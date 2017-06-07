using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://www.hackerrank.com/challenges/pangrams
/// </summary>
namespace HackerRank.Solutions.Strings
{
    public class Pangrams
    {

        public static void Run()
        {

            string s = Console.ReadLine().Trim();

            HashSet<char> cset = new HashSet<char>();
            char[] carr = s.ToLower().ToCharArray();
            int k = carr.Length;

            for (int i = 0; i < k; ++i)
            {
                if (Char.IsLetter(carr[i]))
                {
                    cset.Add(carr[i]);
                }

            }

            Console.WriteLine(cset.Count == 26 ? "pangram" : "not pangram");
        }
    }
}
