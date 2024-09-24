using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p24511 - queuestack, S3
/// 해결 날짜 : 2024/3/30
/// </summary>

/*
주어진 queuestack에 원소를 넣게 되면 스택 부분의 원소는 몇 개를 넣든지 간에
처음에 넣은 원소가 그대로 보존되고, 큐 부분의 원소만 바뀌게 된다.
그래서 큐 부분만 따로 모아 새로운 큐를 만든 뒤, 그 큐에 원소를 넣고 빼는 방식을 사용했다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int count = int.Parse(sr.ReadLine()!);
        int[] type = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        int[] list = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        int sequenceLen = int.Parse(sr.ReadLine()!);
        int[] sequence = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        
        Queue<int> queue = new Queue<int>();
        List<int> output = new List<int>();

        // 큐 부분만 모음
        for (int j = count - 1; j >= 0; j--)
        {
            if (type[j] == 0)
            {
                queue.Enqueue(list[j]);
            }
        }
        
        // 새로 만든 큐에 시퀸스를 집어 넣음
        for (int i = 0; i < sequenceLen; i++)
        {
            queue.Enqueue(sequence[i]);
            output.Add(queue.Dequeue());
        }

        Console.WriteLine(string.Join(" ", output));
        sr.Close();
    }
}