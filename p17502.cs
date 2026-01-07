// p17502 - 클레어와 팰린드롬 (B2)
// #문자열
// 2026.1.7 solved

int len = int.Parse(Console.ReadLine());
string str = Console.ReadLine();

List<char> ret = Enumerable.Repeat(' ', len).ToList();
int left = 0, right = len - 1;
while (left <= right)
{
    if (str[left] == '?')
    {
        if (str[right] == '?')
        {
            ret[left] = ret[right] = 'a';
        }
        else
        {
            ret[left] = ret[right] = str[right];
        }
    }
    else if (str[right] == '?')
    {
        ret[left] = ret[right] = str[left];
    }
    else
    {
        ret[left] = str[left];
        ret[right] = str[right];
    }
    left++; right--;
}
Console.WriteLine(string.Join("", ret));
