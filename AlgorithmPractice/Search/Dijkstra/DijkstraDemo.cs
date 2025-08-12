using System;
using System.Collections.Generic;

class DijkstraDemo
{
    public class Edge
    {
        public int To;
        public int Weight;
        public Edge(int to, int weight)
        {
            To = to;
            Weight = weight;
        }
    }

    //static void Main()
    //{
    //    int n = 5;
    //    List<Edge>[] graph = new List<Edge>[n];
    //    for (int i = 0; i < n; i++)
    //        graph[i] = new List<Edge>();

    //    graph[0].Add(new Edge(1, 2));
    //    graph[0].Add(new Edge(2, 4));
    //    graph[1].Add(new Edge(2, 1));
    //    graph[1].Add(new Edge(3, 7));
    //    graph[2].Add(new Edge(4, 3));
    //    graph[3].Add(new Edge(4, 1));

    //    int start = 0;
    //    int[] dist = myDi(graph, start);

    //    Console.WriteLine("최단 거리 결과:");
    //    for (int i = 0; i < n; i++)
    //    {
    //        Console.WriteLine($"{start} -> {i} : {dist[i]}");
    //    }
    //}

    static int[] Dijkstra(List<Edge>[] graph, int start)
    {
        int n = graph.Length;
        int[] dist = new int[n];
        for (int i = 0; i < n; i++)
            dist[i] = int.MaxValue;
        dist[start] = 0;

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int current, out int currentDist);

            if (currentDist > dist[current])
                continue;

            foreach (var edge in graph[current])
            {
                int next = edge.To;
                int cost = dist[current] + edge.Weight;
                if (cost < dist[next])
                {
                    dist[next] = cost;
                    pq.Enqueue(next, cost);
                }
            }
        }
        return dist;
    }


    static int[] myDi(List<Edge>[] graph, int start)
    {
        int n = graph.Length;
        int[] dist = new int[n];

        for (int i = 0; i < dist.Length; i++)
        {
            dist[i] = int.MaxValue;
        }

        dist[start] = 0;

        PriorityQueue<int, int> pq = new();
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int current, out int currentDist);

            if (currentDist > dist[current]) continue;

            foreach (var edge in graph[current])
            {
                int next = edge.To;
                int weight = edge.Weight;

                if (dist[current] + weight < dist[next])
                {
                    dist[next] = dist[current] + weight;
                    pq.Enqueue(next, dist[current] + weight);
                }
            }
        }

        return dist;
    }
}