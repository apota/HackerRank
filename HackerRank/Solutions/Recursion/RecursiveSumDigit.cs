using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Recursion
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/recursive-digit-sum
    /// </summary>
    class RecursiveSumDigit
    {
        static void Run()
        {
            string[] arr = Console.ReadLine().Split(' ');
            string n = arr[0];
            int k = Int32.Parse(arr[1]);
            double sum = StringSum(n) * k;

            SuperDigit("" + sum);
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        }

        private static double StringSum(string s)
        {
            double sum = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                sum += Int32.Parse("" + s[i]);
            }
            return sum;
        }


        static void SuperDigit(string s)
        {
            if (s.Length == 1)
            {
                Console.WriteLine(s);
                return;
            }
            //int sum  = s.ToCharArray().ToList().Sum(x => Convert.ToInt32(x)); 
            SuperDigit("" + StringSum(s));


        }
    }
}
