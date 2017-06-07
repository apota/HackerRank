using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://www.hackerrank.com/challenges/two-strings
/// </summary>
/// 
namespace HackerRank.Solutions.Strings
{
    public class TwoStrings
    {
        static string twoStrings(string s1, string s2)
        {
            // Complete this function
            HashSet<char> h1 = new HashSet<char>();
            HashSet<char> h2 = new HashSet<char>();
            char[] car1 = s1.ToCharArray();
            char[] car2 = s2.ToCharArray();
            for (int i = 0; i < car1.Length; ++i)
            {
                h1.Add(car1[i]);
            }
            for (int i = 0; i < car2.Length; ++i)
            {
                h2.Add(car2[i]);
            }

            return h1.Intersect(h2).Any() ? "YES" : "NO";
        }

        public static void Run()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                string result = twoStrings(s1, s2);
                Console.WriteLine(result);
            }
        }
    }
}
