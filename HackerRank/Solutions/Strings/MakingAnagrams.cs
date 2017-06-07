using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://www.hackerrank.com/challenges/making-anagrams/
/// </summary>
namespace HackerRank.Solutions.Strings
{
    public class MakingAnagrams
    {
        public static void Run()
        {
            string from = Console.ReadLine();
            string to = Console.ReadLine();

            //First get a map of <char, char count> for the strings provided. Only include chars with count > 0.
            Dictionary<char, int> fromMap = ToDictCount(from);
            Dictionary<char, int> toMap = ToDictCount(to);

            //Sum of the count of chars that are common to both strings. If the char 'c' appears 3 times in one string
            //twice in other string, then we need to have only |3-2| deletes to make them same..
            IEnumerable<char> commonChars = fromMap.Keys.Intersect(toMap.Keys);
            int deletes = 0;
            foreach (char cc in commonChars)
            {
                deletes += Math.Abs(toMap[cc] - fromMap[cc]);
            }

            //Sum up the count of all chars that are in fromMap but not in toMap
            deletes += SumIt(fromMap.Keys.Except(toMap.Keys), fromMap);
            //Sum up the count of all chars that are in toMap but not in fromMap
            deletes += SumIt(toMap.Keys.Except(fromMap.Keys), toMap);

            Console.WriteLine(deletes);
        }


        private static int SumIt(IEnumerable<char> enumerable, Dictionary<char, int> map)
        {
            int sum = 0;
            foreach (char cc in enumerable)
            {
                sum += map[cc];
            }
            return sum;
        }

        private static Dictionary<char, int> ToDictCount(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++) map[c] = 0;
            using (CharEnumerator ce = s.ToLower().GetEnumerator())
            {
                while (ce.MoveNext())
                {
                    map[ce.Current] += 1;
                }
            }
            return map.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
