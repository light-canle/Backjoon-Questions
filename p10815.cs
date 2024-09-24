using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p10815 - 숫자 카드, S5
/// 시작 날짜 : 2023/8/18
/// 해결 날짜 : 2023/8/30
/// </summary>

/*
기존의 알고리즘은 O(n^2)으로 시간 초과를 야기했다.
그래서 새로운 풀이에서는 메모리를 20MB정도 더 쓰는 대신
O(n)으로 바꿔서 문제를 해결할 수 있었다.
*/

public class Program{
    public static void Main(string[] args){
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        int N = int.Parse(sr.ReadLine());
        List<int> list = sr.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();
        int M = int.Parse(sr.ReadLine());
        List<int> have_card = sr.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();

        // -10M~10M의 존재 여부를 판단하는 20,000,001배열
        byte[] contain = Enumerable.Repeat(0, 20_000_001).Select(x => (byte)x).ToArray();

        // 존재 여부 결정
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < list.Count(); i++)
        {
            contain[list[i] + 10_000_000] = 1;
        }

        for (int i = 0; i < have_card.Count(); i++)
        {
            if (contain[have_card[i] + 10_000_000] == 1)
            {
                sb.Append("1 ");
            }
            else
            {
                sb.Append("0 ");
            }
        }
        
        // 출력
        Console.WriteLine(sb.ToString());

        sr.Close();
    }
}

/*
2023.8.18 코드
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
// 미해결 문제 - 시간 초과
public class Program{
    public static void Main(string[] args){
        int N = int.Parse(Console.ReadLine());
        List<int> list = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();
        int M = int.Parse(Console.ReadLine());
        List<int> have_card = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();

        //List<int> isContain = new List<int>();

        // 0, 1 결정
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < have_card.Count(); i++){
            if (list.Contains(have_card[i])){
                sb.Append("1 ");
            }
            else{
                sb.Append("0 ");
            }
        }

        // 출력
        Console.WriteLine(sb);
    }
}
*/