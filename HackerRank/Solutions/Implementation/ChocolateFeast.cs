using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// https://www.hackerrank.com/challenges/chocolate-feast
    /// </summary>
    class Solution
    {

        static void Run(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int c = Convert.ToInt32(tokens_n[1]);
                int m = Convert.ToInt32(tokens_n[2]);
                double answer = 0;
                double wrappersLeft = 0;
                Solve(n, c, m, ref wrappersLeft, ref answer);
                Console.WriteLine(answer);
            }

        }

        private static void Solve(double moneyLeft, double cost, double wrappersPerChoco, ref double wrappersLeft, ref double answer)
        {


            if (moneyLeft >= cost)
            {
                double chocos = Math.Floor(moneyLeft / cost);
                answer += chocos;
                double wrapperBasedChocos = Math.Floor(chocos / wrappersPerChoco);
                answer += wrapperBasedChocos;
                wrappersLeft = chocos - (wrapperBasedChocos * wrappersPerChoco) + wrapperBasedChocos;
                double dollaLeft = Math.Max(0, moneyLeft - (chocos * cost));
                Solve(dollaLeft, cost, wrappersPerChoco, ref wrappersLeft, ref answer);
            }
            else
            {
                if (wrappersLeft >= wrappersPerChoco)
                {
                    double wrapperBasedChocos = Math.Floor(wrappersLeft / wrappersPerChoco);
                    answer += wrapperBasedChocos;
                    wrappersLeft = wrappersLeft - (wrapperBasedChocos * wrappersPerChoco) + wrapperBasedChocos;
                    Solve(0, cost, wrappersPerChoco, ref wrappersLeft, ref answer);
                }
            }

        }
    }

}
