#pragma warning disable CS8604, CS8602, CS8600

// p31713 - 행운을 빌어요 (S4)
// #완전 탐색
// 2025.1.16 solved

// 잎 3개 또는 4개에 줄기 1개로 클로버를 만들 수 있으므로,
// 잎의 개수를 줄기의 개수로 나눈 값이 3 이상 4 이하가 되도록 해야 한다.

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int stem = input[0], leaves = input[1];
            int need = 0;
            // 줄기가 0인 경우
            if (stem == 0)
            {
                // 잎도 0개이면 만들 필요가 없다.
                if (leaves == 0)
                {
                    Console.WriteLine(0);
                    continue;
                }
                // 줄기 1개 추가
                stem++; need++;
            }
            double div = leaves / (double)stem;
            // 줄기에 비해 잎이 많음
            if (div > 4)
            {
                // 잎의 개수가 줄기의 4배 이하가 될 때 까지 줄기 추가
                while (div > 4)
                {
                    stem++; need++;
                    div = leaves / (double)stem;
                }
                // 추가한 후 잎이 줄기 개수의 3배 미만이면 줄기 개수의 3배가 되도록 잎 추가
                if (div < 3)
                {
                    need += stem * 3 - leaves;
                }
                Console.WriteLine(need);
            }
            // 잎이 줄기 개수의 3배 미만이면 줄기 개수의 3배가 되도록 잎 추가
            else if (div < 3)
            {
                Console.WriteLine(need + (stem * 3 - leaves));
            }
            // 3배 이상 4배 이하이면 더 추가할 필요 없음
            else
            {
                Console.WriteLine(need);
            }
        }
    }
}
