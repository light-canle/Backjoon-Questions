using System;

public class P10884{
    static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"{Count(n)}");
    }
    static long Count(int n){
        long sum = 0;
        // 0번째 열이 실제 계단 수들의 합이고,
        // 1, 2번째 열은 다음 계단 수 계산을 위한 공간으로 쓰인다.
        long[,] data = new long[3, 5];
        // 한 자리 계단 수 중 끝자리가 4,5 / 3,6 / 2,7 / 1,8 인 것은 각각 2개씩 있다.
        data[0, 0] = 2;
        data[0, 1] = 2;
        data[0, 2] = 2;
        data[0, 3] = 2;
        // 한 자리 계단 수 중 끝자리가 0,9 인 것은 9 하나 뿐이다.
        data[0, 4] = 1;
        // 기저 사례
        if (n == 1){
            // 한 자리 계단 수의 개수
            return 9;
        }

        for (int i = 1; i < n; i++){
            for (int j = 0; j < 4; j++){
                data[1, j] = data[0, j+1] % 1_000_000_000;
            }
            for (int j = 1; j < 5; j++){
                data[2, j] = data[0, j-1] % 1_000_000_000;
            }
            data[2, 0] = data[0, 0] % 1_000_000_000;

            for (int j = 0; j < 5; j++){
                data[0, j] = (data[1, j] + data[2, j]) % 1_000_000_000;
            }
        }
        
        for(int i = 0; i < 5; i++){
            sum += data[0, i];
        }
        return sum;
    }
}