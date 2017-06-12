using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Graph
{
    public class Edge
    {

        public Edge(string source, string dest, int distance)
        {
            Source = source;
            Destination = dest;
            Distance = distance;
        }


        public string Source { get; private set; }
        public string Destination { get; private set; }
        public int Distance { get; private set; }
    }
}
