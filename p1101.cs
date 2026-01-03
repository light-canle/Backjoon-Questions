#pragma warning disable CS8604, CS8602, CS8600

// p1101 - 카드 정리 1 (G4)
// #그리디 #완전 탐색
// 2026.1.3 solved

/*
1. 우선 완전 탐색으로 N개의 박스 중 하나를 조커 박스로 정한다.
2. 각 박스에 대해 현재 그 박스가 담고 있는 서로 다른 색상의 종류의 수를 센다.
3. 문제에서 조커 박스를 제외한 상자는 하나의 색상 카드만 들고 있어야 한다. 2에서의 정보를 토대로
조커 박스를 제외한 상자들 중에서 색을 2가지 이상 들고 있는 상자는 모든 카드를 꺼내서 조커 박스로 옮긴다.
4. 그 다음으로는 같은 색상 카드는 조커 박스를 제외하고는 하나의 상자에만 들어가야 한다는 조건을 성립시킬 것이다.
3에서의 이동을 마친 후 조커 박스를 제외하고 각 색상을 담고 있는 상자의 수를 센다.
5. 그 후 각각의 색상 중에서 2가지 이상의 박스에 들어간 색의 경우, 박스 하나만 남기고 모두 조커 박스로 이동시킨다.
앞에서 3의 과정을 통해 하나의 상자는 하나의 색만을 담고 있기에 이렇게 해도 다른 색상에는 영향을 주지 않는다.
6. 1 ~ 5 과정을 반복한 뒤 이동 횟수가 최소인 것을 출력한다. 
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int box = input[0], color = input[1];

        List<List<int>> cards = new();
        for (int i = 0; i < box; i++)
        {
            cards.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        int minMovement = int.MaxValue;
        for (int i = 0; i < box; i++)
        {
            minMovement = Math.Min(minMovement, FindMinimumMovement(cards, box, color, i));
        }
        Console.WriteLine(minMovement);
    }

    public static int FindMinimumMovement(List<List<int>> cards, int box, int color, int joker)
    {
        int moveCount = 0;
        // cards 깊은 복사
        var copy = new List<List<int>>();
        for (int i = 0; i < box; i++)
        {
            copy.Add(new(cards[i]));
        }
        List<int> numOfColorInBox = CountColorEachBox(copy, box);

        // joker 박스를 제외한 박스 중 2가지 이상의 색을 가진 카드의 상자를 모두 꺼내 joker로 넣음
        for (int i = 0; i < box; i++)
        {
            if (i == joker || numOfColorInBox[i] < 2) continue;
            moveCount++;
            for (int j = 0; j < color; j++)
            {
                copy[joker][j] += copy[i][j];
                copy[i][j] = 0;
            }
        }
        List<int> numOfBoxOfColor = NumOfBoxesThatContainColor(copy, box, color, joker);
        // joker 박스를 제외한 박스에서 그 색상을 담고 있는 박스의 수가 1보다 크면 박스 하나만 빼고
        // 나머지 상자의 카드는 joker로 넣는다. (코드에서는 넣는 것은 생략하고, 이동 횟수만 센다.)
        for (int i = 0; i < color; i++)
        {
            if (numOfBoxOfColor[i] > 1)
            {
                moveCount += numOfBoxOfColor[i] - 1;
            }
        }
        return moveCount;
    }
    // 각각의 박스가 포함하고 있는 색상의 개수를 세서 리스트 형태로 반환한다.
    public static List<int> CountColorEachBox(List<List<int>> list, int box)
    {
        List<int> ret = new List<int>(box);
        foreach (var item in list)
        {
            ret.Add(item.Count(x => x > 0));
        }
        return ret;
    }

    // 각각의 색상에 대해 joker 박스를 제외하고 그 색상을 담고 있는 상자의 수를 세서 리스트로 반환한다.
    public static List<int> NumOfBoxesThatContainColor(List<List<int>> list, int box, int color, int joker) 
    {
        List<int> ret = new List<int>(color);
        for (int j = 0; j < color; j++)
        {
            int nonZero = 0;
            for (int i = 0; i < box; i++)
            {
                if (i == joker) continue;
                if (list[i][j] != 0) nonZero++;
            }
            ret.Add(nonZero);
        }
        return ret;
    }
}
