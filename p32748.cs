using System;

// p32748 - f(A + B) (S5)
// #수학 #문자열
// 2025.3.18 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] f = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] s = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int fa = s[0];
        int fb = s[1];

        int[] inv = new int[f.Length];
        for (int i = 0; i < f.Length; i++)
        {
            inv[f[i]] = i;
        }

        int a = Inv(inv, fa);
        int b = Inv(inv, fb);

        Console.WriteLine(F(f, a + b));
    }
    public static int F(int[] f, int n)
    {
        string s = n.ToString();
        string ret = "";
        foreach (char c in s)
        {
            ret += f[c - '0'].ToString();
        }
        return int.Parse(ret);
    }
    public static int Inv(int[] inv, int n)
    {
        string s = n.ToString();
        string ret = "";
        foreach (char c in s)
        {
            ret += inv[c - '0'].ToString();
        }
        return int.Parse(ret);
    }
}
