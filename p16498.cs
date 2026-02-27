// p16498 - 작은 벌점 (G5)
// #정렬 #이분 탐색 #완전 탐색
// 2026.2.28 solved (2.27)

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int p1Size = input[0], p2Size = input[1], p3Size = input[2];

List<int> p1 = sr.ReadLine().Split().Select(int.Parse).ToList();
List<int> p2 = sr.ReadLine().Split().Select(int.Parse).ToList();
List<int> p3 = sr.ReadLine().Split().Select(int.Parse).ToList();

p1.Sort();
p2.Sort();
p3.Sort();

// 최저 패널티를 찾는다
// 패널티는 세 수에 대해 셋 중 최댓값과 최솟값의 차이이다.
// p1, p2는 완전 탐색하고 p3은 이분 탐색한다. 시간 복잡도 : O(N^2 * logN)
int minPenalty = int.MaxValue;
for (int i = 0; i < p1Size; i++)
{
    for (int j = 0; j < p2Size; j++)
    {
        int a = Math.Min(p1[i], p2[j]);
        int b = Math.Max(p1[i], p2[j]);
        int c = FindBetween(a, b, p3);

        minPenalty = Math.Min(minPenalty, Penalty(a, b, c));
    }
}
Console.WriteLine(minPenalty);


// list에서 start와 end사이의 값을 찾는다.
// 만약 없다면, start 또는 end와의 차이가 최소인 것을 찾는다.
// list는 정렬되어 있어야 한다.
int FindBetween(int start, int end, List<int> list)
{
    int left = 0, right = list.Count - 1;
    while (right - left > 1)
    {
        int mid = (right + left) / 2;
        int cur = list[mid];
        // 사이값을 찾음
        if (start <= cur && cur <= end)
        {
            return cur;
        }
        else if (cur < start)
        {
            left = mid;
        }
        else
        {
            right = mid;
        }
    }
    // 여기까지 왔다면 후보는 list[left], list[right] 중 하나다.
    // 둘 중 구간의 양 끝 값 중 하나에 더 가까운 것을 찾는다.
    // 두 값이 전부 구간 왼쪽에 있음
    if (list[right] < start)
    {
        return list[right]; 
    }
    // 두 값이 전부 구간 오른쪽에 있음
    else if (list[left] > end)
    {
        return list[left];
    }
    // left는 구간 왼쪽, right는 구간 오른쪽에 있음
    else
    {
        return list[right] - end > start - list[left] ? list[left] : list[right];
    }
}

// 세 수의 최댓값과 최솟값의 차이를 구한다.
int Penalty(int a, int b, int c)
{
    int min = Math.Min(a, Math.Min(b, c));
    int max = Math.Max(a, Math.Max(b, c));
    return max - min;
}
