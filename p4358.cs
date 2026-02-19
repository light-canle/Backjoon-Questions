// p4358 - 생태학 (S2)
// #맵 #문자열
// 2026.2.19 solved

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
Dictionary<string, int> treeCount = new();
int totalCount = 0;
while (true)
{
    string str = sr.ReadLine();
    if (str == null || str == "")
    {
        break;
    }

    if (!treeCount.ContainsKey(str))
        treeCount[str] = 0;
    treeCount[str]++;
    totalCount++;
}

var orderedName = treeCount.Keys.OrderBy(x => x).ToList();
foreach (string str in orderedName)
{
    sw.WriteLine($"{str} {treeCount[str] / (double)totalCount * 100.0:F4}");
}
sw.Flush();
