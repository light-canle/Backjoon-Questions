using System;

// p32370 - Rook (B2)
// #애드 훅
// 2025.4.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] pawnA = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] pawnB = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        if (pawnA[0] == 0 && pawnB[0] == 0)
        {
            Console.WriteLine(pawnA[1] < pawnB[1] ? 1 : 3);
        }
        else if (pawnA[1] == 0 && pawnB[1] == 0)
        {
            Console.WriteLine(pawnA[0] < pawnB[0] ? 1 : 3);
        }
        else if (pawnA[0] == 0 || pawnA[1] == 0)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(2);
        }
    }
}
