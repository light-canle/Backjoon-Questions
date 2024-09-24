using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p11866 - 요세푸스 문제 0, S5
/// 해결 날짜 : 2023/8/21
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
        StringBuilder output = new StringBuilder();

        List<int> list = Enumerable.Range(1, input[0]).ToList(); // 1 ~ N까지 있는 리스트
        List<int> Josephus = new List<int>(); // 구할 순열을 담는 리스트
        
        int K = input[1];
        int removePosition = K - 1;

        while (list.Count > 0)
        {
            Josephus.Add(list[removePosition]);
            list.RemoveAt(removePosition);
            if (list.Count != 0) removePosition = (removePosition + K - 1) % list.Count;
        }
        // 출력 형식에 맞게 output 생성
        output.Append('<');
        foreach(int num in Josephus) 
        { 
            output.Append(num.ToString() + ", ");
        }
        output.Remove(output.Length - 2, 2);
        output.Append('>');

        Console.WriteLine(output);
    }
}