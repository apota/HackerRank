using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Recursion.Crossword
{

    /// <summary>
    /// https://www.hackerrank.com/challenges/crossword-puzzle
    /// 
    /// 
    /// Given a grid with empty spaces (Slots). Make all permutatioms of the input word list and try to "fit" these word combos
    /// into the slots.
    /// 
    /// A word fits into a slot 
    ///     1. if its the same length as the slot
    ///     2. if its in a slot that intersects with another slot then the word on the intersecting slot share a common character.
    /// </summary>
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


            List<string> words  = "CALIFORNIA;LASVEGAS;NIGERIA;CANADA;TELAVIV;ALASKA".Split(';').ToList();
            Grid g = new Grid(data, words);

            g.Solve();

            Debug.WriteLine("");
            g.Print();


        }

    }

}
