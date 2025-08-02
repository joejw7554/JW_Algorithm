using System;
using System.Collections.Generic;

// https://www.acmicpc.net/problem/10026
class CowArt
{
    // 4방향 이동 (상, 하, 좌, 우)
    static readonly int[] dx = { -1, 1, 0, 0 };
    static readonly int[] dy = { 0, 0, -1, 1 };

    // 입력을 받아 그리드 정보를 반환하는 함수
    static (int N, char[,] grid) ReadInput()
    {
        int N = int.Parse(Console.ReadLine()!);
        char[,] grid = new char[N, N];

        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine()!;
            for (int j = 0; j < N; j++)
            {
                grid[i, j] = line[j];
            }
        }

        return (N, grid);
    }

    // 일반인이 보는 구역의 개수를 세는 함수
    static int CountNormalRegions(int N, char[,] grid)
    {
        bool[,] visited = new bool[N, N];
        int regionCount = 0;

        void BFS(int x, int y)
        {
            Queue<(int, int)> queue = new();
            queue.Enqueue((x, y));
            visited[x, y] = true;
            char color = grid[x, y];

            while (queue.Count > 0)
            {
                var (cx, cy) = queue.Dequeue();
                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = cx + dx[dir];
                    int ny = cy + dy[dir];
                    if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                    {
                        if (!visited[nx, ny] && grid[nx, ny] == color) //조건1:방문한곳인지 아닌지 조건2:상 하 좌 우 같은 영역인지 확인해야함
                        {
                            visited[nx, ny] = true;
                            queue.Enqueue((nx, ny));
                        }
                    }
                }
            }
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (!visited[i, j])
                {
                    BFS(i, j);
                    regionCount++;
                }
            }
        }

        return regionCount;
    }

    // 적록색약이 보는 구역의 개수를 세는 함수
    static int CountColorBlindRegions(int N, char[,] grid)
    {
        bool[,] visited = new bool[N, N];
        int regionCount = 0;

        void BFS(int x, int y)
        {
            Queue<(int, int)> queue = new();
            queue.Enqueue((x, y));
            visited[x, y] = true;
            char color = grid[x, y];

            while (queue.Count > 0)
            {
                var (cx, cy) = queue.Dequeue();
                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = cx + dx[dir];
                    int ny = cy + dy[dir];
                    if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                    {
                        if (!visited[nx, ny] && IsSameColor(color, grid[nx, ny]))
                        {
                            visited[nx, ny] = true;
                            queue.Enqueue((nx, ny));
                        }
                    }
                }
            }
        }

        // 적록색약 기준으로 같은 색인지 판별
        bool IsSameColor(char a, char b)
        {
            if (a == b) return true;
            if ((a == 'R' || a == 'G') && (b == 'R' || b == 'G')) return true;
            return false;
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (!visited[i, j])
                {
                    BFS(i, j);
                    regionCount++;
                }
            }
        }

        return regionCount;
    }

    static void Main()
    {
        var (N, grid) = ReadInput();
        int normal = CountNormalRegions(N, grid);
        int colorBlind = CountColorBlindRegions(N, grid);
        Console.WriteLine($"{normal} {colorBlind}");
    }
}
