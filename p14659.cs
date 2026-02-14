// p14659 - 한조서열정리하고옴ㅋㅋ (B1)
// #그리디 #완전 탐색
// 2026.2.14 solved

/*
자신의 위치에서 오른쪽에 있는 값 중 자신보다 큰 값이 나올 때까지 이동했을 때 이동한 거리의 최댓값을 구하는 문제이다.
개수가 3만개가 최대여서 완전 탐색으로 해결 가능했다.
*/

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int n = int.Parse(sr.ReadLine());
int[] heights = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

int best = 0;
for (int i = 0; i < n - 1; i++)
{
    int cur = heights[i];
    int score = 0;
    for (int j = i + 1; j < n; j++)
    {
        if (heights[j] > cur)
        {
            break;
        }
        score++;
    }
    best = Math.Max(best, score);
}
Console.WriteLine(best);
