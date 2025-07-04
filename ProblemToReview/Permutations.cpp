#include <iostream>
#include <vector>

using namespace std;

// 연속된 알파벳이 붙어있는 경우를 제외한 순열 출력 (디버깅 포함)
void PermutationProblem(int CurrentIndex, int LetterNums, vector<char>& Letters, vector<bool>& Selected, vector<char>& Result)
{
	if (CurrentIndex == LetterNums)
	{
		for (auto Letter : Result)
		{
			cout << Letter;
		}
		cout << "  <== 결과" << endl;
		return;
	}


	for (int i = 0; i < LetterNums; i++)
	{
		if (Selected[i]==false)
		{
			if (CurrentIndex > 0 && (Letters[i] - Result[CurrentIndex - 1]) == 1)
				continue;

			Selected[i] = true;
			Result[CurrentIndex] = Letters[i];
			PermutationProblem(CurrentIndex + 1, LetterNums, Letters, Selected, Result);
			Selected[i] = false;
		}
	}
}

void FindAllSolutions(int LetterNums)
{
	char InitialLetter = 'A';
	std::vector<char> Letters;
	for (int i = 0; i < LetterNums; i++)
	{
		Letters.push_back(InitialLetter + i);
	}
	vector<bool>Selected(LetterNums, false);
	vector<char>Result(LetterNums, ' ');
	PermutationProblem(0, LetterNums, Letters, Selected, Result);
}

int main()
{
	int LetterNums = 3;
	FindAllSolutions(LetterNums);
}