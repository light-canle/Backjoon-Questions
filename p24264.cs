using System;

/// <summary>
/// 
/// </summary>

/*
MenOfPassion(A[], n) {
    sum <- 0;
    for i <- 1 to n
        for j <- 1 to n
            sum <- sum + A[i] × A[j]; # 코드1
    return sum;
}

위의 알고리즘에서 '코드1' 부분은 2중 반복문에 의해 O(n^2)시간에 수행된다.
따라서 실행 횟수는 n^2, 차수는 2이다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine()!);
        Console.WriteLine(n * n);
        Console.WriteLine(2);
    }
}