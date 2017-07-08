using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Recursion.Crossword
{
    public class Crossword
    {

        public static void Run()
        {
            string[] filelines = System.IO.File.ReadAllLines(@"d:\exps\hacker_rank_input.txt");

            char[,] data = new char[10, 10];
            for (int i = 0; i < filelines.Length; ++i)
            {
                char[] arr = filelines[i].ToCharArray();
                for (int j = 0; j < arr.Length; ++j)
                {
                    data[i, j] = arr[j];
                }
            }


            List<string> words  = "AGRA;NORWAY;ENGLAND;GWALIOR".Split(';').ToList();
            Grid g = new Grid(data, words);

            g.Solve();

            Debug.WriteLine("");
            g.Print();


        }

    }

}
