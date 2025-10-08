using System;

// p33810 - SciComLove (2025) (B4)
// #문자열
// 2025.10.8 solved

public class Program {
	public static void Main(string[] args) {
        string str = Console.ReadLine();
        string comp = "SciComLove";
        int diff = 0;
        for (int i = 0; i < 10; i++)
        {
            diff += str[i] != comp[i] ? 1 : 0;
        }
        Console.WriteLine(diff);
	}
}
