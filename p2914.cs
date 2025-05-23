using System;

// p2914 - 저작권 (B3)
// #사칙연산
// 2025.5.23 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int A = input[0];
        int I = input[1];

        // A = 1이면 언제나 평균이 정수이다.
        if (A == 1)
        {
            Console.WriteLine(A * I);
        }
        // A = 2이면 평균이 정수가 아닐 수 있다.
        // 구하는 최솟값은 올림된 평균 I에 1을 빼고 A를 곱한 뒤 1을 더한 값이다.
        else
        {
            Console.WriteLine(A * (I - 1) + 1);
        }
    }
}
