using System;
using System.Collections.Generic;

public class HighwayShortcut
{
    // 지름길 정보를 담는 클래스
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

    // 입력값
    static int N; // 지름길 개수
    static int D; // 고속도로 길이
    static List<Shortcut> Shortcuts = new();

    // 최단 거리 계산 함수 (알고리즘은 직접 구현)
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

        // 우선순위 큐: (현재 위치, 현재까지의 거리)
        PriorityQueue<int, int> pq = new();
        pq.Enqueue(0, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int curPos, out int curDist);

            // 이미 더 짧은 경로로 방문했다면 스킵
            if (dist[curPos] < curDist)
                continue;

            // 일반 도로로 한 칸 이동
            if (curPos + 1 <= D && dist[curPos + 1] > dist[curPos] + 1)
            {
                dist[curPos + 1] = dist[curPos] + 1;
                pq.Enqueue(curPos + 1, dist[curPos + 1]);
            }

            // 현재 위치에서 시작하는 지름길 모두 확인
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