using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Search
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/connected-cell-in-a-grid
    /// </summary>
    public class ConnectedGridRegion
    {

        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@"d:\exps\hacker_rank_input.txt");


            int n = lines.Length;
     
            int[,] data  = new int[n,lines[0].Split(' ').Length];


            for (int i = 0; i < n; ++i)
            {
                string[] arr = lines[i].Split(' ');
                for (int j = 0; j < arr.Length; ++j)
                {
                    data[i, j] = Int32.Parse(arr[j]);
                }
            }

            int globalMax = 0;
            for (int i = 0; i < data.GetLength(0); ++i)
            {
               
                for (int j = 0; j < data.GetLength(1); ++j)
                {
                    int ct = 0;
                    int max = 0;
                    Traverse(data, i, j, ref ct, ref max, new HashSet<string>());
                    globalMax = Math.Max(max, globalMax);
                }

            }

            Debug.WriteLine(globalMax);
        }


        private static void Traverse(int[,] data, int i, int j, ref int ct, ref int max, HashSet<string> visited)
        {
            if (!visited.Add(i + " " + j))
            {
                return;
            }

            if (data[i, j] == 1)
            {
                ++ct;
                max = Math.Max(ct, max);
            }
            else
            {
                return;
            }

            if (i + 1 < data.GetLength(0))
            {
                Traverse(data, i + 1, j, ref ct, ref max, visited);
            }

            if (j + 1 < data.GetLength(1))
            {
                Traverse(data, i, j + 1, ref ct, ref max, visited);
            }
            if (j - 1 >= 0)
            {
                Traverse(data, i, j - 1, ref ct, ref max, visited);
            }
            if (i - 1 >= 0)
            {
                Traverse(data, i - 1, j, ref ct, ref max, visited);
            }
            if (i + 1 < data.GetLength(0) && j + 1 < data.GetLength(1))
            {
                Traverse(data, i + 1, j + 1, ref ct, ref max, visited);
            }
            if (i - 1 >= 0 && j - 1 >= 0)
            {
                Traverse(data, i - 1, j - 1, ref ct, ref max, visited);
            }
            if (i - 1 >= 0 && j + 1 < data.GetLength(1))
            {
                Traverse(data, i - 1, j + 1, ref ct, ref max, visited);
            }
            if (i + 1 < data.GetLength(0) && j - 1 >= 0)
            {
                Traverse(data, i + 1, j - 1, ref ct, ref max, visited);
            }


        }
    }
    }

   


