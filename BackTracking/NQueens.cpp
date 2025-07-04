#include <iostream>
#include <vector>
using namespace std;

// ���� ��ġ�� ���� ���� �� �ִ��� �˻�

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
		if (Rows[i] == Column) //����
		{
			return false;
		}

		if (abs(Rows[i] - Column) == abs(Row - i)) //�밢��
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

			Rows[Row] = -1; //�ٽ� ���ƿö��� �ʱ�ȭ�صα�
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
