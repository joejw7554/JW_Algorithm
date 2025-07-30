using System;
using System.Collections.Generic;

class Program
{
    static int Edges;
    static int Vertexes;
      
    static List<int>[] graph;
    static bool[] visited;
    static Queue<int> queue;
    static HashSet<(int, int)> visitedEdges = new();

    // 예시 그래프 (5개 노드, 구조 변경)
    // 0: 1, 2
    // 1: 0, 3
    // 2: 0, 4
    // 3: 1, 4
    // 4: 2, 3

    static void DFS(int Index)
    {
        if (visited[Index]==false)
        {
            Console.WriteLine($"Visited: {Index}");
            visited[Index] = true;
            Vertexes++;

            foreach (var node in graph[Index])
            {
                var edge = Index < node ? (Index, node) : (node, Index);
                if (!visitedEdges.Contains(edge))
                {
                    visitedEdges.Add(edge);
                    Edges++;
                }
                DFS(node);
            }
        }
    }

    static void BFS(int Start)
    {
        visited[Start] = true;
        queue.Enqueue(Start);

        while(queue.Count > 0)
        {
            int current= queue.Dequeue();
            Console.WriteLine($"Visited: {current}");

            foreach(var nextNode in graph[current])
            {
                if (visited[nextNode] == false)
                {
                    queue.Enqueue(nextNode);
                    visited[nextNode] = true;
                }
            }
        }
    }


    static void Main()
    {
        int N = 5;
        graph = new List<int>[N];
        visited = new bool[N];
        queue = new Queue<int>();

        for (int i = 0; i < N; i++)
        {
            graph[i] = new List<int>();
        }

        graph[0].Add(1); graph[1].Add(0);
        graph[0].Add(2); graph[2].Add(0);
        graph[1].Add(3); graph[3].Add(1);
        graph[2].Add(4); graph[4].Add(2);
        graph[3].Add(4); graph[4].Add(3);

        //BFS(0);

        DFS(3);
        Console.WriteLine($"{Vertexes + Edges}");
    }
}

