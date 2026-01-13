#pragma warning disable CS8604, CS8602, CS8600

// p27527 - 배너 걸기 (S1)
// #집합과 맵 #슬라이딩 윈도우
// 2026.1.14 solved (1.13)

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];

        int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        // m개 길이 구간에 있어야 할 같은 값의 개수
        int desireCount = (int)Math.Ceiling(m * 0.9);
        // 길이 m인 구간에 들어있는 각 숫자의 개수
        Dictionary<int, int> counts = new();

        // 처음 m개 구간에 있는 수의 개수를 센다.
        for (int i = 0; i < m; i++)
        {
            if (!counts.ContainsKey(nums[i])) counts[nums[i]] = 1;
            else counts[nums[i]] += 1;
        }

        // 현재 길이 m의 구간 안에 있는 수 중 최빈값의 개수
        int maxCountInBundle = counts.Values.Max();
        // (최적화용 변수) - 구간에 desireCount만큼 최빈값이 있어야 하는데, 현재 최빈값이 maxCountInBundle라면
        // 그것의 차이만큼은 최댓값을 비교할 이유가 없다.
        int noAnsCount = desireCount - maxCountInBundle;
        // 최빈값이 ceil(0.9m) 이상인 구간을 하나라도 발견했는가? - 조기 종료를 위한 변수
        bool done = maxCountInBundle >= desireCount;
        // 최빈값이 ceil(0.9m) 이상이기 위한 서로 다른 종류의 수의 최대 가능한 개수
        int maxKind = m - desireCount + 1;
        for (int i = m; i < n; i++)
        {
            // 이미 완료 했으면 끝
            if (done) break;
            // 구간에 i번쨰 값을 넣고, 길이를 m으로 유지하기 위해 맨 뒤의 값은 뺸다.
            noAnsCount--;
            if (!counts.ContainsKey(nums[i])) counts[nums[i]] = 1;
            else counts[nums[i]] += 1;
            counts[nums[i - m]] -= 1;
            if (counts[nums[i - m]] == 0) counts.Remove(nums[i - m]);
            // 새 값을 넣은 후 현재 m개 구간에 들어 있는 수의 종류의 수를 센다.
            if (counts.Count <= maxKind && noAnsCount <= 0)
            {
                // 현재 최빈값을 구하고 갱신한다.
                int cur = counts.Values.Max();
                maxCountInBundle = Math.Max(cur, maxCountInBundle);
                noAnsCount = desireCount - maxCountInBundle;
                done = maxCountInBundle >= desireCount;
            }
        }
        Console.WriteLine(maxCountInBundle >= desireCount ? "YES" : "NO");
    }
}
