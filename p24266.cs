using System;

/// <summary>
/// p24266 - 알고리즘 수업 - 알고리즘의 수행 시간 5, ㅠ3
/// 해결 날짜 : 2024/3/27
/// </summary>

/*
MenOfPassion(A[], n) {
    sum <- 0;
    for i <- 1 to n
        for j <- 1 to n
            for k <- 1 to n
                sum <- sum + A[i] × A[j] × A[k]; # 코드1
    return sum;
}

위의 알고리즘에서 '코드1' 부분은 3중 반복문에 의해 O(n^3)시간에 수행된다.
따라서 실행 횟수는 n^3, 차수는 3이다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine()!);
        Console.WriteLine(n * n * n);
        Console.WriteLine(3);
    }
}