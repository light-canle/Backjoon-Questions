// p3123 - 배추 (G2)
// #기하학 #구현 #HashSet
// 2026.2.24

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int x = input[0], y = input[1];

int circleCount = int.Parse(sr.ReadLine());
// 영역을 1x1 크기의 격자로 나누었을 때,
// 해당 격자의 네 꼭짓점 중 원의 중심이 있는 것의 개수 (0~4)
int[,] pointNear = new int[x, y];
// 점들의 위치. 특정 점의 존재를 O(1)에 파악하기 위해 HashSet을 사용
HashSet<(int, int)> centers = new();
for (int i = 0; i < circleCount; i++)
{
    int[] pos = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    int px = pos[0], py = pos[1];
    centers.Add((px, py));
    // 해당 점의 왼쪽 위, 오른쪽 위, 왼쪽 아래, 오른쪽 아래의 사각형에 꼭짓점의 개수를 누적
    if (InBoundary(px - 1, py - 1, x, y)) { pointNear[px - 1, py - 1]++; }
    if (InBoundary(px - 1, py, x, y)) { pointNear[px - 1, py]++; }
    if (InBoundary(px, py - 1, x, y)) { pointNear[px, py - 1]++; }
    if (InBoundary(px, py, x, y)) { pointNear[px, py]++; }
}

double totalArea = 0;
for (int cx = 0; cx < x; cx++)
{
    for (int cy = 0; cy < y; cy++)
    {
        switch (pointNear[cx, cy])
        {
            case 1:
                // 반지름이 1인 사분원의 넓이
                totalArea += Math.PI / 4;
                break;
            case 2:
                // 이 사각형의 꼭짓점 중 2개가 원의 중심이고,
                // 두 중심이 사각형의 대각선이면 사각형을 꽉 채운다.
                if (Diagonal(centers, cx, cy))
                {
                    totalArea += 1;
                }
                // 그 외에는 pi / 6 + sqrt(3) + 4만큼 차지한다.
                // 반지름 1, 30도 짜리 부채꼴 2개 + 한 변 길이가 1인 정삼각형 1개
                else
                {
                    totalArea += Math.PI / 6.0 + Math.Sqrt(3) / 4.0;
                }
                break;
                // 그 외 경우에는 반드시 사각형을 가득 채우므로 1이 된다.
            case 3:
            case 4:
                totalArea += 1;
                break;
        }
    }
}
Console.WriteLine(totalArea);

// 해당 좌표가 영역 안에 있는지 검사
bool InBoundary(int x, int y, int xSize, int ySize)
{
    return (0 <= x && x < xSize) && (0 <= y && y < ySize);
}

// (cx, cy)의 네 꼭짓점 중 원의 중심이면서 두 점이 대각선을 이루는 지를 검사
bool Diagonal(HashSet<(int, int)> dots, int cx, int cy)
{
    bool diagonal = (dots.Contains((cx, cy)) && dots.Contains((cx + 1, cy + 1)));
    diagonal |= (dots.Contains((cx + 1, cy)) && dots.Contains((cx, cy + 1)));
    return diagonal;
}
