using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1966 - 프린터 큐, S3
/// 해결 날짜 : 2023/8/24
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int caseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < caseCount; i++)
        {
            string[] info = Console.ReadLine().Split();

            int docsCount = int.Parse(info[0]);
            int docsToConsider = int.Parse(info[1]);

            List<int> priority = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            Queue<int> queue = new Queue<int>();

            for (int j = 0; j < docsCount; j++)
            {
                queue.Enqueue(priority[j]);
            }

            int count = 0; // 찾고자 하는 파일이 몇 번째에 빠지는 지를 저장하는 수
            while (true)
            {
                count++;
                // 찾고자 하는 파일이 큐의 처음으로 왔다
                if (docsToConsider == 0)
                {
                    // 우선도가 더 큰 파일이 있는 경우 이 파일은 맨 뒤로 빠진다.
                    if (queue.Max() != queue.First())
                    {
                        int p = queue.Dequeue();
                        queue.Enqueue(p);
                        docsToConsider = queue.Count() - 1;
                        count--; // 아무 파일도 인쇄되지 않았으므로 수를 감소시킨다.
                    }
                    // 이 파일의 우선도가 제일 큰 경우 반복은 끝이 난다.
                    else
                    {
                        break;
                    }
                }
                // 찾고자 하는 파일이 처음이 아닌 경우
                else
                {
                    // 맨 앞 파일을 제거할 지 아닐 지 결정
                    if (queue.Max() != queue.First())
                    {
                        int p = queue.Dequeue();
                        queue.Enqueue(p);
                        count--; // 아무 파일도 인쇄되지 않았으므로 수를 감소시킨다.
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                    docsToConsider--;
                }
            }
            Console.WriteLine(count);
        }
    }
}
