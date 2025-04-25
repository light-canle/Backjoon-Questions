using System;
using System.Linq;
using System.Collections.Generic;

// p15803 - PLAYERJINAH’S BOTTLEGROUNDS (S5)
// #기하학
// 2025.4.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        List<(int, int)> pos = new();
        for (int i = 0; i < 3; i++)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            pos.Add((line[0], line[1]));
        }
        // x좌표를 오름차순으로, 같으면 y좌표를 오름차순으로 정렬
        pos = pos.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
        
        (int, int)[] diff = new (int, int)[2];
        // 1,2번째 점의 좌표 차이 / 2,3번째 점의 좌표 차이
        for (int i = 0; i < 2; i++)
        {
            diff[i].Item1 = pos[i + 1].Item1 - pos[i].Item1;
            diff[i].Item2 = pos[i + 1].Item2 - pos[i].Item2;
            // 비율을 구하기 위해서 최대공약수로 나눔
            int g = GCD(diff[i].Item1, diff[i].Item2);
            diff[i].Item1 /= g;
            diff[i].Item2 /= g;
        }
        // 기울기가 같거나 세 점이 같은 x좌표나 y좌표 상에 존재하면 한 직선 위에 있는 것이다.
        if ((diff[0].Item1 == diff[1].Item1 && diff[0].Item2 == diff[1].Item2) 
            || (pos[0].Item1 == pos[1].Item1 && pos[1].Item1 == pos[2].Item1) 
            || (pos[0].Item2 == pos[1].Item2 && pos[1].Item2 == pos[2].Item2))
        {
            Console.WriteLine("WHERE IS MY CHICKEN?");
        }
        else
        {
            Console.WriteLine("WINNER WINNER CHICKEN DINNER!");
        }
    }
    public static int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
