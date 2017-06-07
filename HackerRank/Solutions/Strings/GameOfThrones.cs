using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://www.hackerrank.com/challenges/game-of-thrones/
/// </summary>

namespace HackerRank.Solutions.Strings
{
    public class GameOfThrones
    {

        public static void Run()
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                map[c] = 0;
            }
            string s = Console.ReadLine();
            using (CharEnumerator ce = s.GetEnumerator())
            {
                while (ce.MoveNext())
                {
                    map[ce.Current] += 1;
                }
            }
            Console.WriteLine(map.Where(x => x.Value % 2 != 0).Count() > 1 ? "NO" : "YES");

        }
    }
}
