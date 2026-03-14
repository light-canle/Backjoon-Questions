// p1411 - 비슷한 단어 (S2)
// #문자 #완전 탐색
// 2026.3.15 solved (3.14)

int n = int.Parse(Console.ReadLine());
List<List<int>> converted = new();
for (int i = 0; i < n; i++)
{
    converted.Add(ConvertToIntList(Console.ReadLine()));
}

int match = 0;
for (int i = 0; i < n - 1; i++)
{
    for (int j = i + 1; j < n; j++)
    {
        if (Same(converted[i], converted[j])) match++;
    }
}
Console.WriteLine(match);

// 문자열을 동일 알파벳은 동일한 숫자로 1-1 대응시킨 숫자 배열로 반환한다.
// 숫자는 문자열을 왼쪽부터 조사했을 때 가장 먼저 등장한 것부터 1, 2, ... 이렇게 번호를 붙인다.
List<int> ConvertToIntList(string s)
{
    int[] found = new int[26];
    List<int> ret = new();
    int kind = 0;
    for (int i = 0; i < s.Length; i++)
    {
        // 알파벳 최초 발견
        if (found[s[i] - 'a'] == 0)
        {
            found[s[i] - 'a'] = ++kind;
        }
        ret.Add(found[s[i] - 'a']);
    }
    return ret;
}

// 두 정수 리스트가 같은지 판정
bool Same(List<int> a, List<int> b) 
{
    if (a.Count != b.Count) return false;
    for (int i = 0; i < a.Count; i++)
    {
        if (a[i] != b[i]) return false;
    }
    return true;
}
