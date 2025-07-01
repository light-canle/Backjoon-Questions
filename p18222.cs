using System;

// p18222 - 투에-모스 문자열 (S2)
// #재귀
// 2025.7.1 solved

public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());

        Console.WriteLine(Find(n) ? 1 : 0);
    }

    // 해당 자리의 문자가 0이면 false, 1이면 true
    public static bool Find(long n)
    {
        // 처음 두 자리는 기저 사례로 반환
        if (n == 1)
        {
            return false;
        }
        else if (n == 2)
        {
            return true;
        }
        /*
        2^a < k <= 2^(a+1)인 k번째 자리의 문자는
        k - 2^a번째 자리의 문자와 반대되는 문자이다.
        문자열을 2배로 늘릴 때 기존과 반대되는 배치로 뒤에 나열하기 때문에
        k번째 문자와 k - 2^a번째 문자는 반드시 서로 반대되는 문자가 된다.
        모든 단계에서 이것이 성립하기에 n에 대해 n보다 작은 2의 거듭제곱을 구하고
        n - 2^a번째 자리를 재귀적으로 구한 뒤 그것의 반대를 반환한다.
        */
        long partSize = MaximumPow2(n);

        return !Find(n - partSize);
    }

    // n 미만의 가장 큰 2의 거듭제곱을 반환
    public static long MaximumPow2(long n)
    {
        long two62 = 4_611_686_018_427_387_904;
        if (n <= 0) return -1;
        if (n > two62) return two62;
        else if (n == two62) return two62 / 2;
        
        long ret = 1;
        while (ret * 2 < n) ret *= 2;
        return ret;
    }
}
