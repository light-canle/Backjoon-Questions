// p1443 - 망가진 계산기 (G3)
// #백트래킹
// 2026.2.10 solved

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int digit = input[0], product = input[1];

Console.WriteLine(FindMax((int)Math.Pow(10, digit), product, 0, 1, 2));

// numberLimit보다 작고 2~9사이의 수를 productLimit번 만큼 곱해서 나올 수 있는
// 자연수의 최댓값을 찾는다. 그런 수가 없다면 -1을 반환한다.
// depth는 지금까지 곱한 횟수이다.
// curNum은 지금까지 곱해서 나온 결과이다.
// front는 지금까지 곱한 2~9까지의 수 중 값이 가장 작은 것이다.
int FindMax(int numberLimit, int productLimit, int depth, int curNum, int front)
{
    // 탐색 종료
    if (productLimit == depth)
    {
        return curNum;
    }

    int max = -1;
    // front부터 탐색
    for (int p = front; p <= 9; p++)
    {
        // curNum에 p를 곱한 수가 범위 안이면 그 수로 재귀를 수행한다.
        if (curNum * p < numberLimit)
        {
            int cur = FindMax(numberLimit, productLimit, depth + 1, curNum * p, p);
            // 최댓값 갱신
            max = Math.Max(max, cur);
        }
    }
    return max;
}
