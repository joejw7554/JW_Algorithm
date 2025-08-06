using System;
using System.Linq;

namespace AlgorithmPractice
{
    class StringSplitSelectPractice
    {
        // Split 함수 연습: 공백으로 구분된 숫자 문자열을 int 배열로 변환
        public static int[] SplitStringToIntArray(string input)
        {
            // 예: "1 2 3 4 5" -> [1, 2, 3, 4, 5]
            string[] tokens = input.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            return Array.ConvertAll(tokens, int.Parse);
        }

        // Select 함수 연습: 구분자 없이 붙어있는 숫자 문자열을 int 배열로 변환
        public static int[] SelectStringToIntArray(string input)
        {
            // 예: "12345" -> [1, 2, 3, 4, 5]
            return input.Select(c => int.Parse(c.ToString())).ToArray();
        }

        // Split 함수 연습: 쉼표로 구분된 단어를 배열로 변환
        public static string[] SplitWords(string input)
        {
            // 예: "apple,banana,orange" -> ["apple", "banana", "orange"]
            return input.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }

        // Select 함수 연습: 문자열의 각 문자를 대문자로 변환하여 배열로 반환
        public static char[] SelectToUpperChars(string input)
        {
            // 예: "hello" -> ['H', 'E', 'L', 'L', 'O']
            return input.Select(c => char.ToUpper(c)).ToArray();
        }

        // 테스트용 Main 함수
        static void Main()
        {
            Console.WriteLine("Split 연습: 공백 구분 숫자 입력 (예: 1 2 3 4 5)");
            var arr1 = SplitStringToIntArray(Console.ReadLine()!);
            Console.WriteLine("결과: " + string.Join(", ", arr1));

            Console.WriteLine("Select 연습: 붙어있는 숫자 입력 (예: 12345)");
            var arr2 = SelectStringToIntArray(Console.ReadLine()!);
            Console.WriteLine("결과: " + string.Join(", ", arr2));

            Console.WriteLine("Split 연습: 쉼표 구분 단어 입력 (예: apple,banana,orange)");
            var arr3 = SplitWords(Console.ReadLine()!);
            Console.WriteLine("결과: " + string.Join(", ", arr3));

            Console.WriteLine("Select 연습: 문자열 입력 (예: hello)");
            var arr4 = SelectToUpperChars(Console.ReadLine()!);
            Console.WriteLine("결과: " + string.Join(", ", arr4));
        }
    }
}