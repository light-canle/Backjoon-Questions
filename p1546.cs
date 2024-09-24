using System;
using System.Linq;
using System.Collections.Generic;

// p1546 - 평균, B1
// 해결 날짜 : 2023/8/20
public class Program
{
    public static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        // 원래는 List<int>로 했으나, Segfault 에러가 나서 int[]로 고쳤더니 해결되었다.
        int[] numberList = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();

        int maxScore = numberList.Max();

        var newScore = numberList.Select(score => (double)score / maxScore * 100.0);

        Console.Write(newScore.Average().ToString());
    }
}
