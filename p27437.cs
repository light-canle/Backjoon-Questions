// p27437 - 분수찾기 2 (S1)
// #수학 #이분 탐색
// 2026.2.19 solved

long n = long.Parse(Console.ReadLine());

long low = 1, high = 1414213562;

// k(k+1)/2 <= n < (k+1)(k+2)/2인 k를 찾는다.
while (high - low > 1)
{
    long mid = (low + high) / 2;
    // k(k+1)/2 < n인 경우 조건에 부합하지 않음
    if (Sum(mid) < n)
    {
        low = mid + 1;
    }
    else
    {
        high = mid;
    }
}

// 두 후보 중 하나가 우리가 찾는 k가 된다.
long section, order;
if (Sum(low) >= n)
{
    section = low;
}
else
{
    section = high;
}

order = n - Sum(section - 1);
// 1/k -> 2/(k-1) -> ... -> k/1
if (section % 2 == 0)
{
    Console.WriteLine($"{order}/{section + 1 - order}");
}
// k/1 -> (k-1)/2 -> ... -> 1/k
else
{
    Console.WriteLine($"{section + 1 - order}/{order}");
}

long Sum(long k)
{
    return k * (k + 1) / 2;
}
