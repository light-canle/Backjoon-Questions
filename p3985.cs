using System;

public class Program
{
    public static void Main(string[] args)
    {
        int l = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int[] own = new int[l + 1];
        int[] cakeCount = new int[n + 1];
        int expectMax = 0;
        int exMaxNum = 0;
        int realMax = 0;
        int realMaxNum = 0;
        for (int i = 1; i <= n; i++)
        {
            int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int p = line[0], k = line[1];

            if (expectMax < k - p + 1)
            {
                expectMax = k - p + 1;
                exMaxNum = i;
            }

            for (int j = p; j <= k; j++)
            {
                if (own[j] == 0)
                    own[j] = i;
            }
        }

        for (int i = 1; i <= l; i++)
        {
            cakeCount[own[i]]++;
        }

        for (int i = 1; i <= n; i++)
        {
            if (realMax < cakeCount[i])
            {
                realMax = cakeCount[i];
                realMaxNum = i;
            }
        }
        Console.WriteLine(exMaxNum);
        Console.WriteLine(realMaxNum);
    }
}
