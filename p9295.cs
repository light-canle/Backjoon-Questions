using System;

public class Program {
  public static void Main() {
    int n = int.Parse(Console.ReadLine());
    for (int i = 1; i <= n; i++)
    {
        int[] dice = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Console.WriteLine($"Case {i}: {dice[0]+dice[1]}");
    }
  }
}
