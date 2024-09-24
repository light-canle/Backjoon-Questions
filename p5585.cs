using System;

public class Program{
    public static void Main(string[] args){
        int N = int.Parse(Console.ReadLine());

		N = 1000 - N;
        int countCoin = N / 500;
        N %= 500;
        countCoin += N / 100;
        N %= 100;
        countCoin += N / 50;
        N %= 50;
        countCoin += N / 10;
        N %= 10;
        countCoin += N / 5;
        N %= 5;
        countCoin += N / 1;

        Console.WriteLine(countCoin);
    }
}