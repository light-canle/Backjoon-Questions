using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int aScore = 0, bScore = 0;
        int finalWin = 0;
        for (int i = 0; i < 10; i++)
        {
            if (a[i] > b[i]) 
            {
                aScore += 3;
                finalWin = 1;
            }
            else if (a[i] < b[i])
            {
                bScore += 3;
                finalWin = 2;
            }
            else 
            {
                aScore++; 
                bScore++;
            }
        }
        Console.WriteLine(aScore + " " + bScore);
        if (aScore > bScore)
            Console.WriteLine("A");
        else if (aScore < bScore)
            Console.WriteLine("B");
        else
        {
            if (finalWin == 1)
                Console.WriteLine("A");
            else if (finalWin == 2)
                Console.WriteLine("B");
            else
                Console.WriteLine("D");
        }
    }
}
