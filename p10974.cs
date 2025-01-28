using System;
using System.Linq;
using System.Text;
using System.IO;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(Console.ReadLine());
        int[] list = Enumerable.Range(1, n).ToArray();
        StringBuilder output = new();
        MakePermutation(n, 0, new bool[n], list, new int[n], output);
        sw.WriteLine(output);
        sw.Flush();
        sw.Close();
    }
    
    public static void MakePermutation(int n, int count, bool[] visited, int[] list, int[] cur, StringBuilder output)
    {
        if (count == n)
        {
            output.AppendLine(string.Join(" ", cur));
            return;
        }
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                cur[count] = list[i];
                MakePermutation(n, count + 1, visited, list, cur, output);
                visited[i] = false;
            }
        }
    }
}
