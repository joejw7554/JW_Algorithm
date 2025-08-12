using System;
using System.Collections.Generic;

public class HighwayShortcut
{
    // ������ ������ ��� Ŭ����
    public class Shortcut
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Length { get; set; }
        public Shortcut(int start, int end, int length)
        {
            Start = start;
            End = end;
            Length = length;
        }
    }

    // �Է°�
    static int N; // ������ ����
    static int D; // ��ӵ��� ����
    static List<Shortcut> Shortcuts = new();

    // �ִ� �Ÿ� ��� �Լ� (�˰����� ���� ����)
    static void HandleInput()
    {
        int[] token;
        token = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries), int.Parse);

        N = token[0];
        D = token[1];

        for (int i = 0; i < N; i++)
        {
            int[] shortcutInfo = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries), int.Parse);
            Shortcuts.Add(new Shortcut(shortcutInfo[0], shortcutInfo[1], shortcutInfo[2]));

        }
    }


    static int GetMinimumDistance()
    {
        int[] dist = new int[D + 1];
        for (int i = 0; i <= D; i++)
            dist[i] = int.MaxValue;
        dist[0] = 0;

        // �켱���� ť: (���� ��ġ, ��������� �Ÿ�)
        PriorityQueue<int, int> pq = new();
        pq.Enqueue(0, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int curPos, out int curDist);

            // �̹� �� ª�� ��η� �湮�ߴٸ� ��ŵ
            if (dist[curPos] < curDist)
                continue;

            // �Ϲ� ���η� �� ĭ �̵�
            if (curPos + 1 <= D && dist[curPos + 1] > dist[curPos] + 1)
            {
                dist[curPos + 1] = dist[curPos] + 1;
                pq.Enqueue(curPos + 1, dist[curPos + 1]);
            }

            // ���� ��ġ���� �����ϴ� ������ ��� Ȯ��
            foreach (var shortcut in Shortcuts)
            {
                if (shortcut.Start == curPos && shortcut.End <= D)
                {
                    if (dist[shortcut.End] > dist[curPos] + shortcut.Length)
                    {
                        dist[shortcut.End] = dist[curPos] + shortcut.Length;
                        pq.Enqueue(shortcut.End, dist[shortcut.End]);
                    }
                }
            }
        }

        return dist[D];
    }

    static void Main()
    {
        HandleInput();

        GetMinimumDistance();
    }
}