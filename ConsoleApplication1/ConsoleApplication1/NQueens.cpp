#include <iostream>
#include <vector>

using namespace std;

bool IsValid(int K, int MaxCol,  const vector<int>& Columns)
{
	for (int i = 1; i < MaxCol; i++)
	{
		if (Columns[K]==-1 &&) //���� ���� �밢�� 
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
		if (IsValid()) //i���� Column Queen�� ��ġ �������� ��������
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

