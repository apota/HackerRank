using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// https://www.hackerrank.com/challenges/hackerrank-in-a-string/
/// </summary>
namespace HackerRank.Solutions.Strings
{
    public class HackerRankInString
    {

        public static void Run()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string s = Console.ReadLine();
                Regex r = new Regex(@"h\w*a\w*c\w*k\w*e\w*r\w*r\w*a\w*n\w*k");
                Console.WriteLine(r.Match(s).Success ? "YES" : "NO");
            }
        }
    }
}
