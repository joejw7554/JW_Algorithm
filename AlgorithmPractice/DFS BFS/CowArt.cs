using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Xml;

// https://www.acmicpc.net/problem/10026
class CowArt
{
    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };


    static (int N, char[,] grid) ReadInput()
    {
        int N = int.Parse(Console.ReadLine());

        char[,] Grid = new char[N, N];

        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < N; j++)
            {
                Grid[i, j] = line[j];
            }
        }

        Console.WriteLine("///////////////////////////////////////");

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(Grid[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine("///////////////////////////////////////");

        return (N, Grid);
    }

    static int BFSCountNormalRegions(int N, char[,] grid)
    {
        int AreaCount = 0;
        bool[,] visited = new bool[N, N];

        void BFS(int x, int y)
        {
            visited[y, x] = true;
            char color = grid[y, x];
            Queue<(int, int)> queue = new();
            var element = (y, x);
            queue.Enqueue(element);


            while (queue.Count > 0)
            {
                var (cy, cx) = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int ny = cy + dy[i];
                    int nx = cx + dx[i];

                    if (ny >= 0 && ny < N && nx >= 0 && nx < N && grid[ny, nx] == color && visited[ny, nx] == false)
                    {
                        visited[ny, nx] = true;
                        queue.Enqueue((ny, nx));
                    }
                }
            }
        }


        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (visited[i, j] == false)
                {
                    BFS(i, j);
                    AreaCount++;
                }
            }
        }
        return AreaCount;
    }

    static int BFSCountColorBlindRegions(int N, char[,] grid)
    {
        int AreaCount = 0;
        bool[,] visited = new bool[N, N];

        void BFS(int x, int y)
        {
            visited[y, x] = true;
            char color = grid[y, x];
            Queue<(int, int)> queue = new();
            var element = (y, x);
            queue.Enqueue(element);


            while (queue.Count > 0)
            {
                var (cy, cx) = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int ny = cy + dy[i];
                    int nx = cx + dx[i];

                    if (ny >= 0 && ny < N && nx >= 0 && nx < N && visited[ny, nx] == false && IsSameColor(cy, cx, ny, nx))
                    {
                        visited[ny, nx] = true;
                        queue.Enqueue((ny, nx));
                    }
                }
            }
        }

        bool IsSameColor(int y1, int x1, int y2, int x2)
        {
            char c1 = grid[y1, x1];
            char c2 = grid[y2, x2];
            if ((c1 == 'R' || c1 == 'G') && (c2 == 'R' || c2 == 'G'))
                return true;
            return c1 == c2;
        }


        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (visited[i, j] == false)
                {
                    BFS(i, j);
                    AreaCount++;
                }
            }
        }
        return AreaCount;
    }


    static int DFSCountColorNormalRegions(int N, char[,] grid)
    {
        int RegionCount = 0;
        bool[,] visited = new bool[N, N];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (visited[i, j] == false)
                {
                    DFS(i, j);
                    RegionCount++;
                }
            }
        }

        void DFS(int y1, int x1)
        {
            visited[y1, x1] = true;
            Console.WriteLine($"DFS({y1},{x1}) color={grid[y1, x1]} visited={visited[y1, x1]}");

            for (int i = 0; i < 4; i++)
            {
                int nx = x1 + dx[i];
                int ny = y1 + dy[i];

                if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                {
                    if (grid[y1, x1] == grid[ny, nx] && visited[ny, nx] == false)
                    {
                        DFS(ny, nx);
                    }
                }
            }
        }

        return RegionCount;
    }

    static int DFSCountColorBlindRegions(int N, char[,] grid)
    {
        int BlindRegionCount = 0;
        bool[,] visited = new bool[N, N];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (visited[i, j] == false)
                {
                    DFS(i, j);
                    BlindRegionCount++;
                }
            }
        }

        void DFS(int y1, int x1)
        {
            visited[y1, x1] = true;

            for (int i = 0; i < 4; i++)
            {
                int nx = x1 + dx[i];
                int ny = y1 + dy[i];

                if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                {
                    if (visited[ny, nx] == false && IsSameColorforBlind(grid, y1, x1, ny, nx))
                    {
                        DFS(ny, nx);
                    }
                }
            }
        }


        bool IsSameColorforBlind(char[,] grid, int y1, int x1, int y2, int x2)
        {
            if ((grid[y1, x1] == 'R' || grid[y1, x1] == 'G') && (grid[y2, x2] == 'R' || grid[y2, x2] == 'G'))
            {
                return true;
            }

            return false;
        }

        return BlindRegionCount;

    }


    static void Main()
    {
        var (N, grid) = ReadInput();
        //int normal = BFSCountNormalRegions(N, grid);
        //int colorBlind = BFSCountColorBlindRegions(N, grid);

        int normal = DFSCountColorNormalRegions(N, grid);
        int colorBlind = DFSCountColorBlindRegions(N, grid);
        Console.WriteLine($"{normal} {colorBlind}");
    }
}
