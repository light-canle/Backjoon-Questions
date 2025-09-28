#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

// p11571 - 분수를 소수로 (G4)
// #사칙연산 #비둘기 집의 원리
// 2025.9.28 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();

        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0], d = input[1];
            
            // 정수부 구하기
            int intQ = n / d;
            n = (n % d) * 10;
            
            // 계산 결과의 몫, 나머지를 저장하는 리스트
            List<(int q, int r)> divmod = new();
            // 현재 인덱스
            int idx = 0;
            // n / d의 몫과 나머지를 구하면서, 이미 있는 몫과 나머지 조합이 나올 때까지 반복한다. (비둘기집 원리에 의해 나머지의 가능한 경우의 수는 d가지 이므로 d+1번 조사)
            for (int j = 0; j < d + 1; j++)
            {
                int q = n / d;
                int r = n % d;
                divmod.Add((q, r));
                // 나머지에 10을 곱한 것을 n에 넣음
                n = r * 10;
                idx++;
            }

            // 순환 구간의 시작점과 길이를 구한다.
            // 반복이 처음 시작되는 부분의 인덱스
            int repeatStart = -1;
            // 반복되는 구간의 길이
            int repeatLength = 0;
            int other = 0;
            for (int j = 0; j < divmod.Count; j++)
            {
                // 이미 있는 조합이 나오면 그것의 위치를 구하고 끝낸다.
                if ((other = divmod.FindIndex(j + 1, x => x == divmod[j])) != -1)
                {
                    repeatStart = j;
                    repeatLength = other - repeatStart;
                    break;
                }
            }
            
            StringBuilder decimalStr = new();
            // 정수부 (처음 계산 결과의 몫이다.)
            decimalStr.Append(intQ + ".");
            // 반복되지 않는 부분
            for (int j = 0; j < repeatStart; j++)
            {
                decimalStr.Append(divmod[j].q.ToString());
            }
            // 반복되는 부분
            decimalStr.Append("(");
            for (int j = 0; j < repeatLength; j++)
            {
                decimalStr.Append(divmod[repeatStart + j].q.ToString());
            }
            decimalStr.Append(")");
            output.AppendLine(decimalStr.ToString());
        }

        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
