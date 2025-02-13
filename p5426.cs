using System;
using System.IO;
using System.Text;

// p5426 - 비밀 편지 (S5)
// #문자열
// 2025.2.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine().Trim();
            int len = line.Length;
            int sqrt = (int)Math.Sqrt(len);
            char[,] matrix = new char[sqrt, sqrt];

            StringBuilder output = new();
            // 정사각형 배열에 문자를 순서대로 읽음
            // 한 가로줄을 왼쪽에서 오른쪽으로 읽고
            // 한 줄을 내려가며 저장
            for (int j = 0; j < len; j++)
            {
                matrix[j / sqrt, j % sqrt] = line[j];
            }

            // 복호화를 할 때는 오른쪽에서 왼쪽으로 세로줄을
            // 위에서 아래로 내려가면서 한 글자씩 읽어나간다.
            for (int j = sqrt - 1; j >= 0; j--)
            {
                for (int k = 0; k < sqrt; k++)
                {
                    output.Append(matrix[k, j]);
                }             
            }

            Console.WriteLine(output);
        }
        sr.Close();
    }
}
