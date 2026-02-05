// p27467 - 수학 퀴즈 (S1)
// #수학
// 2026.2.5 solved

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int n = int.Parse(sr.ReadLine());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

int[] remain = new int[3];
foreach (int i in input)
{
    remain[i % 3]++;
}
double p = remain[1] - remain[2], q = remain[0] - remain[2];
Console.WriteLine($"{p} {q}");
