using System;

public class P9095{
    static int[] data;
    static void Main(string[] args){
        data = new int[11];
        int T = int.Parse(Console.ReadLine());
        for (int i = 0; i < T; i++){
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{Count(n)}");
        }
    }
    static int Count(int n){
        if (data[n] != 0) return data[n];
        if (n == 1){
            return data[1] = 1;
        }
        if (n == 2){
            return data[2] = 2;
        }
        if (n == 3){
            return data[3] = 4;
        }
        return data[n] = Count(n-1) + Count(n-2) + Count(n-3);
    }
}