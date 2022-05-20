using System;
using System.Collections.Generic;

namespace Number_of_Connected_Components_in_an_Undirected_Graph
{
  class Program
  {
    static void Main(string[] args)
    {
      int n = 5;
      int[][] edges = new int[4][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } };
      Program p = new Program();
      var result = p.countComponents(n, edges);
      Console.WriteLine(result);
    }

    public int countComponents(int n, int[][] edges)
    {
      Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
      for (int i = 0; i < n; i++)
      {
        adj.Add(i, new List<int>());
      }

      foreach (var edge in edges)
      {
        int src = edge[0];
        int dest = edge[1];
        adj[src].Add(dest);
        adj[dest].Add(src);
      }

      int count = 0;
      bool[] visited = new bool[n];
      for (int i = 0; i < n; i++)
      {
        if (!visited[i])
        {
          count++;
          DFS(adj, visited, i);
        }
      }


      return count;
    }

    private void DFS(Dictionary<int, List<int>> adj, bool[] visited, int node)
    {
      visited[node] = true;
      foreach(var next in adj[node])
      {
        if (!visited[next])
          DFS(adj, visited, next);
      }
    }
  }
}
