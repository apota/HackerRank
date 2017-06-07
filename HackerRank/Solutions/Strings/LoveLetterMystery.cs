using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// https://www.hackerrank.com/challenges/the-love-letter-mystery
/// </summary>
namespace HackerRank.Solutions.Strings
{
    public class LoveLetterMystery
    {
        public static void Run()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string s = Console.ReadLine();
                char[] arr = s.ToCharArray();
                int length = arr.Length;

                int minimumOps = 0;
                for (int i = 0, j = length - 1; i < length; ++i, --j)
                {

                    if (i >= j) break;
                    minimumOps += Math.Abs((int)arr[i] - (int)arr[j]);
                }

                Console.WriteLine(minimumOps);
            }
        }
    }
}
