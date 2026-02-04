// p2830 - 행성 X3 (G3)
// #비트마스킹
// 2026.1.30 solved

/*
k개의 수 중 2개를 골라 xor 연산한 것을 모두 더한 것의 합을 구하는 문제
모든 수를 이진수로 나타낸 다음 1의 자리, 2의 자리, ... 2^19의 자리의 비트를 조사해
1의 개수를 센다. 그 후 비트가 (0인 것의 개수) * (1인 것의 개수) * (자릿값)을 곱한 것을 누적하면
모든 수를 xor한 것의 합과 같아진다.

각각의 수의 상한이 100만이고, 2^19 < 10^6 < 2^20이므로 이진수로 최대 20자리 이다.
1부터 2^19까지 각각의 수와 and 연산을 하면 해당 자리 비트가 1인 것의 개수를 알 수 있다.
*/

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

int n = int.Parse(sr.ReadLine());
List<int> nums = new();
for (int i = 0; i < n; i++)
{
    nums.Add(int.Parse(sr.ReadLine()));
}

long ret = 0;
for (int i = 0; i < 20; i++)
{
    int cur = 1 << i;
    int oneCount = 0;
    foreach (var num in nums)
    {
        if ((cur & num) != 0) oneCount++;
    }
    ret += (long)cur * oneCount * (n - oneCount);
}
Console.WriteLine(ret);
