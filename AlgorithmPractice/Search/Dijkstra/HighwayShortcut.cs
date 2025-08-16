using System;
using System.Collections.Generic;

//https://www.acmicpc.net/problem/1446
public class ShortestPath
{
    // ��带 ǥ���ϴ� Ŭ���� (�Ÿ�, ��ġ)
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

        // �Ϲ� ���� ���� �߰�
        for (int i = 0; i < D; i++)
        {
            Node regularRoad = new Node();
            regularRoad.Distance = 1;
            regularRoad.Position = i + 1;
            road[i].Add(regularRoad);
        }

        // ������ �߰� (���� �ڵ� ����)
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