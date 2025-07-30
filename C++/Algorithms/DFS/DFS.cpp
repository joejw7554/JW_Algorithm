#include <iostream>
#include <vector>
using namespace std;

// ���� ����Ʈ ����� �׷��� ����
vector<vector<int>> graph = {
	{},         // 0�� ���� ������� ���� (1������ ����)
	{2, 3},     // 1�� ���� ����� ����
	{1, 4, 5},  // 2�� ���� ����� ����
	{1},        // 3�� ���� ����� ����
	{2},        // 4�� ���� ����� ����
	{2}         // 5�� ���� ����� ����
};

void DFS(int NodeNumber, vector<bool>& visited, const vector<vector<int>>& graph)
{
	if (visited[NodeNumber] == true) return;

		visited[NodeNumber] = true;
		cout << NodeNumber << " ";

	for (auto next : graph[NodeNumber])
	{
		if (visited[next] == false)
		{
			DFS(next, visited, graph);
		}
	}
}

bool hasCycle(int node, int parent, vector<bool>& visited, const vector<vector<int>>& graph) {
    visited[node] = true;
    for (auto next : graph[node]) {
        if (!visited[next]) {
            if (hasCycle(next, node, visited, graph)) return true;
        } else if (next != parent) {
            // 이미 방문했고, 부모가 아니면 사이클!
            return true;
        }
    }
    return false;
}

int main()
{
	vector<bool> Visited( 6, false );
	DFS(1, Visited, graph);

    vector<bool> visited(6, false);
    bool cycle = hasCycle(1, -1, visited, graph);
    if (cycle) cout << "사이클이 존재합니다." << endl;
    else cout << "사이클이 없습니다." << endl;


}

