using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p1900 - 레슬러 (S1)
// #그리디 #정렬 #완전 탐색
// 2025.7.28 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine().Trim());
        // (선수의 힘, 선수의 마술 링의 힘, 이긴 횟수, 번호)
        List<(int, int, int, int)> power = new();
        for (int i = 0; i < n; i++)
        {
            int[] info = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
            power.Add((info[0], info[1], 0, i + 1));
        }
        // 모든 선수들에 대해 1:1 대결을 해서 누가 이기는 지를 판별하고,
        // 이긴 횟수를 구한다.
        // A가 B를 이기고, B가 C를 이기면, A가 C를 이기게 되므로,
        // 모두가 1:1을 한 뒤 이긴 횟수가 큰 쪽은 이긴 횟수가 작은 쪽을 이기게 된다. - O(N^2)
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
		            // 서로의 힘을 계산
                int p1 = power[i].Item1 + power[i].Item2 * power[j].Item1;
                int p2 = power[j].Item1 + power[j].Item2 * power[i].Item1;
	              // 승자 판별
                if (p1 > p2)
                {
		                // C#에서 튜플은 불변이기 때문에 새롭게 만들어 주어야 한다.
                    power[i] = (power[i].Item1, power[i].Item2, power[i].Item3 + 1, power[i].Item4);
                }
                else
                {
                    power[j] = (power[j].Item1, power[j].Item2, power[j].Item3 + 1, power[j].Item4);
                }
            }
        }
        // 이긴 횟수가 많은 사람이 앞에 오게 함
        power = power.OrderBy(x => x.Item3).ToList();
        power.Reverse();
        // 이긴 횟수가 많은 레슬러부터 번호를 출력
        foreach (var x in power)
        {
            sw.WriteLine(x.Item4);
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
