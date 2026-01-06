#pragma warning disable CS8604, CS8602, CS8600

// p11286 - 절댓값 힙 (S1)
// #우선순위 큐
// 2026.1.6 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

        int oper = int.Parse(sr.ReadLine());
        PriorityQueue<int, double> absHeap = new();
        for (int i = 0; i < oper; i++)
        {
            int k = int.Parse(sr.ReadLine());
            if (k == 0)
            {
                if (absHeap.Count > 0)
                {
                    sw.WriteLine(absHeap.Dequeue());
                }
                else
                {
                    sw.WriteLine(0);
                }
            }
            else
            {
                absHeap.Enqueue(k, Math.Abs((double)k) + (k > 0 ? 0.5 : 0.0));
            }
        }
        sw.Flush();
    }
}
