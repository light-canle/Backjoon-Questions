// p1864 - 문어 숫자 (B2)
// #문자열 #사칙연산
// 2026.2.19 solved (2.18)

// -1 ~ 7까지 자릿수
char[] digit = { '/', '-', '\\', '(', '@', '?', '>', '&', '%'};
Dictionary<char, int> value = new();
for (int i = -1; i <= 7; i++)
{
    value[digit[i + 1]] = i;
}
while (true)
{
    string input = Console.ReadLine();
    if (input == "#")
    {
        return;
    }
    int pow = input.Length - 1;
    int ret = 0;
    foreach (char c in input)
    {
        ret += value[c] * (int)Math.Pow(8, pow);
        pow--;
    }
    Console.WriteLine(ret);
}
