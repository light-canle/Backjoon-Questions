using System;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        var fraction = FindFraction(n);
        Console.WriteLine($"{fraction.Item1}/{fraction.Item2}");
    }
    
    public static (int, int) FindFraction(int n){
        // 1. n을 통해 sum을 찾음
        int sum = (int)Math.Ceiling((-1 + Math.Sqrt(8*n + 1)) / 2) + 1;

        // 2. 적절한 분모, 분자를 찾음
        int max_n = (sum - 1) * sum / 2;
        int diff = max_n - n;
        if (sum % 2 == 1){
            return (sum-1-diff,1 + diff);
        }
        else{
            return (1 + diff,sum-1-diff);
        }
    }
}