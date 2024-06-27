using System;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        if (N == 1 || N == 2)
        {
            Console.WriteLine("4");
            return;
        }
        int root = (int)Math.Sqrt(N);

        if (root * root == N)
        {
            Console.WriteLine(4 * (root - 1));
        }
        else if (root * (root + 1) >= N)
        {
            Console.WriteLine(2 * (2 * root - 1));
        }
        else
        {
            Console.WriteLine(4 * root);
        }
    }
}
