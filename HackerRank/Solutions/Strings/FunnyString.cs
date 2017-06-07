using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 
/// https://www.hackerrank.com/challenges/funny-string/
/// </summary>
/// 
namespace HackerRank.Solutions.Strings
{
    public class FunnyString
    {
        public static void RUn()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string s = Console.ReadLine();
                char[] arr = s.ToCharArray();

                int length = arr.Length;

                StringBuilder fsb = new StringBuilder();
                StringBuilder bsb = new StringBuilder();

                for (int i = 0, j = length - 1; j > 0; ++i, --j)
                {
                    fsb.Append(Math.Abs(arr[i] - arr[i + 1]).ToString());
                    bsb.Append(Math.Abs(arr[j] - arr[j - 1]).ToString());
                }

                Console.WriteLine(fsb.Equals(bsb) ? "Funny" : "Not Funny");
            }

            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        }
    }
}
