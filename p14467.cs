using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] pos = new int[10];
        for (int i = 0; i < 10; i++)
        {
            pos[i] = -1;
        }

        int changePos = 0;
        for (int i = 0; i < n; i++)
        {
            int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int cow = line[0] - 1, curPos = line[1];

            if (pos[cow] == -1)
                pos[cow] = curPos;
            else if (pos[cow] != curPos)
            {
                changePos++;
                pos[cow] = curPos;
            }
        }
        Console.WriteLine(changePos);
    }
}
