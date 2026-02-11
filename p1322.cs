using System.Text;

// p1322 - X와 K (G4)
// #비트마스킹
// 2026.2.11 solved

/*
주어진 x에 대하여 x + y = x | y가 되는 자연수 y를 크기 순으로 정렬 했을 때
k번째를 구하는 문제이다.

우선, x + y = x | y를 만족하려면 x와 y를 이진수로 나타낸 뒤 길이를 맞추었을 때, 둘 다 비트가 1이 되는 위치가 없어야 한다.
x = 101(2)로 두고 조건을 만족시키는 y를 나열하면,

x  = 00101
-----------
y1 = 00010
y2 = 01000
y3 = 01010
y4 = 10000
y5 = 10010
즉, k번째 y는 k를 이진법으로 나타낸 다음, x에서 비트가 1이 아닌 자리에
k의 이진법 표현을 뒷 자리 부터 하나씩 대입한 것과 같다.
*/

long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
long x = input[0], k = input[1];

string xBit = Convert.ToString(x, 2);
string kBit = Convert.ToString(k, 2);

int xPtr = xBit.Length - 1; 
int kPtr = kBit.Length - 1; // 뒤의 자리 부터 채워넣기 위해 포인터는 끝에서 시작

StringBuilder ret = new();
while (kPtr >= 0)
{
    // x가 끝난 경우 앞에 0이 있다고 가정 - k의 현재 자리를 그대로 채워 넣는다.
    if (xPtr < 0)
    {
        ret.Insert(0, kBit[kPtr]);
        kPtr--;
        continue;
    }
    // x 비트가 1인 경우 그 자리에는 k의 자리 대신 0을 넣는다.
    if (xBit[xPtr] == '1')
    {
        ret.Insert(0, '0');
    }
    // k의 현재 자리를 그대로 채워 넣는다.
    else
    {
        ret.Insert(0, kBit[kPtr]);
        kPtr--;
    }
    xPtr--;
}
Console.WriteLine(Convert.ToInt64(ret.ToString(), 2));
