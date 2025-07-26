using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p28245 - 배고파(Hard) (S3)
// #완전 탐색
// 2025.7.26 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

        // 2^0+2^0 부터 2^59+2^59까지의 결과를 미리 저장해 둔다.
        // Note : 59 < log2(10^18) < 60
        List<(int, int, long)> nums = new(); // x, y, 2^x+2^y 순서로 저장
        for (int y = 0; y <= 59; y++)
        {
            for (int x = 0; x <= y; x++)
            {
                nums.Add( (x, y, Pow2(x) + Pow2(y)) );
            }
        }
        nums = nums.OrderBy(x => x.Item3).ToList(); // 2^x + 2^y의 크기 순으로 오름차순 정렬
        
        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            long k = long.Parse(sr.ReadLine());

            int idx = 0;
            while (idx < nums.Count && nums[idx].Item3 < k)
            {
                idx++;
            }
            // 동일한 값을 찾았거나 idx가 0 (k = 1, 2인 경우)
            if (nums[idx].Item3 == k || idx == 0)
            {
                sw.WriteLine($"{nums[idx].Item1} {nums[idx].Item2}");
            }
            // 동일한 값이 없음.
            // high = nums[idx].Item3는 k보다 큰 값 중 가장 작은 값, 
            // low = nums[idx - 1].Item3는 k보다 작은 값 중 가장 큰 값이다.
            // 이 둘중 k와 차이가 적은 쪽이 정답이다. 차이가 같으면 low가 정답이다.
            else
            {
                long low = nums[idx - 1].Item3;
                long high = nums[idx].Item3;
                sw.WriteLine(high - k < k - low ? 
                    $"{nums[idx].Item1} {nums[idx].Item2}" : 
                    $"{nums[idx - 1].Item1} {nums[idx - 1].Item2}");
            }
            
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    // 0 ~ 59 사이의 x에 대해 2^x를 반환
    public static long Pow2(int x)
    {
        if (x < 0 || x >= 60) return -1;
        long ret = 1L;
        for (int i = 1; i <= x; i++)
        {
            ret *= 2L;
        }
        return ret;
    }
}
