using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Graph
{
    public class Graph
    {

        public List<Edge> Edges { get; private set; }
        public List<string> Vertices { get; private set; }

        
        public Graph(List<Edge> edges, List<string> vertices)
        {
            Edges = edges;
            Vertices = vertices;
        }


        /// <summary>
        /// Given a source vertex find the shortest distance and paths to all other vertices
        /// </summary>
        /// <param name="sourceVertex">Vertex to calculate the path from</param>
        /// <param name="shortestDistances">Map of vertices and their shortest distances to them</param>
        /// <param name="shortestPaths">Map of vertices and the node leading to them in a shortest path</param>
        public void  Djkistra(string sourceVertex, out Dictionary<string, double> shortestDistances, out Dictionary<string, string> shortestPaths)
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

                var t = shortestDistances.Where(p => queue.Contains(p.Key));
                double min = t.Min(p => p.Value);
                string u = t.Where(p => p.Value == min).Select(p => p.Key).First();
                queue.Remove(u);
                List<Edge> nearbyEdges = Edges.Where(p => p.Source == u && queue.Contains(p.Destination)).ToList();
                foreach (var edge in nearbyEdges)
                {
                    double alt = CalcDistance(edge, u, shortestDistances);
                    if (alt < shortestDistances[edge.Destination])
                    {
                        shortestDistances[edge.Destination] = alt;
                        shortestPaths[edge.Destination] = u;
                    }
                }
            }
        }

        /// <summary>
        /// Given source and destination vertex find the shortest path and distance.
        /// </summary>
        /// <param name="sourceVertex"></param>
        /// <param name="destinationVertex"></param>
        /// <param name="shortestDistance"></param>
        /// <param name="shortestPath"></param>
        public void Djkistra(string sourceVertex, string destinationVertex, out double? shortestDistance, out List<string> shortestPath)
        {
            Dictionary<string, double> shortestDistances = new Dictionary<string, double>();
            Dictionary<string, string> shortestPaths = new Dictionary<string, string>();

            Djkistra(sourceVertex, out shortestDistances, out shortestPaths);

            shortestDistance = shortestDistances[destinationVertex];

            shortestPath = new List<string>();
            string s = destinationVertex;
            while (s != null && shortestPaths.ContainsKey(s))
            {
                shortestPath.Add(s);
                s = shortestPaths[s];
            }
            shortestPath.Reverse();
        }




        protected virtual double CalcDistance(Edge edge, string currentVertex, Dictionary<string, double> shortestDistances)
        {
            return edge.Distance + shortestDistances[currentVertex];
        }
    }


    
}
