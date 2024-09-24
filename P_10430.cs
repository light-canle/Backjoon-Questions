using System;
using System.Linq;

public class P10430{
    static void Main(string[] args){
        int[] input = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
        int a = input[0];
        int b = input[1];
        int c = input[2];
        Console.WriteLine($"{(a + b) % c}");
        Console.WriteLine($"{((a % c) + (b % c)) % c}");
        Console.WriteLine($"{(a * b) % c}");
        Console.WriteLine($"{((a % c) * (b % c)) % c}");
    }
}