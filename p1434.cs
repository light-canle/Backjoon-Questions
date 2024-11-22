using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = size[0], m = size[1];

        int[] box = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] book = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int curBox = 0, curBook = 0;
        int wasteSpace = 0;
        while (curBox < n && curBook < m)
        {
            if (box[curBox] >= book[curBook])
            {
                box[curBox] -= book[curBook];
                curBook++;
            }
            else
            {
                wasteSpace += box[curBox];
                curBox++;
            }
        }
        while (curBox < n)
        {
            wasteSpace += box[curBox];
            curBox++;
        }
        Console.WriteLine(wasteSpace);
    }
}
