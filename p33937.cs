// p33937 - 태권도와 복싱을 합한 운동 (B1)
// #문자열
// 2026.2.9 solved

string s1 = Console.ReadLine();
string s2 = Console.ReadLine();

int s1Prefix = PrefixLength(s1);
int s2Prefix = PrefixLength(s2);

if (s1Prefix < 0 || s2Prefix < 0)
{
    Console.WriteLine("no such exercise");
}
else
{
    Console.WriteLine(string.Concat(s1.AsSpan(0, s1Prefix), s2.AsSpan(0, s2Prefix)));
}

int PrefixLength(string s)
{
    int vowelCount = 0;
    int prefixLen = -1;
    for (int i = 0; i < s.Length; i++)
    {
        if (IsVowel(s[i]))
        {
            vowelCount++;
        }
        else
        {
            if (vowelCount > 0)
            {
                prefixLen = i;
                break;
            }
        }
    }
    return prefixLen;
}

bool IsVowel(char c)
{
    return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
}
