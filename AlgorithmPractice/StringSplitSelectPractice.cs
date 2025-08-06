using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmPractice
{
    class StringSplitSelectPractice
    {
        static int SplitStringToIntArray(string input)
        {
            int answer = 0;

            string[] token = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(token);

            foreach (var str in token)
            {
                Console.WriteLine(int.Parse(str));
                answer += int.Parse(str);
            }

            return answer;
        }

        // 테스트용 Main 함수
        static void Main()
        {
            string input = "3 5 7 2 8";
            int total = SplitStringToIntArray(input);
            Console.WriteLine($"Answer {total}");

        }
    }
}