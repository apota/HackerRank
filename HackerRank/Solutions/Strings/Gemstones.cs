using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// https://www.hackerrank.com/challenges/gem-stones
/// </summary>
public class Gemstones
{

    static int gemstones(string[] arr)
    {
        HashSet<char> result = new HashSet<char>();
        List<HashSet<char>> elems = new List<HashSet<char>>();

        foreach (string s in arr)
        {
            elems.Add(new HashSet<char>(s.ToCharArray()));
        }

        foreach (var elem in elems)
        {
            result.UnionWith(elem);
        }
        foreach (var elem in elems)
        {
            result.IntersectWith(elem);
        }

        return result.Count();

        // Complete this function
    }

    public static void Run()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr = new string[n];
        for (int arr_i = 0; arr_i < n; arr_i++)
        {
            arr[arr_i] = Console.ReadLine();
        }
        int result = gemstones(arr);
        Console.WriteLine(result);
    }
}
