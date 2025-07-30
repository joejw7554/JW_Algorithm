#include <iostream>
#include <set>
#include <vector>
#include <algorithm>

using namespace std;


//https://www.acmicpc.net/problem/6603


void Backtrack(const vector<int>& S, int start, vector<int>& comb) {
	// �����: ���� ���� ���� ���
	cout << "[DEBUG] comb: ";
	for (int n : comb) cout << n << " ";
	cout << "| start: " << start << "\n";

	if (comb.size() == 6) 
	{
		cout << "[RESULT] ";
		for (int n : comb) cout << n << " ";
		cout << "\n";
		return;
	}

	for (int i = start; i < S.size(); ++i)
	{
		cout << "[DEBUG] ����: " << S[i] << " (i=" << i << ")\n";
		comb.push_back(S[i]);
		Backtrack(S, i + 1, comb);
		comb.pop_back();
	}
}


void GetLottoCombinations(const vector<int>& S, int k)
{
	vector<int> Combination;

	Backtrack(S, 0, Combination);
}

int main()
{
	vector<int> S = {1,2,3,5,8,13,21,34};
	int k = 8;
	GetLottoCombinations(S, k);
	// result���� 28���� 6��¥�� ������ �������

}