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

            List<ConnectedCell> allCells = new List<ConnectedCell>();

            for (int i = 0; i < n; ++i)
            {
                string[] arr = lines[i].Split(' ');
                for (int j = 0; j < arr.Length; ++j)
                {
                    data[i, j] = Int32.Parse(arr[j]);
                }
            }

//            Debug.WriteLine(allCells.Count);
//
//            List<Region> regions = new List<Region>();
//            foreach (ConnectedCell cell in allCells)
//            {
//                Region reg = new Region();
//                reg.Add(cell);
//                regions.Add(reg);
//            }
//
//
//            int failureCounts = 0;
//            foreach (Region region in regions)
//            {
//                foreach (ConnectedCell cell in allCells)
//                {
//                    if (!region.Add(cell))
//                    {
//                        ++failureCounts;
//                    }
//                }
//            }
//         
//
//            Debug.WriteLine(regions.Max(x => x.Count));

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

    class ConnectedCell
    {
        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }

        private int _x, _y;

        public ConnectedCell(int i, int j)
        {
            _x = i;
            _y = j;
        }

        public bool IsAtDistanceOne(ConnectedCell that)
        {
            if (X == that.X - 1 && Y == that.Y) return true;
            if (X == that.X && Y == that.Y - 1) return true;
            if (X == that.X + 1 && Y == that.Y) return true;
            if (X == that.X && Y == that.Y + 1) return true;
            if (X == that.X - 1 && Y == that.Y - 1) return true;
            if (X == that.X + 1 && Y == that.Y +  1) return true;
            if (X == that.X + 1  && Y == that.Y - 1) return true;
            if (X == that.X - 1 && Y == that.Y + 1) return true;
            return false;
        }

    public override bool Equals(object obj)
        {
            ConnectedCell that = obj as ConnectedCell;            
            return that.X == this.X && that.Y == this.Y;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, Y);
        }
    }

    class Region
    {
        private HashSet<ConnectedCell> cells = new HashSet<ConnectedCell>();

        public int Count
        {
            get { return cells.Count; }
        }


        public bool Add(ConnectedCell newConnectedCell)
        {
            if (cells.Count == 0)
            {
                cells.Add(newConnectedCell);
                return true;
            }
            if (cells.Any(x => x.IsAtDistanceOne((newConnectedCell))))
            {
                cells.Add(newConnectedCell);
                return true;
            }
            
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ConnectedCell c in cells)
            {
                sb.Append(c).Append(" ");
            }
            return sb.ToString();
        }

        
        

    }


