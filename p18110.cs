using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p18110 - solved.ac, S4
/// 해결 날짜 : 2023/8/28
/// </summary>

/*
C#의 Math.Round() 함수는 기본적으로 0.5를 버리는 경향이 있다.
이를 방지하기 위해 여기서는 아주 작은 수를 더해주었는데,
Math.Round(value, MidpointRounding.AwayFromZero)를 사용하는 방법도 있다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int count = int.Parse(sr.ReadLine());

        List<int> list = new List<int>();
        for (int i = 0; i < count; i++)
        {
            list.Add(int.Parse(sr.ReadLine()));
        }

        if (count == 0) {
            Console.WriteLine(0);
            return;
        }

        list.Sort();

        int numToOmit = (int)Math.Round(0.15m * count + 0.000000001m);

        int sum = 0;
        int partialCount = 0;

        for (int i = numToOmit; i < count - numToOmit; i++)
        {
            sum += list[i];
            partialCount++;
        }

        Console.WriteLine((int)Math.Round( (decimal)sum / partialCount + 0.000000001m));
        
        sr.Close();
    }
}
