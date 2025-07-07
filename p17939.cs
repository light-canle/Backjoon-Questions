using System;
using System.IO;

// p17939 - Gazzzua (S1)
// #그리디
// 2025.7.7 solved

/*
코인을 구입한 시점 이후에 가장 가격이 비싸지는 시점에 팔면 이익이 최대가 된다.
그래서 afterMax라는 구입 시점과 그 이후에 등장하는 가격 중 최대 가격을 저장하는 리스트를 만든다.
그래서 현재 가격이 afterMax보다 작으면 이후 시점에 이득을 볼 수 있으므로 코인을 사고,
afterMax와 같으면 현재가 이득이 최대가 되는 시점이므로 코인을 모두 팔아버린다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        int[] price = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        // 해당 시간에 대하여 자신의 뒷 시간 중 가장 큰 시간의 값을 저장
        int[] afterMax = new int[n];
        int curMax = price[n - 1];
        for (int i = n - 1; i >= 0; i--)
        {
            if (curMax < price[i])
            {
                curMax = price[i];
            }
            afterMax[i] = curMax;
        }
        // afterMax가 자신보다 크면 코인을 사고,
        // 자신과 같으면서 코인을 가지고 있다면 모든 코인을 팔아버린다.
        int profit = 0;
        int coinCount = 0, cost = 0; // 가지고 있는 코인과 그들을 사는 데 쓴 비용
        for (int i = 0; i < n; i++)
        {
            if (afterMax[i] > price[i])
            {
                coinCount++;
                cost += price[i];
            }
            else if (afterMax[i] == price[i] && coinCount > 0)
            {
                profit += coinCount * price[i] - cost;
                coinCount = 0;
                cost = 0;
            }
        }
        Console.WriteLine(profit);
    }
}
