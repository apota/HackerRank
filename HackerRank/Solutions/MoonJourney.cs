using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions
{

    /// <summary>
    /// https://www.hackerrank.com/challenges/journey-to-the-moon
    /// </summary>
    public class MoonJourney
    {
        public static void Run(int n, string[] inputLines)
        {
            double sum = 0;
            Dictionary<string, HashSet<string>> rawMap = BuildRawMap(inputLines);
            List<HashSet<string>> depthFirstSearchList = new List<HashSet<string>>();

            Dictionary<string, HashSet<string>> depthFirstSearchMap =
                AlgorithmUtility.BuildCompleteRelationsMap(rawMap);

       
            foreach (var entry in depthFirstSearchMap)
            {
                HashSet<string> h = new HashSet<string>();
                h.Add(entry.Key);
                var values = depthFirstSearchMap[entry.Key];
                foreach (var s in values) h.Add(s);
                //h.UnionWith(sumMap[entry.Key]);  -- UnionWith is slower
                depthFirstSearchList.Add(h);
            }

            Sort(depthFirstSearchList);
            while (!AreAllSetsDisJointed(depthFirstSearchList))
            {
                Reduce(depthFirstSearchList);
                depthFirstSearchList = depthFirstSearchList.Where(x => x.Count > 0).ToList<HashSet<string>>();
            }

            List<HashSet<string>> finals = depthFirstSearchList.Where(x => x.Count > 0).ToList<HashSet<string>>();
            List<int> cc = finals.Select(x => x.Count()).ToList<int>();
            for (int i = 0; i < cc.Count(); ++i)
            {
                for (int j = i + 1; j < cc.Count(); ++j)
                {
                    if (i != j)
                    {
                        sum += cc[i] * cc[j];
                    }
                }
            }
            double remain = Math.Max(0, n - finals.Sum(x => x.Count()));

            for (int i = 0; i < cc.Count(); ++i)
            {
                sum += cc[i] * remain;
            }
            sum += (remain * (remain - 1)) / 2;

            Console.WriteLine(sum);
            Debug.WriteLine(sum);

        }

        private static void Reduce(List<HashSet<string>> mapList)
        {
            for (int i = 0; i < mapList.Count(); ++i)
            {
                HashSet<string> src = mapList[i];
                for (int j = 0; j < mapList.Count(); ++j)
                {
                    HashSet<string> dest = mapList[j];

                    if (i != j && src.Overlaps(dest))
                    {
                        if (src.Count >= dest.Count)
                        {
                            dest.RemoveWhere(x => src.Contains(x));
                            foreach (var s in dest) src.Add(s);
                            //src.UnionWith(dest); UnionWith is slower
                            dest.Clear();
                        }
                        else
                        {
                            src.RemoveWhere(x => dest.Contains(x));
                            foreach (var s in src) dest.Add(s);
                            //dest.UnionWith(src);  UnionWith is slower
                            src.Clear();
                        }
                    }
                }
            }
        }


        private static bool AreAllSetsDisJointed(IList<HashSet<string>> finals)
        {

            for (int i = 0; i < finals.Count; ++i)
            {
                for (int j = 0; j < finals.Count; ++j)
                {
                    if (i != j)
                    {

                        if (finals[i].Overlaps(finals[j]))
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }




        private static void Sort(List<HashSet<string>> dfs)
        {

            dfs.Sort(delegate (HashSet<string> x, HashSet<string> y)
            {
                if (x.Count() == y.Count()) return 0;
                else if (x.Count() < y.Count()) return 1;
                else if (x.Count() > y.Count()) return -1;
                return 0;
            });

        }

    
        private static Dictionary<string, HashSet<string>> BuildRawMap(string[] lines)
        {

            Dictionary<string, HashSet<string>> map = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < lines.Length; ++i)
            {
                string[] members = lines[i].Split(' ');
                AlgorithmUtility.Add2Map(map, members[0], members[1]);
            }

            return map;

        }

    }
}
