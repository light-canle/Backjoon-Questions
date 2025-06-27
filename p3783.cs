using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

// p3783 - 세곱근 (G1)
// #이분 탐색 #큰 수 연산 #임의 정밀도
// 2025.6.27 solved

// 이 문제를 풀기 위해 구현을 간소화한 임의 정밀도의 부동 소수점 자료형
// 덧셈, 곱셈, 뺄셈, 2로 나누기, 대소 비교만을 지원한다.
public class SimpleDecimal
{
    // 실수를 Mantissa * 10 ^ Exponent의 형태로 저장한다.
    // Exponent는 양이 아닌 정수여야 한다.
    public BigInteger Mantissa { get; private set; }
    public int Exponent { get; private set; }

    public SimpleDecimal(BigInteger n)
    {
        Mantissa = n;
        Exponent = 0;
    }

    public SimpleDecimal(BigInteger m, int e)
    {
        if (e > 0)
        {
            throw new ArgumentException("Exponent must be non-positive");
        }
        Mantissa = m;
        Exponent = e;
    }

    public static SimpleDecimal operator +(SimpleDecimal lhs, SimpleDecimal rhs)
    {
        // 두 수의 지수를 더 작은 쪽으로 통일시킨뒤, 큰 쪽의 가수에 10의 거듭제곱을 곱한 뒤 더한 것을 반환한다.
        // 이때 거듭제곱의 지수는 두 지수의 차이로 한다.
        // Ex) 7 * 10^-2 + 8 ^ 10^-1 = 10^-2 * (7 + 8 * 10) = 87 * 10^-2 
        if (lhs.Exponent < rhs.Exponent)
        {
            return new SimpleDecimal(lhs.Mantissa + rhs.Mantissa * BigInteger.Pow(10, rhs.Exponent - lhs.Exponent), lhs.Exponent);
        }
        else
        {
            return new SimpleDecimal(rhs.Mantissa + lhs.Mantissa * BigInteger.Pow(10, lhs.Exponent - rhs.Exponent), rhs.Exponent);
        }
    }

    public static SimpleDecimal operator -(SimpleDecimal lhs, SimpleDecimal rhs)
    {
        // 덧셈과 동일한 방식으로 계산하되, 여기서는 가수끼리 빼준다.
        if (lhs.Exponent < rhs.Exponent)
        {
            return new SimpleDecimal(lhs.Mantissa - rhs.Mantissa * BigInteger.Pow(10, rhs.Exponent - lhs.Exponent), lhs.Exponent);
        }
        else
        {
            return new SimpleDecimal(lhs.Mantissa * BigInteger.Pow(10, lhs.Exponent - rhs.Exponent) - rhs.Mantissa, rhs.Exponent);
        }
    }

    public static SimpleDecimal operator *(SimpleDecimal lhs, SimpleDecimal rhs)
    {
        // 가수는 가수끼리 곱하고, 지수는 지수끼리 더해준다.
        return new SimpleDecimal(lhs.Mantissa * rhs.Mantissa, lhs.Exponent + rhs.Exponent);
    }

    public static bool operator <(SimpleDecimal lhs, SimpleDecimal rhs)
    {
        // 여기서도 덧셈에서 처럼, 지수를 통일한다. 지수가 더 작은 쪽으로 통일하며, 지수가 큰 쪽에서는 지수의 차이만큼 가수에 10의 거듭제곱을 곱한다.
        // 그 다음 가수끼리 비교한 결과가 두 수의 대소 관계가 된다.
        if (lhs.Exponent < rhs.Exponent)
        {
            return lhs.Mantissa < rhs.Mantissa * BigInteger.Pow(10, rhs.Exponent - lhs.Exponent);
        }
        else
        {
            return (lhs.Mantissa * BigInteger.Pow(10, lhs.Exponent - rhs.Exponent)) < rhs.Mantissa;
        }
    }

    public static bool operator >(SimpleDecimal lhs, SimpleDecimal rhs)
    {
        if (lhs.Exponent < rhs.Exponent)
        {
            return lhs.Mantissa > rhs.Mantissa * BigInteger.Pow(10, rhs.Exponent - lhs.Exponent);
        }
        else
        {
            return (lhs.Mantissa * BigInteger.Pow(10, lhs.Exponent - rhs.Exponent)) > rhs.Mantissa;
        }
    }

    // 이분 탐색을 하기 위해 존재하는 함수로 2로 나눈 값을 반환한다.
    public SimpleDecimal Half()
    {
        // 지수에 1을 빼서 10을 나눈 뒤 가수에 5를 곱하는 방식으로 구현했다.
        return new SimpleDecimal(Mantissa * 5, Exponent - 1);
    }

    // n ^ e를 구한다. (e는 음이 아닌 정수)
    public static SimpleDecimal Pow(SimpleDecimal n, int e)
    {
        SimpleDecimal ret = new SimpleDecimal(1);
        for (int i = 0; i < e; i++)
        {
            ret = ret * n;
        }
        return ret;
    }
    // 절댓값을 구한다.
    public static SimpleDecimal Abs(SimpleDecimal n)
    {
        if (n.Mantissa < 0) return new SimpleDecimal(-n.Mantissa, n.Exponent);
        else return n;
    }

    // n의 세제곱근을 구한다.
    // 문제에서 소수점 10자리 까지 정확하게 구하라고 했으므로, 절대 오차를 10^-12로 지정
    public static SimpleDecimal CubeRoot(SimpleDecimal n)
    {
        SimpleDecimal epsilon = new SimpleDecimal(1, -12); 
        SimpleDecimal low = new SimpleDecimal(1), high = n;
        SimpleDecimal mid = (low + high).Half();
        // 차이가 엡실론 이하가 될때까지 반복
        // SimpleDecimal.Pow(mid, 3) < n을 넣은 이유는 8의 세제곱근을 구할 때, 이 조건이 없으면 답이 1.99999....가 나오는데,
        // 문제에서는 2.0000000000를 요구하기 때문이다. 그래서 탐색이 끝날 시점에 mid가 n의 세제곱근보다 엡실론보다 작은 차이만큼 크도록 설정해서
        // 정수 제곱근이 원하는 형태로 나오도록 했다.
        while (SimpleDecimal.Abs(SimpleDecimal.Pow(mid, 3) - n) > epsilon || SimpleDecimal.Pow(mid, 3) < n)
        {
            if (SimpleDecimal.Pow(mid, 3) > n)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
            mid = (low + high).Half();
        }
        return mid;
    }

    // 소수 형태로 수를 나타낸다.
    // 뒤의 불필요한 0을 제거해주기는 하나 소수점은 제거해주지 않음
    public override string ToString()
    {
        bool neg = Mantissa < 0; // 음수의 경우 - 부호를 붙이기 위함이다.
        int toLeft = -Exponent; // 필요한 소수점 아래 자릿수
        string str = BigInteger.Abs(Mantissa).ToString();
        int digit = str.Length;

        if (toLeft == 0) return Mantissa.ToString(); // 소수점 불필요
        // 전체 가수의 자릿수가 소수점 아래 자릿수보다 크다.
        // 123.45의 형태로 가수의 중간에 소수점이 들어간다.
        // digit - toLeft번 인덱스에 '.'이 들어간다.
        if (toLeft < digit)
        {
            return ((neg ? "-" : "") + str.Substring(0, digit - toLeft) + "." + str.Substring(digit - toLeft)).TrimEnd('0');
        }
        // 전체 가수의 자릿수가 소수점 아래 자릿수와 같다.
        // 0.1234의 형태로 0. 뒤에 가수가 들어간다.
        else if (toLeft == digit)
        {
            return ((neg ? "-" : "") + "0." + str).TrimEnd('0');
        }
        // 전체 가수의 자릿수가 소수점 아래 자릿수보다 작다.
        // 0.001234의 형태로 가수와 '.'사이에 0을 toLeft - digit개 만큼 삽입한 형태를 반환한다.
        else
        {
            return ((neg ? "-" : "") + "0." + new string('0', toLeft - digit) + str).TrimEnd('0');
        }
    }

    // 지정한 자리만큼 소수점 자리를 포함한 형태를 반환한다. 그 아랫자리는 반올림 하지 않고 버림한다.
    // digit = 5일 때, 5.231은 5.23100이 되고, 1.2345678은 1.23456이 된다.
    public string Precision(int digit)
    {
        string str = this.ToString();
        int dot = str.IndexOf('.');
        // 소수점이 없음
        if (dot == -1)
        {
            return str + "." + new string('0', digit);
        }
        // 소수점의 위치를 통해 이미 있는 소수점 아래 자릿수를 구함
        int decimalPlace = str.Length - dot - 1;
        // 소수점 아래 자릿수가 출력하고자 하는 자릿수보다 작음 -> 모자란 만큼 0을 보충한다.
        if (decimalPlace < digit)
        {
            return str + new string('0', digit - decimalPlace);
        }
        // digit의 개수만큼 자릿수를 남기고 반환한다.
        else
        {
            return str.Substring(0, dot + digit + 1);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine(SimpleDecimal.CubeRoot(new SimpleDecimal(n)).Precision(10)); // 세제곱근을 소수점 10째 자리까지 출력
        }
    }
}
