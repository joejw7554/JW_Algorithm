#include <iostream>
#include <vector>

using namespace std;

bool IsValid(int K, int MaxCol,  const vector<int>& Columns)
{
	for (int i = 1; i < MaxCol; i++)
	{
		if (Columns[K]==-1 &&) //가로 세로 대각선 
		{
			return true;
		}
		else
		{
			return false;
		}
	}


}

void NQueensProblem(int K, int Col, vector<int>Columns)
{
	for (int i = 1; i < Col; i++)
	{
		if (IsValid()) //i번쨰 Column Queen이 배치 가능한지 여부조건
		{

		}

	}

}

int main()
{
	int NumQueens = 4;


	vector<int> Columns(NumQueens + 1, -1);
	int Start = 1;

	NQueensProblem(Start, NumQueens + 1, Columns);

	return 0;
}

