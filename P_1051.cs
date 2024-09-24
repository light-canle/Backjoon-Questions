using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class P1051{
    public static int min(int a, int b) => a < b ? a : b;
    public static void Main(string[] args){
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = sr.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int[,] nums = new int[size[0], size[1]];
        for (int i = 0; i < size[0]; i++){
            for (int j = 0; j < size[1]; j++){
                // 숫자 하나씩 입력 받기(공백 구분 없이 한 자리 수를 입력)
                nums[i, j] = sr.Read() - 48;
            }
            sr.Read(); // 공백 무시
        }

        int max_size = 1;
        // 2차원 배열 순회
        for (int i = 0; i < size[0]; i++){
            for (int j = 0; j < size[1]; j++){
                for(int curr_size = 2; curr_size <= min(size[0] - i, size[1] - j); curr_size++){
                    if (nums[i, j] == nums[i + curr_size - 1, j] && nums[i + curr_size - 1, j] == nums[i, j + curr_size - 1] &&
                    nums[i + curr_size - 1, j] == nums[i + curr_size - 1, j + curr_size - 1]){
                        if (max_size < curr_size){
                            max_size = curr_size;
                        }
                    }
                }
            }
        }

        Console.WriteLine(max_size * max_size);
        sr.Close();
    }
}