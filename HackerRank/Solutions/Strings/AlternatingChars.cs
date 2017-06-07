using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// https://www.hackerrank.com/challenges/alternating-characters
/// </summary>
namespace HackerRank.Solutions.Strings
{
    public class AlternatingChars
    {

        public static void Run()
        {
            int numLines = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numLines; ++i)
            {
                PrintMin(Console.ReadLine());
            }
        }

        private static void PrintMin(string s)
        {
            char[] arr = s.ToCharArray();
            int todelete = 0;
            int i = 0;
            while (true)
            {
                if (i >= arr.Length) break;
                char current = arr[i];
                if (i + 1 < arr.Length)
                {
                    char next = arr[i + 1];
                    if (current == next)
                    {
                        ++todelete;
                    }
                }

                ++i;
            }
            Console.WriteLine(todelete);
        }

    }
}
