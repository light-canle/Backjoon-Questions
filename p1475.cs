using System;
using System.Linq;

/// <summary>
/// p1475 - 방 번호, S5
/// 해결 날짜 : 2023/9/1
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string roomNumber = Console.ReadLine();

        // 9는 6을 뒤집어서 쓸 수 있으므로, 9는 6의 개수에 포함한다.
        int[] count = new int[9];

        for (int i = 0; i < roomNumber.Length; i++)
        {
            if (roomNumber[i] == '9') count[6]++;
            else count[int.Parse(roomNumber[i].ToString())]++;
        }
        // 6, 9가 5개 -> 3세트
        // 6, 9가 4개 -> 2세트
        // 즉, 6의 개수의 반을 반올림하면, 필요한 세트의 수가 나온다.
        count[6] = (int)Math.Round(count[6] / 2.0, MidpointRounding.AwayFromZero);
        Console.WriteLine(count.Max());
    }
}
