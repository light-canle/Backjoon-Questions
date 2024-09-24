using System;

/// <summary>
/// p24267 - 알고리즘 수업 - 알고리즘의 수행 시간 6, B2
/// 해결 날짜 : 2024/3/27
/// </summary>

/*
MenOfPassion(A[], n) {
    sum <- 0;
    for i <- 1 to n - 2
        for j <- i + 1 to n - 1
            for k <- j + 1 to n
                sum <- sum + A[i] × A[j] × A[k]; # 코드1
    return sum;
}

위의 알고리즘에서 '코드1' 부분은 3중 반복문에 의해 O(n^3)시간에 수행된다.
따라서, 차수는 3이다.
실행 횟수는 1 + (1 + 2) + (1 + 2 + 3) + ... + (1 + 2 + ... + n - 2)회가 된다.
이를 시그마 식으로 나타내면 k = 1 ... n - 2, ∑ k(k + 1) / 2가 되고, 계산하면 n * (n - 2) * (n - 1) / 6이 된다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine()!);
        Console.WriteLine(n * (n - 2) * (n - 1) / 6);
        Console.WriteLine(3);
    }
}