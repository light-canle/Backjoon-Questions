using System;

// p2885 - 초콜릿 식사 (S2)
// #비트마스킹 #그리디
// 2025.2.26 solved

public class Program
{
    public static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine());

        // k이상의 가장 작은 2의 거듭 제곱을 구한다.
        int pow = 0;
        while ((1 << pow) < k)
        {
            pow++;
        }
        // k를 2진수로 나타냈을 때 가장 작은 자리에 나타나는 1의 위치를 구한다.
        int lsb = 0;
        while (((1 << lsb) & k) == 0)
        {
            lsb++;
        }
        /*
        초콜릿을 정확하게 k개 만큼 얻기 위해서는
        k의 합을 이루는 가장 작은 2의 거듭제곱 크기의 조각이 나올때 까지 자르면 된다. 그래서 최소 다르기 횟수는 pow - lsb가 된다.
        */
        int toCut = pow - lsb;
        int minSize = (1 << pow);

        Console.WriteLine($"{minSize} {toCut}");
    }
}
