using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions
{
    public static class AlgorithmUtility
    {
        #region Dictionary stuff
        public static Dictionary<string, HashSet<string>> BuildCompleteRelationsMap(Dictionary<string, HashSet<string>> rawMap)
        {
            Dictionary<string, HashSet<string>> resultMap = new Dictionary<string, HashSet<string>>();
            ProcessMap(rawMap, resultMap);
            return resultMap;
        }

        private static void ProcessMap(Dictionary<string, HashSet<string>> map, Dictionary<string, HashSet<string>> sumMap)
        {

            foreach (KeyValuePair<string, HashSet<string>> entry in map)
            {
                string key = entry.Key;
                HashSet<string> children = map[key];
                foreach (string s in children)
                {
                    Add2Map(sumMap, key, s);
                    ProcessMapInner(map, key, s, sumMap);
                }
            }
        }

        public static void Add2Map(Dictionary<string, HashSet<string>> map, string key, string value)
        {
            HashSet<string> values;
            if (map.ContainsKey(key))
            {
                values = map[key];
            }
            else
            {

                values = new HashSet<string>();
            }
            values.Add(value);
            map[key] = values;
        }

        public static void Add2Map(Dictionary<string, List<string>> map, string key, string value)
        {
            List<string> values;
            if (map.ContainsKey(key))
            {
                values = map[key];
            }
            else
            {

                values = new List<string>();
            }
            values.Add(value);
            map[key] = values;
        }

        private static void ProcessMapInner(Dictionary<string, HashSet<string>> map, string parent, string child, Dictionary<string, HashSet<string>> sumMap)
        {
            if (map.ContainsKey(child))
            {

                HashSet<string> children = map[child];
                foreach (string ss in children)
                {
                    Add2Map(sumMap, parent, ss);
                    ProcessMapInner(map, parent, ss, sumMap);
                }
            }

        }

        #endregion


        #region Printing 

        public static string ToString(IEnumerable<string> h, string delim = null)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in h)
            {
                sb.Append(s).Append(delim != null ? delim : " ");
            }
            return sb.ToString();
        }
        public static string ToString(List<int> h)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int s in h)
            {
                sb.Append(s).Append(" ");
            }
            return sb.ToString();
        }

        #endregion

        #region String ops

        public static bool IsAnagram(string a, string b)
        {
            if (a.Length != b.Length) return false;

            char[] aarr = a.ToCharArray();
            char[] barr = b.ToCharArray();
            Array.Sort(aarr);
            Array.Sort(barr);


            for (int i = 0; i < aarr.Length; ++i)
            {
                if (aarr[i] != barr[i]) return false;
            }

            return true;

        }

        public static int EditDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        #endregion


        #region Combinatorics 


        public static List<List<T>> Permutations<T>(List<T> list)
        {
            List<List<T>> result = new List<List<T>>();
            if (list.Count == 1)
            { // If only one possible permutation
                result.Add(list); // Add it and return it
                return result;
            }
            foreach (T element in list)
            { // For each element in that list
                var remainingList = new List<T>(list);
                remainingList.Remove(element); // Get a list containing everything except of chosen element
                foreach (List<T> permutation in Permutations<T>(remainingList))
                { // Get all possible sub-permutations
                    permutation.Add(element); // Add that element
                    result.Add(permutation);
                }
            }
            return result;
        }

      
        #endregion




    }
}
