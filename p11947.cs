#pragma warning disable CS8604, CS8602, CS8600

// p11947 - 이런 반전이 (S3)
// #수학
// 2026.1.9 solved

/*
문제에서 정의한 수의 '사랑스러움' 수치에는 다음과 같은 특징이 있다.
(1) n자리 자연수 중 최솟값인 100...000부터 시작해서 499...999까지는 사랑스러움 수치가 계속해서 증가한다.
사랑스러움 수치는 499...999와 500...000에서 최대치를 찍은 후 500...001부터는 계속해서 감소해서
n자리 자연수 중 최댓값인 999...999는 반전수가 0이므로 사랑스러움도 0이다.
(2) n자리 자연수 500...000의 '사랑스러움'보다 n+1자리 자연수 100...000의 '사랑스러움'이 항상 더 크다.

이 두 사실을 이용해서 1부터 n까지의 수 중 사랑스러움의 최댓값은 아래와 같이 찾을 수 있다.
(1) n의 자릿수 k를 구한다.
(2) 만약 n이 5 * 10^(k-1) 이하라면 n의 사랑스러움이 최댓값이 된다. 반열린 구간 [ 10^(k-1), 5 * 10^(k-1) )에서는 사랑스러움이 증가하기 때문이다.
(3) 만약 n이 5 * 10^(k-1)보다 크다면, 5 * 10^(k-1)의 사랑스러움이 최댓값이 된다. 반열린 구간 (5 * 10^(k-1), 10^k - 1]에서는 사랑스러움이 감소하기 때문이다.
Note : 위의 (2)번에 의해 n이 속한 자릿수보다 더 작은 자연수는 조사할 필요가 없다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            int pow = n.ToString().Length - 1;
            long middle = (long)Math.Pow(10, pow) * 5;
            // n이 
            if (n <= middle)
            {
                Console.WriteLine(Lovely(n));
            }
            else
            {
                Console.WriteLine(Lovely(middle));
            }
        }
    }

    // 반전수를 구하는 함수
    public static long Reversal(long k)
    {
        string s = k.ToString();
        string ret = "";
        // 반전수는 어떤 수의 각 자릿수 j를 9-j로 바꾼 것이다.
        // 앞에 생긴 0은 무시된다. ex) 12345 -> 87654 || 912 -> 087 -> 87 (앞의 0 무시)
        foreach (var i in s)
        {
            ret += '9' - i;
        }
        return long.Parse(ret);
    }

    public static long Lovely(long k)
    {
        return k * Reversal(k);
    }
}
