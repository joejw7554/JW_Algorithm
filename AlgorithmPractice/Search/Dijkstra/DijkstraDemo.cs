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

    static void Main()
    {
        int n = 5;
        List<Edge>[] graph = new List<Edge>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<Edge>();

        graph[0].Add(new Edge(1, 2));
        graph[0].Add(new Edge(2, 4));
        graph[1].Add(new Edge(2, 1));
        graph[1].Add(new Edge(3, 7));
        graph[2].Add(new Edge(4, 3));
        graph[3].Add(new Edge(4, 1));

        int start = 0;
        int[] dist = Dijkstra(graph, start);

        Console.WriteLine("최단 거리 결과:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{start} -> {i} : {dist[i]}");
        }
    }

    static int[] Dijkstra(List<Edge>[] graph, int start)
    {
        int n = graph.Length;
        int[] dist = new int[n];
        for (int i = 0; i < n; i++)
            dist[i] = int.MaxValue;
        dist[start] = 0;

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(start, 0);

        Console.WriteLine("=== Dijkstra 알고리즘 시작 ===");
        PrintDist(dist);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int current, out int currentDist);
            Console.WriteLine($"\n[큐에서 꺼냄] current: {current}, currentDist: {currentDist}");

            if (currentDist > dist[current])
            {
                Console.WriteLine($"  이미 더 짧은 경로로 방문함 (dist[{current}]={dist[current]}), 건너뜀");
                continue;
            }

            foreach (var edge in graph[current])
            {
                int next = edge.To;
                int cost = dist[current] + edge.Weight;
                Console.WriteLine($"  이웃 확인: {current} -> {next} (가중치 {edge.Weight}), 계산된 cost: {cost}");

                if (cost < dist[next])
                {
                    Console.WriteLine($"    최단 거리 갱신! dist[{next}] : {dist[next]} -> {cost}");
                    dist[next] = cost;
                    pq.Enqueue(next, cost);
                    PrintDist(dist);
                }
                else
                {
                    Console.WriteLine($"    기존 경로가 더 짧음 (dist[{next}]={dist[next]}), 갱신하지 않음");
                }
            }
        }
        Console.WriteLine("=== Dijkstra 알고리즘 종료 ===");
        return dist;
    }

    static void PrintDist(int[] dist)
    {
        Console.Write("  현재 dist 배열: ");
        for (int i = 0; i < dist.Length; i++)
        {
            if (dist[i] == int.MaxValue)
                Console.Write("∞ ");
            else
                Console.Write(dist[i] + " ");
        }
        Console.WriteLine();
    }
}