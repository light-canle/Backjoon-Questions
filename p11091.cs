// p11091 - 알파벳 전부 쓰기 (B2)
// #문자열
// 2026.2.12 solved

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string str = Console.ReadLine().ToLower();
    bool[] hasContain = new bool[26];
    foreach (char c in str)
    {
        if ('a' <= c && c <= 'z')
        {
            hasContain[c - 'a'] = true;
        }
    }
    string missing = "";
    for (int j = 0; j < 26; j++)
    {
        if (!hasContain[j])
        {
            missing += Convert.ToChar('a' + j);
        }
    }
    if (missing != "")
    {
        Console.WriteLine($"missing {missing}");
    }
    else
    {
        Console.WriteLine("pangram");
    }
}
