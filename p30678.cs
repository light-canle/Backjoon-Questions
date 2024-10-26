using System;
using System.Text;
using System.IO;

public class Program
{
    public static int[] pow = {1, 5, 25, 125, 625, 3125};
    public static void Main(string[] args)
    {
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(Console.ReadLine());
        bool[,] grid = new bool[pow[n], pow[n]];
        FillStar(grid, 0, 0, n);
        StringBuilder sb = new ();
        for (int i = 0; i < pow[n]; i++)
        {
            for (int j = 0; j < pow[n]; j++)
            {
                if (grid[i, j]) sb.Append("*");
                else sb.Append(" ");
            }
            sb.AppendLine();
        }
        sw.WriteLine(sb);
        sw.Flush();
        sw.Close();
    }

    public static void FillStar(bool[,] grid, int y, int x, int size)
    {
        if (size == 0)
        {
            grid[y, x] = true;
            return;
        }
        int unit = pow[size - 1];
        
        FillStar(grid, y, x + 2 * unit, size - 1);
        FillStar(grid, y + unit, x + 2 * unit, size - 1);
        for (int i = 0; i < 5; i++)
            FillStar(grid, y + 2 * unit, x + i * unit, size - 1);
        for (int i = 1; i < 4; i++)
            FillStar(grid, y + 3 * unit, x + i * unit, size - 1);
        FillStar(grid, y + 4 * unit, x + 1 * unit, size - 1);
        FillStar(grid, y + 4 * unit, x + 3 * unit, size - 1);
    }
}
