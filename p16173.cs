// p16173 - 점프왕 쩰리 (Small) (S4)
// #재귀 #완전 탐색
// 2026.2.22 solved (2.21)

int n = int.Parse(Console.ReadLine());
List<List<int>> map = new();
for (int i = 0; i < n; i++)
{
    map.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
}
Console.WriteLine(CanReach(0, 0, n - 1, n - 1, map, n) ? "HaruHaru" : "Hing");

bool CanReach(int curY, int curX, int goalY, int goalX, List<List<int>> map, int size)
{
    if (curY == goalY && curX == goalX)
    {
        return true;
    }
    else if (curY >= size || curX >= size)
    {
        return false;
    }
    int move = map[curY][curX];
    if (move == 0) return false;
    return CanReach(curY + move, curX, goalY, goalX, map, size) || CanReach(curY, curX + move, goalY, goalX, map, size);
}
