using System;

// p8958 - OX퀴즈, B2
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            int totalPoint = 0;
            int currentPoint = 1;

            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == 'O')
                {
                    totalPoint += currentPoint;
                    currentPoint++;
                }
                else
                {
                    currentPoint = 1;
                }
            }

            Console.WriteLine(totalPoint);
        }
    }
}
