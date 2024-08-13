using System;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine());

        int[] nums = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[] LIS = new int[N];
        LIS[0] = nums[0];
        int i = 1;
        int lisLast = 0;

        while (i < N)
        {
            if (LIS[lisLast] < nums[i])
            {
                LIS[lisLast + 1] = nums[i];
                lisLast++;
            }
            else
            {
                int pos = SelectPos(LIS, 0, lisLast, nums[i]);
                LIS[pos] = nums[i];
            }
            i++;
        }
        Console.WriteLine(lisLast + 1);
        sr.Close();
    }

    public static int SelectPos(int[] arr, int left, int right, int target)
    {
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        return right;
    }
}

// 참고 : https://chanhuiseok.github.io/posts/algo-49/
