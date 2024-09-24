using System;

/// <summary>
/// p24262 - 알고리즘 수업 - 알고리즘의 수행 시간 1, B5
/// 해결 날짜 : 2024/3/27
/// </summary>

/*
MenOfPassion(A[], n) {
    i = ⌊n / 2⌋;
    return A[i]; # 코드1
}

위의 알고리즘에서 '코드1'부분은 배열에서 특정 인덱스에 접근하는 부분으로 O(1)시간에 수행된다.
따라서 실행 횟수는 1, 차수는 0이다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        Console.WriteLine(1);
        Console.WriteLine(0);
    }
}