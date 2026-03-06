// p11949 - 번호표 교환 (B2)
// #시뮬레이션
// 2026.3.7 solved (3.6)

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0], m = input[1];
List<int> studentNumber = new();
for (int i = 0; i < n; i++)
{
    studentNumber.Add(int.Parse(sr.ReadLine()));
}
for (int i = 1; i <= m; i++) 
{
    for (int j = 0; j < n - 1; j++) 
    {
        if (studentNumber[j] % i > studentNumber[j + 1] % i)
        {
            int temp = studentNumber[j];
            studentNumber[j] = studentNumber[j + 1];
            studentNumber[j + 1] = temp;
        }
    }
}

foreach (int num in studentNumber)
{
    Console.WriteLine(num);
}
