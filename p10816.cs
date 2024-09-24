using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p10816 - 숫자 카드 2
/// 시작 날짜 : 2020/9/5
/// 해결 날짜 : 2023/8/24
/// </summary>

/*
문제에서 제시된 수의 범위는 -10,000,000 ~ 10,000,000이다.
시간 복잡도를 O(N)으로 하기 위해서, 크기가 20,000,001칸인 배열을 생성하고,
숫자 카드의 배열에 들어있는 수를 받아와, -10,000,000은 인덱스 1, -9,999,999는 인덱스 2,
... 0은 인덱스 10,000,001, ... 10,000,000은 인덱스 20,000,001번에 저장하기 위해 값에 10,000,000을 더했다.
그 후 개수를 알고 싶은 수의 카드 배열 내 개수를 가져와서 출력한다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();

        int listSize = int.Parse(sr.ReadLine());
        List<int> list = sr.ReadLine().Split().Select(x => int.Parse(x)).ToList();

        int numberCount = int.Parse(sr.ReadLine());
        List<int> candidate = sr.ReadLine().Split().Select(x => int.Parse(x)).ToList();

        List<int> count = Enumerable.Repeat<int>(0, 20_000_001).ToList();
        for (int i = 0; i < listSize; i++)
        {
            count[list[i] + 10_000_000]++;
        }

        for (int i = 0; i < numberCount; i++)
        {
            output.Append(count[candidate[i] + 10_000_000].ToString() + ' ');
        }

        sw.WriteLine(output.ToString());

        sw.Flush();
        sw.Close();
        sr.Close();
    }
}