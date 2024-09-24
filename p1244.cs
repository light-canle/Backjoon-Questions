using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1244 - 스위치 켜고 끄기, S4
/// 해결 날짜 : 2023/11/14
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int numSwitch = int.Parse(Console.ReadLine()!);
        List<int> list = Console.ReadLine()!
            .Split()
            .Select(int.Parse)
            .ToList();
        int numStudent = int.Parse(Console.ReadLine()!);

        // 학생들에 따라 스위치 제어를 달리함
        for (int i = 0; i < numStudent; i++)
        {
            int[] info = Console.ReadLine()!.Split()
                        .Select(int.Parse).ToArray();

            // 남자 : 받은 수의 배수 번호의 스위치 변경
            if (info[0] == 1)
            {
                int target = info[1];
                int cur = target;
                // 범위를 벗어나기 전까지 반복
                while (cur <= numSwitch)
                {
                    list[cur - 1] = change(list[cur - 1]);
                    cur += target;
                }
            }
            // 여자 : 받은 수 번호의 스위치는 상태를 바꾼 뒤, 그것을 기준으로 양 옆으로 한 칸씩 이동하며
            // 기준 스위치로 부터 n칸씩 떨어진 스위치 상태가 같은 동안 그 스위치들의 상태를 바꾼다.
            else
            {
                int target = info[1];
                list[target - 1] = change(list[target - 1]); // 기준점 스위치 상태 바꿈
                int diff = 1;
                while (true)
                {
                    // 영역을 벗어남
                    if (target - diff <= 0 || target + diff > numSwitch) break;
                    // 같은 칸만큼 떨어진 두 스위치의 상태가 다름
                    else if (list[target - 1 - diff] != list[target - 1 + diff]) break;
                    // 같은 경우에는 상태를 바꿈
                    else
                    {
                        list[target - 1 - diff] = change(list[target - 1 - diff]);
                        list[target - 1 + diff] = change(list[target - 1 + diff]);
                        diff++;
                    }
                }
            }
        }
        // 한 줄에 20개씩 상태 출력
        for (int i = 0; i < numSwitch; i++) 
        {
            Console.Write(list[i] + " ");
            if (i % 20 == 19) Console.WriteLine();
        }
    }

    public static int change(int i)
    {
        return (i == 0) ? 1 : 0;
    }
}