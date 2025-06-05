using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

// p1655 - 가운데를 말해요 (G2)
// #우선순위 큐
// 2025.6.6 solved

public class Program
{
    public static void Main(string[] args)
    {
        // p1655
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();

        int n = int.Parse(sr.ReadLine());

        List<int> nums = new();
        for (int i = 0; i < n; i++)
        {
            nums.Add(int.Parse(sr.ReadLine()));
        }

        // c#의 우선순위 큐는 우선순위가 낮은 것을 먼저 반환한다.
        // maxHeap에 넣을 때는 우선순위를 부호를 바꿔서 넣고 (큰 수부터 나오게 하기 위해),
        // minHeap에 넣을 때는 우선순위를 넣는 수와 동일하게 넣는다 (작은 수부터 나오게 하기 위해).
        // maxHeap에는 전체 리스트를 정렬했을 때 작은 거 절반이 들어가고,
        // minHeap에는 전체 리스트를 정렬했을 때 큰 거 절반이 들어간다.
        PriorityQueue<int, int> maxHeap = new();
        PriorityQueue<int, int> minHeap = new();

        for (int i = 0; i < n; i++)
        {
            // 1. maxHeap에 원소를 넣는다.
            maxHeap.Enqueue(nums[i], -nums[i]);
            // 2. maxHeap의 원소 수가 minHeap의 원소 수보다 2 크면, dequeue해서 minHeap에 넣는다.
            // 이렇게 하면 두 큐에 원소가 절반씩 나눠지게 되고, 홀수인 경우 maxHeap에 1개 더 원소가 들어간다.
            if (maxHeap.Count - minHeap.Count >= 2)
            {
                int d = maxHeap.Dequeue();
                minHeap.Enqueue(d, d);
            }
            // 3. maxHeap의 최대 원소가, minHeap의 최소 원소보다 크면, 두 큐에서 각각 dequeue 한 뒤 서로 바꿔서 넣는다.
            // 이렇게 하면 maxHeap.Peek()가 항상 중앙값이 된다.
            if (minHeap.Count > 0 && maxHeap.Peek() > minHeap.Peek())
            {
                int maxTop = maxHeap.Dequeue();
                int minTop = minHeap.Dequeue();
                minHeap.Enqueue(maxTop, maxTop);
                maxHeap.Enqueue(minTop, -minTop);
            }
            output.AppendLine(maxHeap.Peek().ToString());
        }
        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
