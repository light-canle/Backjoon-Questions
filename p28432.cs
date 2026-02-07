// p28432 - 끝말잇기 (S5)
// #구현 #문자열
// 2026.2.8 solved

int n = int.Parse(Console.ReadLine());
int pPos = 0;
List<string> list = new();
for (int i = 0; i < n; i++)
{
    string temp = Console.ReadLine();
    if (temp == "?") pPos = i;
    list.Add(temp);
}

int k = int.Parse(Console.ReadLine());
List<string> candidate = new();
for (int i = 0; i < k; i++)
{
    candidate.Add(Console.ReadLine());
}
// 특이 케이스
// 단어가 1개인 경우 후보군도 1개임이 보장됨
if (n == 1)
{
    Console.WriteLine(candidate[0]);
    return;
}

foreach (string c in candidate)
{
    // ?가 맨 앞 : 바로 뒷 단어의 앞 글자와 비교
    if (pPos == 0)
    {
        if (list[pPos + 1][0] == c[^1] && !list.Contains(c))
        {
            Console.WriteLine(c);
            break;
        }
    }
    // ?가 맨 뒤 : 바로 앞 단어의 끝 글자와 비교
    else if (pPos == n - 1)
    {
        if (list[pPos - 1][^1] == c[0] && !list.Contains(c))
        {
            Console.WriteLine(c);
            break;
        }
    }
    // 그 외 : 바로 앞 단어와 바로 뒤 단어의 각각 맨 끝과 맨 앞 자와 비교한다.
    else
    {
        if (list[pPos - 1][^1] == c[0] && list[pPos + 1][0] == c[^1] && !list.Contains(c))
        {
            Console.WriteLine(c);
            break;
        }
    }
}
