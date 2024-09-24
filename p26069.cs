using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p26069 - 붙임성 좋은 총총이, S4
/// 해결 날짜 : 2024/3/30
/// </summary>

/*
doDance는 그 사람이 무지개 댄스를 추고 있는지 여부를 나타내며 1이면 추고 있는 중, 0이면 아닌 것이다.
ChongChong는 처음부터 이 댄스를 추고 있으므로 1로 두고 시작한다.
이후 반복문에서 두 사람이 만났을 때, 한 사람이라도 무지개 댄스를 추고 있다면 다른 사람도 무지개 댄스를 추도록 설정한다.
두 사람의 doDance 값을 더한 뒤, 그것이 1이상인 경우 1로 조절하는 방식을 이용해서, 한 번 무지개 댄스를 본 사람이
계속 댄스를 추는 상태로 바뀌도록 조정한다.
이후 doDance를 순회해서 값이 0이 아닌 사람의 수를 세면 정답이 된다. 
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int N = int.Parse(sr.ReadLine()!);
        Dictionary<string, int> doDance = new Dictionary<string, int>();
        doDance["ChongChong"] = 1;

        for (int i = 0; i < N; i++)
        {
            string[] name = sr.ReadLine()!.Split();

            if (!doDance.ContainsKey(name[0]))
                doDance[name[0]] = 0;    

            if (!doDance.ContainsKey(name[1]))
                doDance[name[1]] = 0;

            doDance[name[0]] = doDance[name[0]] + doDance[name[1]];
            doDance[name[0]] = (doDance[name[0]] > 0) ? 1 : 0;
            doDance[name[1]] = doDance[name[0]] + doDance[name[1]];
            doDance[name[1]] = (doDance[name[1]] > 0) ? 1 : 0;
        }

        int dancePeople = 0;
        foreach (string n in doDance.Keys)
        {
            if (doDance[n] != 0) { dancePeople++; }

        }
        Console.WriteLine(dancePeople);
        sr.Close();
    }
}
