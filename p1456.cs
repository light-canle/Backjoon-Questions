using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// p1456 - 거의 소수, G5
/// 해결 날짜 : 2024/3/11
/// </summary>

/*
A ~ B 사이의 수중 소수의 N제곱(N>=2)이 몇 개 있는지 구하는 문제

1. 에라토스테네스의 체를 이용해서 2부터 Sqrt(B) + 1사이의 수 중 소수만 있는 배열을 구한다.
2. 제일 작은 소수인 2부터 시작해서 소수의 pow제곱이 A와 B사이에 있는 경우 count에 1 누적한다.
3. 2^pow가 B보다 커질때 까지 과정 2를 반복한다.

- 이 문제 해결에 애를 먹은 원인은 에라토스테네스 체의 구현 방식에 있었다. 예전에 하던 방식대로 진행하니 FindAll 함수가
List<int>를 복사하는 횟수가 너무 많아져 배열이 10,000,000개 정도되자 메모리 초과가 되었다.
// 2 ~ sqrt(B)까지의 소수 배열 제작
List<int> list = Enumerable.Range(2, (int)Math.Ceiling(Math.Sqrt(B))).ToList();
primeList = new List<int>();
int cur = list[0];
var limit = (int)Math.Sqrt(Math.Ceiling(Math.Sqrt(B))) + 1;
while (cur <= limit && list.Count > 0)
{
    cur = list[0];
    primeList.Add(cur);
    list = list.Where(x => x % cur != 0).ToList();
}
primeList.AddRange(list);
그래서 reference 사이트에 있는 방식을 차용해서 소수가 아닌 수에 -1을 표시한 뒤, 마지막에 -1이 아닌 수에 대해
FindAll로 가져오는 방식을 사용해서 이 함수의 호출을 최소화 하였다.
- 그리고 소수의 경우 a, b가 소수, m, n이 2 이상의 자연수 일때, a^m = b^n이 성립하는 조건이 a = b, m = n 밖에 없으므로
pow가 늘어날 때 수가 이전 것과 중복이 되는 걱정을 할 필요는 없다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        // input
        long[] input = Console.ReadLine()!.Split().Select(long.Parse).ToArray();
        (long A, long B) = (input[0], input[1]);

        // 2 ~ sqrt(B)까지의 소수 배열 제작
        List<int> list = Enumerable.Range(2, (int)Math.Ceiling(Math.Sqrt(B))).ToList();
        
        int cur = list[0];
        var limit = (int)Math.Sqrt(Math.Ceiling(Math.Sqrt(B))) + 1;
        int index = 0;
        
        while (cur <= limit && index < list.Count - 1)
        {
            while (list[index] == -1)
                index++;
            cur = list[index];
            for (int i = index + cur; i < list.Count - 1; i += cur) 
            {
                list[i] = -1;
            }
            index++;
        }

        var primeList = list.FindAll(x => x != -1);

        // 2^pow가 B보다 크지 않은 동안 반복
        int pow = 2;
        long count = 0;
        while (Math.Pow(2, pow) <= B)
        {
            for (int i = 0; i < primeList.Count; i++)
            {
                BigInteger candidate = BigInteger.Pow(primeList[i], pow);
                if (A <= candidate && candidate <= B) count++;
                else if (B < candidate) break;
            }
            pow++;
        }
        Console.WriteLine(count);
    }
}

// reference : https://velog.io/@max9106/Algorithm-%EC%97%90%EB%9D%BC%ED%86%A0%EC%8A%A4%ED%85%8C%EB%84%A4%EC%8A%A4%EC%9D%98-%EC%B2%B4