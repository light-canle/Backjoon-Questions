#pragma warning disable CS8604, CS8602, CS8600

using System.Text;

// p25319 - Twitch Plays VIIIbit Explorer (G5)
// #구현
// 2026.1.15 solved (풀이는 1.14)

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];

        List<string> dungeon = new();
        for (int i = 0; i < n; i++)
        {
            dungeon.Add(Console.ReadLine());
        }
        string id = Console.ReadLine();
        int[] charInDungeon = new int[26];
        int[] charInName = new int[26];
        // 던전 내 각 알파벳의 개수를 구함
        foreach (var str in dungeon)
        {
            foreach (char c in str)
            {
                charInDungeon[c - 'a']++;
            }
        }
        // id 내 각 알파벳의 개수를 구함
        foreach (var c in id)
        {
            charInName[c - 'a']++;
        }
        // 만들 수 있는 ID의 최소 개수를 구함
        int canMake = int.MaxValue;
        for (int i = 0; i < 26; i++)
        {
            if (charInName[i] == 0) continue;
            canMake = Math.Min(canMake, charInDungeon[i] / charInName[i]);
        }

        // id를 canMake만큼 연결 후 문자들을 던전에서 찾음
        string toFind = RepeatString(id, canMake);
        int idx = 0, len = toFind.Length;
        int y = 0, x = 0;
        List<(int, int)> road = new();
        bool[,] found = new bool[n, m];

        // 처음 위치는 (0, 0)
        road.Add((0, 0));
        // 던전을 1칸씩 조사하며 원하는 알파벳이 있는 곳을 추가한다.
        while (idx < len)
        {
            if (dungeon[y][x] == toFind[idx] && !found[y, x])
            {
                road.Add((y, x));
                found[y, x] = true;
                idx++;
            }
            // 배열을 벗어날 시 좌표를 0으로 초기화
            x++;
            if (x == m)
            {
                x = 0; y++;
            }
            if (y == n) y = 0;
        }
        // 마지막 위치는 (n - 1, m - 1)
        road.Add((n - 1, m - 1));

        // 발견한 위치들을 모두 연결
        StringBuilder path = new();
        int roadLen = road.Count;
        for (int i = 1; i < roadLen; i++)
        {
            path.Append(Way(road[i - 1].Item1, road[i - 1].Item2, road[i].Item1, road[i].Item2));
            if (i != roadLen - 1) path.Append('P');
        }

        Console.WriteLine($"{canMake} {path.Length}");
        Console.WriteLine(path);
    }

    public static string RepeatString(string text, int count)
    {
        StringBuilder ret = new();
        for (int i = 0; i < count; i++)
        {
            ret.Append(text);
        }
        return ret.ToString();
    }

    public static string Way(int y1, int x1, int y2, int x2)
    {
        StringBuilder ret = new();
        int xDiff = x2 - x1;
        int yDiff = y2 - y1;
        if (xDiff > 0) 
            ret.Append(new string('R', xDiff));
        else 
            ret.Append(new string('L', -xDiff));
        // y좌표가 높아지는 게 내려가는 것이다.
        if (yDiff > 0)
            ret.Append(new string('D', yDiff));
        else
            ret.Append(new string('U', -yDiff));
        return ret.ToString();
    }
}
