using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://www.acmicpc.net/problem/4963

namespace AlgorithmPractice
{
    class NumberofIslands
    {
       
        static (int[,], int, int) InputProcess()
        {
            int Column, Row;

            Console.WriteLine("Enter Col");
            Column = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Row");
            Row = int.Parse(Console.ReadLine());

            int[,] Map = new int[Row, Column];

            Console.WriteLine("Design a map using 0(Sea) and 1(Land)");
            for (int i = 0; i < Row; i++)
            {
                string line = Console.ReadLine();
                string[] tokens;
                if (line.Contains(' '))
                {
                    tokens = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    tokens = line.Select(c => c.ToString()).ToArray();
                }

                int[] numbers = Array.ConvertAll(tokens, int.Parse);
                for (int j = 0; j < Column; j++)
                {
                    Map[i, j] = numbers[j];
                }
            }

            return (Map, Row, Column);
        }

        static int CountIslandsBFS(int row, int col, int[,] map)
        {
            bool[,] visited = new bool[row, col];
            int islandCount = 0;


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (map[i, j] == 1 && !visited[i, j])
                    {
                        BFS(i, j); //DFS(i,j)
                        islandCount++;
                    }
                }
            }

            void BFS(int yCoor, int xCoor)
            {
                var queue = new Queue<(int, int)>();
                visited[yCoor, xCoor] = true;
                queue.Enqueue((yCoor, xCoor));

                while (queue.Count > 0)
                {
                    var (cy, cx) = queue.Dequeue();

                    for (int dyIdx = -1; dyIdx <= 1; dyIdx++)
                    {
                        for (int dxIdx = -1; dxIdx <= 1; dxIdx++)
                        {
                            if (dyIdx == 0 && dxIdx == 0) continue; // 자기 자신 제외

                            int ny = cy + dyIdx;
                            int nx = cx + dxIdx;

                            if (ny >= 0 && ny < row && nx >= 0 && nx < col)
                            {
                                if (!visited[ny, nx] && map[ny, nx] == 1)
                                {
                                    visited[ny, nx] = true;
                                    queue.Enqueue((ny, nx));
                                }
                            }
                        }
                    }
                }

            }


            return islandCount;
        }

        static int CountIslandsDFS(int row, int col, int[,] map)
        {
            int numOfIslands = 0;
            bool[,] visited = new bool[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (map[i, j] == 1 && !visited[i, j])
                    {
                        Stack<(int, int)> stack = new();
                        stack.Push((i, j));
                        visited[i, j] = true;

                        while (stack.Count > 0)
                        {
                            var (y, x) = stack.Pop();

                            for (int dy = -1; dy <= 1; dy++)
                            {
                                for (int dx = -1; dx <= 1; dx++)
                                {
                                    if (dy == 0 && dx == 0) continue;
                                    int ny = y + dy;
                                    int nx = x + dx;
                                    if (ny >= 0 && ny < row && nx >= 0 && nx < col)
                                    {
                                        if (!visited[ny, nx] && map[ny, nx] == 1)
                                        {
                                            visited[ny, nx] = true;   // 먼저 방문 표시
                                            stack.Push((ny, nx));     // 그 다음 push
                                        }
                                    }
                                }
                            }
                        }
                        numOfIslands++;
                    }
                }
            }
            return numOfIslands;
        }



        //static void Main()
        //{
        //    var (map, row, col) = InputProcess();

        //    //var islandCount= CountIslandsBFS(row, col, map);
        //    int islandCount = CountIslandsDFS(row, col, map);
        //    Console.WriteLine(islandCount);
        //}
    }
}
