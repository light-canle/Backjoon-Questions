using System;

public class P11727{
    static int[1001] data = new int[1001];
    static int Count(int n){
        // 기저 사례
        if (n == 1) 
        {
            data[n] = 1;
        }
        if (n == 2) 
        {
            data[n] = 3;
        }

        // 데이터가 이미 있는 경우 반환
        if (data[n] != 0) return data[n-1];

        // 재귀 f(n) = f(n-1) + 2 * f(n-2)
        data[n] = Count(n-1) + 2 * Count(n-2);
        return data[n];
    }
    static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine($"{Count(n)}");
    }
}