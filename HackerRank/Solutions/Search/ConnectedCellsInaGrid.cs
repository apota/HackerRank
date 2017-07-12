using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HackerRank.Solutions.Search
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/connected-cell-in-a-grid
    /// </summary>
    public class ConnectedCellsInaGrid
    {

        public static void Run()
        {


            string[] filelines = System.IO.File.ReadAllLines(@"d:\exps\hacker_rank_input.txt");

            int[,] data = new int[7, 8];
            for (int i = 0; i < filelines.Length; ++i)
            {
                string[] arr = filelines[i].Split(' ');
                for (int j = 0; j < arr.Length; ++j)
                {
                    data[i, j] = Int32.Parse(arr[j]);
                }
            }

            int currentCount = 0;
            int maxCount = 0;


            Traverse(data, 0, 0, ref currentCount, ref maxCount, new HashSet<string>());

            Debug.WriteLine(maxCount);
        }


        private static void Traverse(int[,] data, int i, int j, ref int currentCount, ref int maxCount, HashSet<string> visited)
        {
            if (!visited.Add(i + " " + j) || i > data.GetLength(0) || j > data.GetLength(1) || i < 0 || j < 0)
            {
                return;
            }
            ++currentCount;
            maxCount = Math.Max(maxCount, currentCount);

            //Check boundary conditions
            if (data[i + 1, j] == 1)
            {
                Traverse(data, i + 1, j, ref currentCount, ref maxCount, visited);
            }

            if (j + 1 < data.GetLength(1) && data[i, j + 1] == 1)
            {
                Traverse(data, i, j + 1, ref currentCount, ref maxCount, visited);
            }
            if (i + 1 < data.GetLength(0) && j + 1 < data.GetLength(1) && data[i + 1, j + 1] == 1)
            {
                Traverse(data, i + 1, j + 1, ref currentCount, ref maxCount, visited);
            }
            if (i - 1 >= 0 && data[i - 1, j] == 1)
            {
                Traverse(data, i - 1, j, ref currentCount, ref maxCount, visited);
            }
            if (j - 1 >= 0 && data[i, j - 1] == 1)
            {
                Traverse(data, i, j - 1, ref currentCount, ref maxCount, visited);
            }
            if (i - 1 >= 0 && j - 1 >= 0 && data[i - 1, j - 1] == 1)
            {
                Traverse(data, i - 1, j - 1, ref currentCount, ref maxCount, visited);
            }
            if (i + 1 < data.GetLength(0) && j - 1 >= 0 && data[i + 1, j - 1] == 1)
            {
                Traverse(data, i + 1, j - 1, ref currentCount, ref maxCount, visited);
            }
            if (i - 1 >= 0 && j + 1 < data.GetLength(1) && data[i - 1, j + 1] == 1)
            {
                Traverse(data, i - 1, j + 1, ref currentCount, ref maxCount, visited);
            }
        }
    }
}
