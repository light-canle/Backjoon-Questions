using System;
using System.IO;

// p21967 - 세워라 반석 위에 (S3)
// #완전 탐색 #두 포인터
// 2025.5.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        // 두 포인터의 범위에 속한 요소들의 개수 - count[k]는 범위 내 k의 수이다.
        int[] count = new int[11];
        // 1번째 요소를 추가
        count[arr[0]]++;
        // 두 포인터
        int left = 0, right = 0;
        // 반석의 최대 길이
        int maxBan = 1;
        // 끝쪽에서 최대 길이 반석이 나올 수 있으므로 왼쪽, 오른쪽 모두 끝에 도달하면 종료
        while (left != n - 1 || right != n - 1)
        {
            // 두 포인터가 겹침 - 오른쪽 것을 옮긴다.
            if (left == right)
            {
                right++;
                count[arr[right]]++; // 오른쪽 포인터는 옮길 때마다 새로운 요소를 추가
            }
            // 현재 영역이 반석인지 체크
            bool isBan = Banseog(count);
            // 반석인 경우 오른쪽 포인터 이동 (단, 오른쪽 포인터가 끝에 도달하면 왼쪽을 이동)
            if (isBan)
            {
                maxBan = Math.Max(right - left + 1, maxBan);
                if (right < n - 1)
                {
                    right++;
                    count[arr[right]]++;
                }
                else
                {
                    count[arr[left]]--;
                    left++; // 왼쪽 포인터는 지워질 요소를 먼저 빼고 이동한다.
                }
            }
            // 반석이 아니면 왼쪽 포인터를 이동한다.
            else
            {
                if (left < n - 1)
                {
                    count[arr[left]]--;
                    left++;
                }
            }
        }

        Console.WriteLine(maxBan);
        sr.Close();
    }

    // 현재 영역에 있는 최대값, 최솟값의 차이가 2 이하인지 판별, arr에는 count를 넣음
    // arr에서 값이 0보다 큰 인덱스의 최소, 최대 차이가 2 이하인지 판별
    public static bool Banseog(int[] arr)
    {
        int len = arr.Length;
        int min = 0, max = len - 1;
        for (int i = 0; i < len; i++)
        {
            if (arr[i] > 0)
            {
                min = i;
                break;
            }
        }
        for (int i = len - 1; i >= 0; i--)
        {
            if (arr[i] > 0)
            {
                max = i;
                break;
            }
        }
        return max - min <= 2;
    }
}
