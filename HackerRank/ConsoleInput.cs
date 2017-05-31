using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    
        /// Standard HackerRank input. 
        /// 
        /// 
        public class ConsoleInput
    {
        public static int N { get; private set; }

        public static string[] InputLines { get; private set; }

        public static void FetchInput()
        {
            string s = Console.ReadLine();
            string[] parts = s.Split(' ');
            N = Convert.ToInt32(parts[0]);
            int totalLines = Convert.ToInt32(parts[1]);

            List<string> llines = new List<string>();
            for (int i = 0; i < totalLines; ++i)
            {
                llines.Add(Console.ReadLine());
            }

            InputLines = llines.ToArray<string>();

        }

    }
}
