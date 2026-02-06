#pragma warning disable CS8604, CS8602, CS8600

// p5549 - 행성 탐사 (G5)
// #누적 합(2차원)
// 2026.2.6 solved

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int row = input[0], col = input[1];
int areaCount = int.Parse(sr.ReadLine());

List<string> list = new();
for (int i = 0; i < row; i++)
{
    list.Add(sr.ReadLine());
}

// 각각의 지형의 개수를 담은 누적합 배열
// xx[i, j]에는 (1,1)부터 (i,j)까지 해당 지형의 개수가 들어간다. 
int[,] jungle = new int[row + 1, col + 1];
int[,] ocean = new int[row + 1, col + 1];
int[,] ice = new int[row + 1, col + 1];

// 2차원 누적합 배열을 채운다.
for (int i = 1; i <= row; i++)
{
    for (int j = 1; j <= col; j++)
    {
        /*
        각 지형에 대해 현재 리스트 상 위치가 해당 지형인 경우 그 위치 값을 1로 잡는다.
        2차원 누적합을 구할 때는 s[i,j] = list[i-1,j-1] + s[i-1,j] + s[i,j-1] - s[i-1,j-1]로 구할 수 있다.
        */
        jungle[i, j] = (list[i - 1][j - 1] == 'J' ? 1 : 0) +
            jungle[i - 1, j] + jungle[i, j - 1] - jungle[i - 1, j - 1];
        ocean[i, j] = (list[i - 1][j - 1] == 'O' ? 1 : 0) +
            ocean[i - 1, j] + ocean[i, j - 1] - ocean[i - 1, j - 1];
        ice[i, j] = (list[i - 1][j - 1] == 'I' ? 1 : 0) +
            ice[i - 1, j] + ice[i, j - 1] - ice[i - 1, j - 1];
    }
}

for (int i = 0; i < areaCount; i++)
{
    int[] p = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    int y1 = p[0] - 1, x1 = p[1] - 1;
    // 각 지형에 대해 입력받은 영역에 해당 지형이 몇 개 있는지를 누적합 배열을 이용해서 구한다.
    // 영역이 (a,b) ~ (c,d)일 때, count = s[c, d] - s[a - 1, d] - s[c, b - 1] + s[a - 1, b - 1]
    // 좌표는 (1,1)이 시작인 것으로 한다.
    int jungleCount = jungle[p[2], p[3]] - jungle[y1, p[3]]
        - jungle[p[2], x1] + jungle[y1, x1];
    int oceanCount = ocean[p[2], p[3]] - ocean[y1, p[3]]
        - ocean[p[2], x1] + ocean[y1, x1];
    int iceCount = ice[p[2], p[3]] - ice[y1, p[3]]
        - ice[p[2], x1] + ice[y1, x1];
    sw.WriteLine($"{jungleCount} {oceanCount} {iceCount}");
}
sw.Flush();
