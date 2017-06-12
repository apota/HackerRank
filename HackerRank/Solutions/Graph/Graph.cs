using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Graph
{
    public class Graph
    {

        public List<Edge> Edges { get; private set; }
        public List<string> Vertices { get; private set; }

        private Dictionary<string, double> shortestDistances;

        public Graph(List<Edge> edges, List<string> vertices)
        {
            Edges = edges;
            Vertices = vertices;
            shortestDistances = new Dictionary<string, double>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceVertex">Vertex to calculate the path from</param>
        /// <param name="destinationVertex">Vertex to calculate the path to</param>
        /// <param name="shortestDistances">Map of vertices and their shortest distances to them</param>
        /// <param name="shortestPaths">Map of vertices and the node leading to them in a shortest path</param>
        public void  Djkistra(string sourceVertex, string destinationVertex, out Dictionary<string, double> shortestDistances, out Dictionary<string, string> shortestPaths)
        {
            List<string> queue = new List<string>();
            shortestDistances = new Dictionary<string, double>();
            shortestPaths = new Dictionary<string, string>();

            foreach (var v in Vertices)
            {
                shortestDistances.Add(v, Int32.MaxValue);
                shortestPaths.Add(v, null);
                queue.Add(v);
            }

            shortestDistances[sourceVertex] = 0;
            while (queue.Count != 0)
            {

                var t = this.shortestDistances.Where(p => queue.Contains(p.Key));
                double min = t.Min(p => p.Value);
                string u = t.Where(p => p.Value == min).Select(p => p.Key).First();
                queue.Remove(u);
                List<Edge> nearbyEdges = Edges.Where(p => p.Source == u && queue.Contains(p.Destination)).ToList();
                foreach (var edge in nearbyEdges)
                {
                    double alt = edge.Distance + this.shortestDistances[u];
                    if (alt < this.shortestDistances[edge.Destination])
                    {
                        this.shortestDistances[edge.Destination] = alt;
                        shortestPaths[edge.Destination] = u;
                    }
                }
            }
        }
    }


    
}
