using System;

// p1813 - 논리학 교수 (S5)
// #애드 혹
// 2025.6.7 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        // 각각의 명제는 참인 명제가 n개 중에 몇 개 있는지를 담고 있다.
        int[] propositions = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 가정 - 명제 n개중 참인 것의 개수
        int assume = n;
        while (assume >= 0)
        {
            int truePropos = 0;
            for (int i = 0; i < n; i++)
            {
                // 가정한 것과 개수가 같으면 참이다.
                if (assume == propositions[i])
                {
                    truePropos++;
                }
            }
            // 가정과 실제 참인 명제 개수가 같으면 가정은 참인.것이다.
            if (truePropos == assume)
            {
                break;
            }
            assume--;
        }
        // 만약 어떤 가정도 참이 아니면 -1이 출력됨
        Console.WriteLine(assume);
    }
}
