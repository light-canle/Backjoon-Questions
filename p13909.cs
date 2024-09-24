using System;

/// <summary>
/// p13909 - 창문 닫기, S5
/// 해결 날짜 : 2024/3/28
/// </summary>

/*
정해진 규칙대로 창문을 열고 닫으면 마지막에는 1, 4, 9, ... 이렇게 자연수의 제곱번째 창문만 열리게 된다.
그래서 열린 창문의 개수는 floor(sqrt(count))이다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine()!);

        Console.WriteLine((int)Math.Sqrt(count));
    }
}