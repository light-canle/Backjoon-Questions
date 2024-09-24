using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1931 - 회의실 배정, S1
/// 해결 날짜 : 2023/9/3
/// </summary>

/*
그리디 알고리즘을 이용해서 현재 시점에서 가장 빨리 끝나는 회의를 선택하면
최적해가 나오는 문제이다.

그런데 입력의 크기가 커서 메모리 초과나 시간 초과를 많이 일으켰다.
다양한 방법을 시도하다가 도서를 참고했는데, for문을 사용하는 방식으로 해결했다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int num = int.Parse(sr.ReadLine());
        
        List<(int, int)> meetings = new List<(int, int)>();
        

        for (int i = 0; i < num; i++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            // 원래는 시작 시간이 앞, 끝나는 시간이 뒤에 있는데, 
            // List<T>의 Sort()함수로 끝나는 시간을 기준으로 정렬하기 위해
            // 끝나는 시간을 앞에 두었다.
            meetings.Add((input[1], input[0]));
        }

        // 빨리 회의가 끝나는 순으로 정렬
        meetings.Sort();

        int selected = 0;
        int earliest = 0;
        for( int i = 0; i < meetings.Count; i++)
        {
            int start = meetings[i].Item2; // 시작 시간
            int end = meetings[i].Item1; // 끝나는 시간
            // 겹치지 않는 회의를 찾음(즉, 회의가 시작하는 시간이 이전 회의의 끝나는 시간 이후인 것을 찾음)
            if (earliest <= start)
            {
                earliest = end; // 다음 회의가 시작할 수 있는 가장 빠른 시간은 현재 회의가 끝나는 시간이다.
                selected++; // 선택된 회의의 수를 추가
            }
        }
        
        Console.WriteLine(selected);
        sr.Close();
    }
}

/*
만약 선택된 회의들의 시작~끝 시간을 알고 싶다면 아래 코드를 보면 된다.
아래 코드는 이 문제에서는 시간 초과가 났지만, 선택된 회의들의 정보를 selected 리스트에서
확인할 수 있다.

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int num = int.Parse(sr.ReadLine());
        
        List<(int, int)> meetings = new List<(int, int)>();
        List<(int, int)> selected = new List<(int, int)>();
        for (int i = 0; i < num; i++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            meetings.Add((input[0], input[1]));
        }

        // 빨리 회의가 끝나는 순으로 정렬
        meetings = meetings.OrderBy(a => a.Item2).ToList();

        while(meetings.Count > 0)
        {
            (int, int) meet = meetings.First();
            meetings.RemoveAll(x => Overlap(meet, x));
            selected.Add(meet);
        }
        
        Console.WriteLine(selected.Count);
        sr.Close();
    }

    public static bool Overlap((int, int) a, (int, int) b)
    {
        return (a.Item2 > b.Item1) ? true : false;
    }
}

*/