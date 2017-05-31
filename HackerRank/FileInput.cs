using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class FileInput
    {

        public static int N { get; private set; }

        public static string[] InputLines { get; private set; }

        public static void FetchInput()
        {

            string[] filelines = System.IO.File.ReadAllLines(@"d:\exps\hacker_rank_input.txt");
            string[] parts = filelines[0].Split(' ');
            InputLines = new string[filelines.Length - 1];
            Array.Copy(filelines, 1, InputLines, 0, Convert.ToInt32(parts[1]));
            N = Convert.ToInt32(parts[0]);
        }


    }
}
