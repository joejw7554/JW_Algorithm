#include <iostream>
#include <vector>
#include <algorithm>
#include <array>
using namespace std;

// 2차원 배열을 파라미터로 받는 함수 선언 (10x10)


bool IsValid(int row, int col, int value, int S[10][10])
{
	for (int i = 1; i < 10; i++)
	{
		if (S[i][col] == value) return false; // 세로
		if (S[row][i] == value) return false; // 가로
	}

	//Check in the cube
	int Block_XCoor = col - ((col - 1) % 3);
	int Block_YCoor = row - ((row - 1) % 3);

	for (int i = Block_YCoor; i < Block_YCoor + 3; i++)
	{
		for (int j = Block_XCoor; j < Block_XCoor + 3; j++)
		{
			if (S[i][j] == value)
			{
				return false;
			}
		}
	}

	return true;
}

void SudokuProblem(int row, int col, int S[10][10])
{
	if (row == 10)
	{
		for (int i = 1; i < 10; i++)
		{
			for (int j = 1; j < 10; j++)
			{
				cout << S[i][j] << ' ';
			}
			cout << endl;
		}
		return;
	}
	else
	{
		if (S[row][col] != -1)
		{
			SudokuProblem(col == 9 ? row + 1 : row, col == 9 ? 1 : col + 1, S);
		}
		else
		{
			for (int i = 1; i < 10; i++)
			{
				{
					if (IsValid(row, col, i, S))
					{
						S[row][col] = i;
						col == 9 ? SudokuProblem(row + 1, 1, S) : SudokuProblem(row, col + 1, S);
						S[row][col] = -1;
					}
				}
			}
		}
	}

}

int main()
{
	int sudoku[10][10] = { 0 };

	int temp[9][9] =
	{
		{5, 3, -1, 6, 7, 8, 9, 1, 2},
		{6, -1, 2, 1, 9, 5, 3, 4, 8},
		{1, 9, 8, 3, 4, -1, 5, 6, 7},
		{8, 5, 9, 7, 6, 1, -1, 2, 3},
		{4, 2, 6, 8, -1, 3, 7, 9, 1},
		{7, 1, 3, 9, 2, 4, 8, -1, 6},
		{-1, 6, 1, 5, 3, 7, 2, 8, 4},
		{2, 8, 7, 4, 1, 9, 6, 3, -1},
		{3, 4, 5, -1, 8, -1, 1, 7, 9}
	};

	for (int i = 1; i <= 9; ++i)
		for (int j = 1; j <= 9; ++j)
			sudoku[i][j] = temp[i - 1][j - 1];

	SudokuProblem(1, 1, sudoku);
}
