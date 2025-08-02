using System;
using System.IO;

// p16567 - 바이너리 왕국 (S3)
// #애드 혹 #시뮬레이션
// 2025.8.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];
        int[] road = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        // 연속으로 연결된 1로 이루어진 부분의 개수를 센다.
        // ex) 0110111010 -> flipCount = 3
        int flipCount = 0;
        int prev = -1;
        for (int i = 0; i < n; i++)
        {
            int cur = road[i];
            // 이전이 1, 현재 칸이 0이면 하나의 연속된 구간이 끝나는 것을 의미한다.
            if (cur == 0 && prev == 1)
            {
                flipCount++;
            }
            prev = cur;
        }
        // 길이 연속된 1로 끝날 수 있으므로 마지막 칸도 체크
        if (prev == 1) flipCount++;
        // m개의 쿼리 수행
        for (int i = 0; i < m; i++)
        {
            int[] query = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            switch (query[0])
            {
                // 현재 '연속된 1로 연결된 구간'의 개수를 출력
                case 0:
                    sw.WriteLine(flipCount);
                    break;
                // i번째 칸(i-1번 인덱스)을 1로 만들고, 그로 인해 변화하는 구간 개수를 업데이트
                case 1:
                    // 이미 1인 경우 변화 없음
                    if (road[query[1] - 1] == 1) break;
                    // 현재 칸을 1로 바꿈
                    road[query[1] - 1] = 1;
                    // 맨 첫 칸을 1로 바꾼 경우
                    if (query[1] == 1)
                    {  
                        // 두 번째 칸이 0인 경우에만 구간의 수를 증가시킴
                        /*
                        00... -> 10... => 길이가 1인 1로 이루어진 구간이 새로 생김 (flipCount에 1 추가)
                        01... -> 11... => 기존에 있던 구간의 길이가 1 길어짐 (flipCount 변화 없음)
                        */
                        if (road[1] == 0) flipCount++;
                    }
                    else if (query[1] == n)
                    {
                        // n-1 번째 칸이 0인 경우에만 구간의 수를 증가시킴
                        /*
                        ...00 -> ...01 => 길이가 1인 1로 이루어진 구간이 새로 생김 (flipCount에 1 추가)
                        ...10 -> ...11 => 기존에 있던 구간의 길이가 1 길어짐 (flipCount 변화 없음)
                        */
                        if (road[n - 2] == 0) flipCount++;
                    }
                    else
                    {
                        int pos = query[1] - 1;
                        // 넣을 칸 왼쪽과 오른쪽이 모두 0인 경우
                        // ...000... -> ...010... => 가운데에 길이가 1인 새로운 1이 생겨나는 것을 의미하므로, flipCount 1 증가
                        if (road[pos - 1] == 0 && road[pos + 1] == 0) flipCount++;
                        // 넣을 칸 왼쪽과 오른쪽이 모두 1인 경우
                        // ...101... -> ...111... => 기존에 있던 두 구간이 새로운 1로 인해 하나로 통합되는 것을 의미하므로, flipCount 1 감소
                        else if (road[pos - 1] == 1 && road[pos + 1] == 1) flipCount--;
                    }
                    break;
            }
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
