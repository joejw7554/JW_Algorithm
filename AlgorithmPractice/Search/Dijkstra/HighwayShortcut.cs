using System;
using System.Collections.Generic;

//https://www.acmicpc.net/problem/1446
public class ShortestPath
{
    // 노드를 표현하는 클래스 (거리, 위치)
    public class Node
    {
        public int Distance { get; set; }
        public int Position { get; set; }
    }

    public static void Main(string[] args)
    {
        int N, D;
        string[] firstLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);
        N = int.Parse(firstLine[0]);
        D = int.Parse(firstLine[1]);

        List<Node>[] road = new List<Node>[D + 1];

        // 일반 도로 간선 추가
        for (int i = 0; i < D; i++)
        {
            Node regularRoad = new Node();
            regularRoad.Distance = 1;
            regularRoad.Position = i + 1;
            road[i].Add(regularRoad);
        }

        // 지름길 추가 (기존 코드 개선)
        for (int i = 0; i < N; i++)
        {
            int[] shortcuts = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries), int.Parse);
            int start = shortcuts[0];
            int end = shortcuts[1];
            int distance = shortcuts[2];

            if (end <= D && 0 <= start && start < D && distance < (end - start))
            {
                Node node = new Node();
                node.Distance = distance;
                node.Position = end;
                road[start].Add(node);
            }
        }


    }

}