// p1132 - 합 (G3)
// #그리디
// 2026.3.10 solved

int n = int.Parse(Console.ReadLine());
string[] nums = new string[n]; // 알파벳 문자열
int existCount = 0; // A~J 중 존재하는 것의 개수
int maxLen = 0; // nums에 있는 문자열 중 제일 긴 것의 길이
for (int i = 0; i < n; i++)
{
    nums[i] = Console.ReadLine()!;
    maxLen = Math.Max(nums[i].Length, maxLen);
}
// A~J가 존재하는 지 확인
bool[] exist = new bool[10]; // 각 알파벳의 존재 여부
bool[] canZero = Enumerable.Repeat(true, 10).ToArray(); // 각 알파벳 중 0이 될 수 있는 것들
foreach (string str in nums)
{
    for (int i = 0; i < str.Length; i++)
    {
        if (i == 0)
        {
            canZero[str[i] - 'A'] = false; // 맨 앞자리 알파벳은 0이 되면 안된다.
        }
        exist[str[i] - 'A'] = true;
    }
}
// 해당 알파벳이 대응된 자릿수 (0~9)
Dictionary<char, int> mapped = new();
for (int i = 0; i < 10; i++)
{
    if (exist[i])
    {
        existCount++;
        mapped[Convert.ToChar('A' + i)] = -1; // -1로 초기화
    }
}

// 각 문자열 길이를 제일 긴 것과 동일하게 맞춘다. (앞에 0을 채움)
for (int i = 0; i < n; i++)
{
    nums[i] = new string('0', maxLen - nums[i].Length) + nums[i];
}

// 각 자리에 등장할 때마다 10^(maxLen - 1 - idx)를 더한다.
// 앞 자리에 올 수록, 많이 등장할 수록 값이 크므로, 그 알파벳이 더 큰 자릿수를 부여받게 된다.
Dictionary<char, long> value = new();
for (int i = 0; i < 10; i++)
{
    if (exist[i]) value[Convert.ToChar('A' + i)] = 0;
}
for (int i = 0; i < maxLen; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (nums[j][i] != '0')
        {
            value[nums[j][i]] += (long)Math.Pow(10, maxLen - i - 1);
        }
    }
}

// existCount = 10일 때, 0이 될 수 있는 알파벳 중에서 앞에서 구한 값이 제일 작은 것에 0 부여
if (existCount == 10)
{
    var zeroOrder = value.Where(x => canZero[x.Key - 'A'])
                         .OrderBy(x => x.Value)
                         .ToList();
    // 제일 작은 것에 0 부여
    mapped[zeroOrder[0].Key] = 0;
}

// 그 후 값이 큰 순으로 큰 자릿값을 부여
var order = value.OrderBy(x => -x.Value)
                 .ToList();
int digit = 9;
foreach (var item in order)
{
    if (mapped[item.Key] != -1) continue; // 앞에서 0을 부여받은 알파벳은 건드리지 않음
    mapped[item.Key] = digit--;
}

// 계산된 자릿수를 대입해 실제 합 계산
long sum = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < maxLen; j++)
    {
        if (nums[i][j] != '0') sum += ((long)mapped[nums[i][j]] * (long)Math.Pow(10, maxLen - j - 1));
    }
}
Console.WriteLine(sum);
