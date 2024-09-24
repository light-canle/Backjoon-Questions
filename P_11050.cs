using System;
using System.Linq;
using System.Collections.Generic;

public class P11050{
    static int factorial(int n){
    if (n == 0 || n == 1) return 1;
    int product = 1;
    for (int i = 2; i <= n; i++){
        product *= i;
    }
    return product;
    }

    static void Main(string[] args){
        int[] nums = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        int n = nums[0];
        int k = nums[1];
        Console.WriteLine( factorial(n) / (factorial(k) * factorial(n - k)) );
    }
}