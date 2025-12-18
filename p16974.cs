#pragma warning disable CS8604, CS8602, CS8600

using System;

// p16974 - 레벨 햄버거 (G5)
// #재귀 #DP
// 2025.12.18 solved

public class Program
{
    public static long[] sizeOfBurger;      // N단계 버거의 크기
    public static long[] numberOfPatty;     // N단계 버거에 들어있는 패티의 수
    public static void Main(string[] args)
    {
        long[] info = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        int level = (int)info[0];
        long count = info[1];

        // 함수 실행 전 미리 버거 크기와, 패티 개수를 저장한다.
        sizeOfBurger = new long[51];
        numberOfPatty = new long[51];
        sizeOfBurger[0] = 1;
        numberOfPatty[0] = 1;
        for (int i = 1; i <= 50; i++)
        {
            sizeOfBurger[i] = 3 + 2 * sizeOfBurger[i - 1];
            numberOfPatty[i] = 1 + 2 * numberOfPatty[i - 1];
        }

        Console.WriteLine(PattyCount(level, count));
    }

    public static long PattyCount(int level, long count)
    {
        // 완전한 햄버거
        if (count == sizeOfBurger[level])
        {
            return numberOfPatty[level];
        }
        // 아무 것도 없음
        else if (count == 0)
        {
            return 0;
        }
        long patty = 0;
        long prevLevel = sizeOfBurger[level - 1];

        // 맨 앞의 빵 제외
        count -= 1;
        // 1번째 N-1단계 햄버거의 전부 또는 일부에 포함된 패티 수를 센다.
        patty += PattyCount(level - 1, count > prevLevel ? prevLevel : count);
        count -= prevLevel;
        if (count <= 0) return patty;
        // 가운데 있는 패티 반영
        count -= 1; patty += 1;
        // 2번째 N-1단계 햄버거의 전부 또는 일부에 포함된 패티 수를 센다.
        patty += PattyCount(level - 1, count > prevLevel ? prevLevel : count);
        // 뒤에는 빵 1개만 남으므로 패티가 더 이상 없음 - 그대로 반환
        return patty;
    }
}
