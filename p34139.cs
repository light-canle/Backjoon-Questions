#pragma warning disable CS8604, CS8602, CS8600

// p34139 - 의식의 광장 (S2)
// #그리디 #애드 혹 #정렬
// 2026.1.2 solved

/*
h행의 좌우로는 무한한 격자에 빛 n개의 시작 위치가 주어진다.
n개의 빛은 1 ~ n까지 서로 다른 이동 거리를 가지고 있고, 오른쪽으로 자신의 이동거리만큼을 이동한다.
n개의 빛이 동시에 움직여서 동시에 도착할 때, 이동 도중 빛들은 겹치지 않아야 하고,
도착했을 시 n개의 빛은 모두 다른 열에 위치해야 한다. 
위 조건을 만족하도록 n개의 빛에 이동 거리를 부여하는 것이 이 문제의 목표이다.

이 문제를 풀기 위해서 우선 이동 도중 빛들이 겹치지 않게 이동 거리를 부여해보자.
빛들의 시작 위치는 주어지므로, 더 오른쪽에 있는 빛에 더 큰 이동거리를 부여하게 되면
같은 행에 있는 빛들은 겹치지 않게 된다.
시작 위치의 열이 1밖에 차이나지 않는 경우에도 오른쪽 빛의 이동거리를 크게 주면, 이동 거리가 큰 빛의 속도가 더 빠르기에
겹치는 일은 일어나지 않는다.
열이 같은 두 빛의 경우에는 행 좌표가 더 큰 쪽 (더 아래 칸)에 더 큰 이동거리를 부여한다.
이제 이렇게 지정한 경우 이동 완료시 열도 서로 다름을 증명해 보이겠다.
행이 서로 다른 두 빛의 좌표가 (r1, c1), (r2, c2)이고, r1 < r2라고 하자.
두 빛의 이동 거리를 d1, d2라고 하자.
(1) c1 = c2인 경우
위의 조건에 따라 행 좌표가 더 큰 두번째 빛이 더 큰 이동거리를 부여받으므로 d1 < d2
이동 후 열 좌표는 c1 + d1, c2 + d2가 되는데, d1 < d2이므로,
c1 + d1 < c2 + d2로 둘의 열 좌표는 다르게 된다.
(2) c1 < c2인 경우
위의 조건에 따라 d1 < d2이고,
c1 + d1 < c2 + d2가 항상 성립하므로 둘의 열 좌표는 다르다.
(3) c1 > c2인 경우
위의 조건에 따라 d1 > d2이고,
c1 > c2, d1 > d2에 의해 c1 + d1 > c2 + d2가 항상 성립하므로 둘의 열 좌표가 다르다.
즉, 어떠한 경우에도 서로 다른 두 빛의 열 좌표는 이동 후 다르게 된다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int h = input[0], n = input[1];

        List<(int, int, int)> positions = new(); // 번호, r, c
        for (int i = 0; i < n; i++)
        {
            int[] pos = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            positions.Add((i, pos[0], pos[1]));
        }
        // 열의 내림차순으로 정렬 후 행의 내림차순으로 정렬
        positions = positions.OrderBy(x => -x.Item3).ThenBy(x => -x.Item2).ToList();

        List<int> result = Enumerable.Repeat(0, n).ToList();

        // 시작 위치가 더 오른쪽에 있는 빛에 더 큰 이동거리를 우선 부여한다.
        // 열이 같으면 행이 더 아래인 쪽에 큰 이동거리를 부여한다.
        int distance = n;
        foreach (var light in positions)
        {
            result[light.Item1] = distance;
            distance--;
        }

        sw.WriteLine("YES");
        sw.WriteLine($"{string.Join(" ", result)}");
        sw.Flush();
    }
}
