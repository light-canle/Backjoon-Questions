using System;

/// <summary>
/// p24265 - 알고리즘 수업 - 알고리즘의 수행 시간 4, B3
/// 해결 날짜 : 2024/3/27
/// </summary>

/*
MenOfPassion(A[], n) {
    sum <- 0;
    for i <- 1 to n - 1
        for j <- i + 1 to n
            sum <- sum + A[i] × A[j]; # 코드1
    return sum;
}

위의 알고리즘에서 '코드1' 부분은 2중 반복문에 의해 O(n^2)시간에 수행된다.
따라서 차수는 2이다.
실행 횟수를 따져보면 i = 1일 때, j는 2부터 n, i = 2일 떄, j는 3부터 n, ...
처음에는 n - 1회, 2번째에는 n - 2회, ... , 2, 1회 실행되므로 실행 횟수는 n(n-1) / 2회이다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine()!);
        Console.WriteLine((n - 1) * n / 2);
        Console.WriteLine(2);
    }
}