using System;

/// <summary>
/// p24263 - 알고리즘 수업 - 알고리즘의 수행 시간 2, B4
/// 해결 날짜 : 2024/3/27
/// </summary>

/*
MenOfPassion(A[], n) {
    sum <- 0;
    for i <- 1 to n
        sum <- sum + A[i]; # 코드1
    return sum;
}

위의 알고리즘에서 '코드1' 부분은 1부터 n까지 반복되므로 O(n)시간에 수행된다.
따라서 실행 횟수는 n, 차수는 1이다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        Console.WriteLine(n);
        Console.WriteLine(1);
    }
}