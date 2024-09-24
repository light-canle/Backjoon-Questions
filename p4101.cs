using System;
using System.Linq;

/// <summary>
/// p4101 - 크냐?, B5
/// 해결 날짜 : 2023/10/22
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (inputs[0] == 0 && inputs[1] == 0) { break; }
            Console.WriteLine((inputs[0] > inputs[1]) ? "Yes" : "No");
        }
    }
}