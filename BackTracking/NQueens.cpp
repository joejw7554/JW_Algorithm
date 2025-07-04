#include <iostream>
#include <vector>
using namespace std;

// 현재 위치에 퀸을 놓을 수 있는지 검사

void PrintSolution(int NumQueens, const vector<int>& Rows)
{
	for (int i = 1; i < NumQueens + 1; i++)
	{
		for (int j = 1; j < NumQueens + 1; j++)
		{
			Rows[i] == j ? cout << "Q " : cout << ". ";
		}
		cout<< endl;
	}

	cout << endl;
}

bool IsValid(int Row, int Column, vector<int>& Rows)
{
	for (int i = 1; i < Row; i++)
	{
		if (Rows[i] == Column) //세로
		{
			return false;
		}

		if (abs(Rows[i] - Column) == abs(Row - i)) //대각선
		{
			return false;
		}
	}

	return true;
}

void NQueensProblem(int Row, int NumQueens, vector<int>& Rows, int& Solutions)
{
	if (Row > NumQueens)
	{
		Solutions++;
		PrintSolution(NumQueens, Rows);
		return;
	}

	for (int i = 1; i < NumQueens + 1; i++)
	{
		if (IsValid(Row, i, Rows))
		{
			Rows[Row] = i;
			NQueensProblem(Row + 1, NumQueens, Rows, Solutions);

			Rows[Row] = -1; //다시 돌아올때는 초기화해두기
		}
	}
}


void FindAllSolutions(int NumQueens)
{
	vector<int> Rows(5, -1);

	int Solution = 0;
	NQueensProblem(1, NumQueens, Rows, Solution);

	cout << "Answer:" << Solution << endl;
}


int main()
{
	int NumQueens = 4;
	FindAllSolutions(NumQueens);
	return 0;
}
