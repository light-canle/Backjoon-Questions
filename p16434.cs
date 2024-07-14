using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int N = input[0];
        long fAtk = input[1];

        List<(int, int, int)> rooms = new();

        for (int i = 0; i < N; i++)
        {
            input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int t = input[0];
            int a = input[1];
            int h = input[2];

            rooms.Add((t, a, h));
        }

        long low = 1;
        long high = long.MaxValue - 1;

        while (high - low > 1)
        {
            long mid = (low + high) / 2;
            if (CanWin(fAtk, mid, rooms))
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        if (CanWin(fAtk, low, rooms))
        {
            Console.WriteLine(low);
        }
        else
        {
            Console.WriteLine(high);
        }
        sr.Close();
    }

    public static bool CanWin(long fAtk, long maxHp, List<(int, int, int)> rooms)
    {
        long hp = maxHp;
        long atk = fAtk;

        int roomCount = rooms.Count;
        for (int i = 0; i < roomCount; i++)
        {
            (int t, int a, int h) = rooms[i];
            if (t == 1)
            {
                long heroTurn = (h % atk == 0 ? h / atk : h / atk + 1);
                long monsterTurn = (hp % a == 0 ? hp / a : hp / a + 1);
                if (heroTurn > monsterTurn)
                {
                    return false;
                }
                else
                {
                    hp -= a * (heroTurn - 1);
                }
            }
            else
            {
                hp = Math.Min(hp + h, maxHp);
                atk += a;
            }
        }
        return true;
    }
}
