using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1927 - 최소 힙, S2
/// 해결 날짜 : 2023/9/11
/// 200번째 문제
/// </summary>

/*
부모 노드가 자식 노드 이하인 최소 이진 힙을 구현하는 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();
        int N = int.Parse(sr.ReadLine());

        List<int> min_heap = new List<int>();
        // 힙의 인덱스는 1부터 시작해야 하므로 쓰이지 않는 값인 -1을 넣음
        min_heap.Add(-1);
        // N번의 숫자 입력
        for (int i = 0; i < N; i++)
        {
            int num = int.Parse(sr.ReadLine());
            // 0인 경우 루트 노트의 값을 반환한 뒤, 힙에서 제거하라는 뜻이다.
            if (num == 0)
            {
                // 힙에 원소가 없음(즉, -1만 있다.)
                if (min_heap.Count == 1)
                {
                    output.AppendLine("0");
                    continue;
                }
                // 아닌 경우 루트 노드의 값을 출력하고 제거
                output.AppendLine(Pop(min_heap).ToString());
                //Console.WriteLine(string.Join(" ", min_heap.GetRange(1, min_heap.Count - 1)));
            }
            else
            {
                // 힙에 값을 추가
                Push(min_heap, num);
                //Console.WriteLine(string.Join(" ", min_heap.GetRange(1, min_heap.Count - 1)));
            }
        }

        Console.WriteLine(output.ToString());
        sr.Close();
    }

    // heap에 value를 추가하는 함수
    public static void Push(List<int> heap, int value)
    {
        // 우선 맨 뒤에 원소를 추가함
        heap.Add(value);

        // 해당 원소의 현재 인덱스
        int index = heap.Count - 1;
        // 최소 힙의 규칙을 지키기 위해 해당 원소가 부모 노드보다 작은 경우
        // 부모 노드와 위치를 바꾼다.(힙에서 부모 노드는 자신의 인덱스를 2로 나눈 몫이다.)
        while (index > 1 && heap[index / 2] > value)
        {
            int temp = heap[index / 2];
            heap[index / 2] = value;
            heap[index] = temp;
            index = index / 2;
        }
    }
    public static int Pop(List<int> heap)
    {
        // 기저 사례 : 힙이 비어있음(-1 밖에 없다.)
        if (heap.Count <= 1) return -1;
        // 루트 노드의 값 저장
        int top = heap[1];
        // 맨 마지막 노드(리프 노드 중 하나)의 값을 루트 노드에 덮어씌우고 맨 뒷 노드는 지운다.
        heap[1] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        // 기저 사례 : 힙에 루트 노드밖에 없었던 경우 heap[1]에 접근하면 인덱스 범위를 벗어나므로
        // 바로 top 값을 반환해야 한다.
        if (heap.Count == 1) return top;
        int value = heap[1];
        // 현재 인덱스
        int index = 1;
        // 리프 노드가 되거나 현재 위치에서의 자식 노드가 자신 이상이어서 더 이상
        // 내려갈 필요가 없을 때까지 반복
        while (index * 2 <= heap.Count - 1)
        {
            int minPos = 1;
            // 만약 자식 노드가 2개인 경우 둘 중 더 작은 값을 비교할 것이다.
            if (index * 2 + 1 <= heap.Count - 1)
                minPos = (heap[index * 2] > heap[index * 2 + 1] ? 2 : 1);
            // minPos가 1 = 왼쪽 자식 노드가 작은 경우
            if (minPos == 1)
            {
                // 자신이 더 작은 경우 더 이상 내려가지 않음
                if (heap[index] < heap[index * 2]) break;
                // 아닌 경우 위치 교환
                int temp = heap[index];
                heap[index] = heap[index * 2];
                heap[index * 2] = temp;
                index *= 2;
            }
            // minPos가 2 = 오른쪽 자식 노드가 작은 경우
            else
            {
                if (heap[index] < heap[index * 2 + 1]) break;
                int temp = heap[index];
                heap[index] = heap[index * 2 + 1];
                heap[index * 2 + 1] = temp;
                index = index * 2 + 1;
            }
        }

        return top;
    }
}