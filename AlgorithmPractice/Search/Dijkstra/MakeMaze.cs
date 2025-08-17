using System;
using System.Collections.Generic;

//https://www.acmicpc.net/problem/2665

namespace AlgorithmPractice.Search.Dijkstra
{
    class MakeMaze
    {
        class Node
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Cost { get; set; }

            public Node(int x, int y, int cost)
            {
                X = x;
                Y = y;
                Cost = cost;
            }
        }

        static int N;
        static int[,] map;
        static int[,] dist;

        // 4방향 이동 (상, 하, 좌, 우)
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static void HandleInput()
        {
            N = int.Parse(Console.ReadLine());

            if (N < 1 || N > 50)
            {
                Console.WriteLine("Should be 1~ 50");
                return;
            }

            map = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                
                if (line.Length != N)
                {
                    Console.WriteLine("Error: Invalid input length");
                    return;
                }

                for (int j = 0; j < N; j++)
                {
                    map[i, j] = line[j] - '0';  // '0' → 0, '1' → 1
                }
            }

            int result = Dijkstra();
            Console.WriteLine(result);
        }

        static int Dijkstra()
        {
            dist = new int[N, N];
            
            // 모든 위치의 거리를 무한대로 초기화
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    dist[i, j] = int.MaxValue;
                }
            }

            // 시작점 초기화
            dist[0, 0] = 0;

            var pq = new PriorityQueue<Node, int>();
            pq.Enqueue(new Node(0, 0, 0), 0);

            while (pq.Count > 0)
            {
                Node current = pq.Dequeue();
                int x = current.X;
                int y = current.Y;
                int cost = current.Cost;

                // 이미 더 짧은 경로로 방문했다면 스킵
                if (cost > dist[x, y])
                    continue;

                // 4방향 탐색
                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    // 범위 체크
                    if (nx < 0 || nx >= N || ny < 0 || ny >= N)
                        continue;

                    int newCost;
                    if (map[nx, ny] == 1)  // 흰 방
                    {
                        newCost = cost + 0;  // 비용 0
                    }
                    else  // 검은 방
                    {
                        newCost = cost + 1;  // 흰 방으로 바꾸는 비용 1
                    }

                    // 더 짧은 경로를 발견했다면 갱신
                    if (newCost < dist[nx, ny])
                    {
                        dist[nx, ny] = newCost;
                        pq.Enqueue(new Node(nx, ny, newCost), newCost);
                    }
                }
            }

            return dist[N - 1, N - 1];  // 도착점까지의 최소 비용
        }

        static void Main()
        {
            HandleInput();
        }
    }
}
