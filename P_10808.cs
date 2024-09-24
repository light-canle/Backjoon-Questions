using System;

public class P10808{
    static void Main(string[] args){
        string input = Console.ReadLine();

        int[] num_alphabet = new int[26];
        
        foreach (char c in input){
            num_alphabet[(int)c - 97] += 1;
        }

        foreach (int num in num_alphabet){
            Console.Write($"{num} ");
        }
    }
}