using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Search
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// https://www.hackerrank.com/challenges/pairs
    /// </summary>
    class Solution
    {
        /* Head ends here */
        static int pairs(int[] a, int k)
        {
            int sum = 0;

            //Remove dups
            int[] d = a.Distinct().ToArray();
            //Sort so we know if that if the diff between i+1 and i is > k, there is no need to traverse the rest of the sorted array.
            Array.Sort(d);

            for (int i = 0; i < d.Length; ++i)
            {
                for (int j = i + 1; j < d.Length; ++j)
                {
                    int delta = d[j] - d[i];
                    sum = sum + (delta == k ? 1 : 0);
                    if (d[j] - d[i] >= k)
                    {
                        break;
                    }
                }
            }
            return sum;
        }
        /* Tail starts here */
        static void Run(String[] args)
        {
            int res;

            String line = Console.ReadLine();
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }

            res = pairs(_a, _k);
            Console.WriteLine(res);

        }
    }

}
