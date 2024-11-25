using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = size[0], k = size[1];

        bool[] isDeleted = new bool[n - 1];

        int curPrime = 2, curNumber = 2;

        int order = 0;

        bool done = false;
        while (true)
        {
            while (curNumber <= n)
            {
                
                if (!isDeleted[curNumber - 2])
                {
                    isDeleted[curNumber - 2] = true;
                    order++;
                }
                if (order == k) 
                {
                    done = true;
                    break;
                }
                curNumber += curPrime;
            }
            if (done) break;
            while (curPrime <= n && isDeleted[curPrime - 2]) curPrime++;
            curNumber = curPrime;
        }

        Console.WriteLine(curNumber);
    }
}
