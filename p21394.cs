using System;
using System.IO;

// p21394 - 숫자 카드 (B1)
// #그리디
// 2025.4.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int[] c = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            // 1~9가 쓰인 카드의 각 개수와 총 개수
            int totalCount = 0;
            for (int j = 0; j < 9; j++)
            {
                totalCount += c[j];
            }
            // 6을 9로 교체
            c[8] += c[5];
            c[5] = 0;
            int[] result = new int[totalCount];

            int curNum = 9;
            int left = 0, right = totalCount - 1;
            int addTime = 0;
            
            while (curNum > 0)
            {
                // 현재 수를 다 씀
                if (c[curNum - 1] == 0)
                {
                    curNum--;
                    continue;
                }
                c[curNum - 1]--;
                addTime++;
                // 홀수 번째는 왼쪽부터, 짝수 번째는 오른쪽부터 채워 넣음
                if (addTime % 2 == 1)
                {
                    result[left] = curNum;
                    left++;
                }
                else
                {
                    result[right] = curNum;
                    right--;
                }
            }
            sw.WriteLine(string.Join(" ", result));
        }
        sw.Flush();
        sw.Close();
    }
}
