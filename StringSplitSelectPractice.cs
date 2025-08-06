using System;
using System.Linq;

namespace AlgorithmPractice
{
    class StringSplitSelectPractice
    {
        // Split �Լ� ����: �������� ���е� ���� ���ڿ��� int �迭�� ��ȯ
        public static int[] SplitStringToIntArray(string input)
        {
            // ��: "1 2 3 4 5" -> [1, 2, 3, 4, 5]
            string[] tokens = input.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            return Array.ConvertAll(tokens, int.Parse);
        }

        // Select �Լ� ����: ������ ���� �پ��ִ� ���� ���ڿ��� int �迭�� ��ȯ
        public static int[] SelectStringToIntArray(string input)
        {
            // ��: "12345" -> [1, 2, 3, 4, 5]
            return input.Select(c => int.Parse(c.ToString())).ToArray();
        }

        // Split �Լ� ����: ��ǥ�� ���е� �ܾ �迭�� ��ȯ
        public static string[] SplitWords(string input)
        {
            // ��: "apple,banana,orange" -> ["apple", "banana", "orange"]
            return input.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }

        // Select �Լ� ����: ���ڿ��� �� ���ڸ� �빮�ڷ� ��ȯ�Ͽ� �迭�� ��ȯ
        public static char[] SelectToUpperChars(string input)
        {
            // ��: "hello" -> ['H', 'E', 'L', 'L', 'O']
            return input.Select(c => char.ToUpper(c)).ToArray();
        }

        // �׽�Ʈ�� Main �Լ�
        static void Main()
        {
            Console.WriteLine("Split ����: ���� ���� ���� �Է� (��: 1 2 3 4 5)");
            var arr1 = SplitStringToIntArray(Console.ReadLine()!);
            Console.WriteLine("���: " + string.Join(", ", arr1));

            Console.WriteLine("Select ����: �پ��ִ� ���� �Է� (��: 12345)");
            var arr2 = SelectStringToIntArray(Console.ReadLine()!);
            Console.WriteLine("���: " + string.Join(", ", arr2));

            Console.WriteLine("Split ����: ��ǥ ���� �ܾ� �Է� (��: apple,banana,orange)");
            var arr3 = SplitWords(Console.ReadLine()!);
            Console.WriteLine("���: " + string.Join(", ", arr3));

            Console.WriteLine("Select ����: ���ڿ� �Է� (��: hello)");
            var arr4 = SelectToUpperChars(Console.ReadLine()!);
            Console.WriteLine("���: " + string.Join(", ", arr4));
        }
    }
}