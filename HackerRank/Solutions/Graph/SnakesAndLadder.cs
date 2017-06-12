using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// https://www.hackerrank.com/challenges/the-quickest-way-up
/// </summary>
namespace HackerRank.Solutions.Graph
{
    public class SnakesAndLadder
    {

        public static void Run()
        {


            List<string> vertices = new List<string>();
            for (int i = 1; i <= 100; ++i)
            {
                vertices.Add("" + i);
            }

            List<Edge> edges = new List<Edge>();

            int ladders = Convert.ToInt32(Console.ReadLine());
            HashSet<string> specialVertices = new HashSet<string>();
            for (int i = 0; i < ladders; ++i)
            {
                string[] arr = Console.ReadLine().Split(' ');
                specialVertices.Add(arr[0]);
                edges.Add(new Edge(arr[0], arr[1], 0));
            }
            int snakes = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < snakes; ++i)
            {
                string[] arr = Console.ReadLine().Split(' ');
                specialVertices.Add(arr[0]);
                edges.Add(new Edge(arr[0], arr[1], 0));
            }

            for (int i = 1; i <= 94; ++i)
            {
                for (int j = 1; j <= 6; ++j)
                {
                    if (!specialVertices.Contains("" + i)) edges.Add(new Edge("" + i, "" + (i + j), 1));
                }
            }


            for (int i = 95; i <= 100; ++i)
            {
                for (int j = 1; j <= 100 - i; ++j)
                {
                    if (!specialVertices.Contains("" + i)) edges.Add(new Edge("" + i, "" + (i + j), 1));
                }
            }



          

            Graph g = new Graph();
            g.edges = edges;
            g.vertices = vertices;

            g.doit();

        }

    }

    class Edge
    {

        public string dest;
        public string src;
        public int w;

        public Edge(string src, string dest, int w)
        {
            this.src = src;
            this.dest = dest;
            this.w = w;
        }

    }

    class Graph
    {

        public List<string> vertices;
        public List<Edge> edges;


        public void doit()
        {
            List<string> Q = new List<string>();
            Dictionary<string, int> dist = new Dictionary<string, int>();
            Dictionary<string, string> prev = new Dictionary<string, string>();

            foreach (var v in vertices)
            {
                dist.Add(v, Int32.MaxValue);
                prev.Add(v, null);
                Q.Add(v);
            }

            dist["1"] = 0;
            while (Q.Count != 0)
            {

                var t = dist.Where(p => Q.Contains(p.Key));
                int min = t.Min(p => p.Value);
                string u = t.Where(p => p.Value == min).Select(p => p.Key).First();
                Q.Remove(u);
               /// Debug.WriteLine("Solving " + u);
                List<Edge> nearbyEdges = edges.Where(p => p.src == u && Q.Contains(p.dest)).ToList();
                foreach (var edge in nearbyEdges)
                {
                    int alt = edge.w + dist[u];
                    if (alt < dist[edge.dest])
                    {
                        dist[edge.dest] = alt;  
                        prev[edge.dest] = u;
                    }
                }

            }
            Debug.WriteLine(dist["100"]  == Int32.MaxValue ? -1 : dist["100"]);
        }

    }


}
