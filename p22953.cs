#pragma warning disable CS8604, CS8602, CS8600

// p22953 - 도도의 음식 준비 (G4)
// #백트래킹 #이분 탐색
// 2026.2.8 solved

public class Program
{
    public static int[] backTrackRet;                    // 백트래킹 결과 - 격려를 받을 셰프의 번호를 저장
    public static int[] time;                            // 각 셰프가 요리하는 데 걸리는 시간
    public static long minTime = long.MaxValue;          // 최소 요리 시간
    public static int chef, food;                        // 셰프와 요리의 수   
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        chef = input[0];
        food = input[1];
        int cheer = input[2]; // 격려할 횟수
        time = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        backTrackRet = new int[cheer];

        BackTracking(cheer, 0);
        Console.WriteLine(minTime);
    }

    // 백트래킹으로 k번 격려할 수 있는 모든 경우를 탐색
    // 같은 셰프한테 여러 번 격려할 수 있음
    public static void BackTracking(int k, int depth)
    {
        if (k == depth)
        {
            CalculateMinTime();
            return;
        }

        for (int i = 0; i < chef; i++)
        {
            backTrackRet[depth] = i;
            BackTracking(k, depth + 1);
        }
    }

    public static void CalculateMinTime()
    {
        // 격려를 적용해서 시간을 감소시킨다.
        int[] temp = new int[chef];
        Array.Copy(time, temp, chef);
        foreach (int idx in backTrackRet)
        {
            temp[idx] -= ((temp[idx] > 1) ? 1 : 0); // 이미 1인 경우에는 감소시키지 않음
        }

        // 주어진 셰프들의 조리 시간 안에서 food개의 요리를 하는데 걸리는 최소 시간을 이분 탐색으로 구한다.
        long low = 1, high = 1_000_000_000_001;    // 최대 요리 시간은 1명의 셰프가 요리하는데 10^6초 걸리고, 요리가 10^6개 있을 때이다.
        while (high - low > 1)
        {
            long mid = (high + low) / 2;
            long canMake = FoodCountDuringTime(mid, temp);
            // 주어진 시간안에 food개의 음식을 만들 수 있다면 상한을 줄이고, 아니면 하한을 늘린다.
            if (canMake >= food)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }
        // 2개 이하 후보군이 남았을 때 더 작은 쪽으로도 주어진 음식 개수를 충족하면 작은 쪽을,
        // 아니면 큰 쪽을 골라서 최소시간을 갱신한다.
        if (FoodCountDuringTime(low, temp) >= food)
        {
            minTime = Math.Min(minTime, low);
        }
        else
        {
            minTime = Math.Min(minTime, high);
        }
    }
    // 주어진 시간 동안 만들 수 있는 요리의 최대 개수를 구함
    public static long FoodCountDuringTime(long time, int[] cookTime)
    {
        long canMake = 0;
        foreach (int t in cookTime)
        {
            canMake += time / t;
        }
        return canMake;
    }
}
