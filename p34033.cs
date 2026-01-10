#pragma warning disable CS8604, CS8602, CS8600

// p34033 - 공금 횡령 (S4)
// #집합과 맵
// 2026.1.10 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];
        Dictionary<string, int> price = new();
        for (int i = 0; i < n; i++)
        {
            string[] product = sr.ReadLine().Split();
            price[product[0]] = int.Parse(product[1]);
        }

        int mayMisappropriation = 0;
        for (int i = 0; i < m; i++)
        {
            string[] product = sr.ReadLine().Split();
            if (price[product[0]] * 1.05 < double.Parse(product[1]))
            {
                mayMisappropriation++;
            }
        }
        Console.WriteLine(mayMisappropriation);
    }
}
