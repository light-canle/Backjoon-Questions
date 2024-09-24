using System;
using System.Linq;
using System.Collections.Generic;

public class P10773{
    static void Main(string[] args){
        int N = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < N; i++){
            int input = int.Parse(Console.ReadLine());
            if (input == 0){
                stack.Pop();
            }
            else{
                stack.Push(input);
            }
        }
        Console.WriteLine(stack.Sum());
    }
}