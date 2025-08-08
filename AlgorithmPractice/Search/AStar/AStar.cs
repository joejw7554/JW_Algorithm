using System;
using System.Collections.Generic;

// 노드 구조체
public class Node
{
    public int X, Y;                // 위치
    public int G, H, F;             // 비용
    public Node Parent;             // 경로 추적용

    public Node(int x, int y, int g, int h, Node parent)
    {
        X = x; Y = y;
        G = g; H = h;
        F = g + h;
        Parent = parent;
    }

    public override bool Equals(object obj)
    {
        if (obj is Node other)
            return X == other.X && Y == other.Y;
        return false;
    }

    public override int GetHashCode()
    {
        return X * 31 + Y;
    }
}

public class AStar
{
    // 4방향 이동 (상하좌우)
    private static readonly int[] dx = { 0, 0, -1, 1 };
    private static readonly int[] dy = { -1, 1, 0, 0 };

    // 맵: 0은 이동 가능, 1은 벽
    public static List<Node> FindPath(int[,] map, int startX, int startY, int endX, int endY)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        var open = new SortedSet<Node>(Comparer<Node>.Create((a, b) => a.F == b.F ? (a.H.CompareTo(b.H)) : a.F.CompareTo(b.F)));
        var closed = new HashSet<Node>();

        var startNode = new Node(startX, startY, 0, Heuristic(startX, startY, endX, endY), null);
        open.Add(startNode);

        while (open.Count > 0)
        {
            Node current = open.Min;
            open.Remove(current);
            closed.Add(current);

            // 도착 지점 도달
            if (current.X == endX && current.Y == endY)
                return BuildPath(current);

            // 4방향 인접 노드 탐색
            for (int i = 0; i < 4; i++)
            {
                int nx = current.X + dx[i];
                int ny = current.Y + dy[i];

                if (nx < 0 || ny < 0 || nx >= width || ny >= height)
                    continue; // 맵 바깥
                if (map[nx, ny] == 1)
                    continue; // 벽

                var neighbor = new Node(nx, ny, current.G + 1, Heuristic(nx, ny, endX, endY), current);
                if (closed.Contains(neighbor))
                    continue;

                // open에 이미 있으면 비용 비교
                Node openNode = null;
                foreach (var node in open)
                    if (node.Equals(neighbor)) { openNode = node; break; }
                if (openNode != null && neighbor.G >= openNode.G)
                    continue;

                open.Add(neighbor);
            }
        }
        // 길이 없을 때
        return null;
    }

    // 맨해튼 거리 휴리스틱
    private static int Heuristic(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }

    // 경로 되짚기
    private static List<Node> BuildPath(Node endNode)
    {
        var path = new List<Node>();
        Node current = endNode;
        while (current != null)
        {
            path.Add(current);
            current = current.Parent;
        }
        path.Reverse();
        return path;
    }
}