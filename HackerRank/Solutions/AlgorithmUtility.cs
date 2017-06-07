using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions
{
    public static class AlgorithmUtility
    {
        /// <summary>
        /// Recusrively traverse a map of key value pairs to find "complete" relationships using depth first search.
 
        /// Assumption: values of the map are "related" to the corresponding map key. The values themselves can be keys to some other
        /// set of values (i.e. could have relations of their own). The purpose of this method is to unravel those relations starting from begin to finish and store them in a
        /// flattened map.
        /// 
        /// Data is assumed to NOT HAVE LOOPS! (no cyclical data checks made).  
        /// </summary>
        /// <param name="lines"></param>
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

    }
}
