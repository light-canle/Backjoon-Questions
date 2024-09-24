using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// 유틸컵 Chapter2 - T번(4), Tier and Rank
/// p30035 - G4
/// 해결 날짜 : 2023/9/16
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int N, int T) = (input[0], input[1]);
        
        Dictionary<string, string> tiers = new Dictionary<string, string>();
        for (int i = 0; i < T; i++)
        {
            string[] t = sr.ReadLine().Split();
            tiers[t[0]] = t[1];
        }
        string checkTier = sr.ReadLine();

        // 1. Valid Check - 가능한 시스템인지 판단
        List<int> peopleInTier = new List<int>();
        int remain = N;
        foreach (string t in tiers.Values) 
        {
            if (t[^1] == '%')
            {
                int num = (int)Math.Floor((long)remain * int.Parse(t.Substring(0, t.Length - 1)) / 100.0);
                peopleInTier.Add(num);
                remain -= num;
                if (remain <= 0) { remain = 0; }
            }
            else
            {
                peopleInTier.Add(Math.Min(int.Parse(t), remain));
                remain -= int.Parse(t);
                if (remain <= 0) { remain = 0; }
            }    
        }

        if (remain > 0)
        {
            Console.WriteLine("Invalid System");
            return;
        }

        // 2. 해당 티어의 세부 티어를 조사
        int tierMinor = 0;
        int.TryParse(checkTier[^1].ToString(), out tierMinor);
        string tierMajor = (tierMinor == 0) ? checkTier : checkTier.Substring(0, checkTier.Length - 1);
        
        int index = 0;
        int priorPeople = 0;
        int upper = 0, lower = 0;
        if (!tiers.ContainsKey(tierMajor))
        {
            Console.WriteLine("Liar");
            return;
        }
        foreach(string t in tiers.Keys)
        {
            if (tierMajor == t)
            {
                if (tierMinor == 0)
                {
                    if (peopleInTier[index] == 0)
                    {
                        Console.WriteLine("Liar");
                        return;
                    }
                    else
                    {
                        upper = priorPeople + 1;
                        lower = upper + peopleInTier[index] - 1;
                    }
                    break;
                }
                int maxSubTier = (int)Math.Ceiling(peopleInTier[index] / 4.0);
                int[] peopleInSubTier = new int[4];
                int remainSub = peopleInTier[index];

                for (int i = 0; i < 4; i++)
                {
                    peopleInSubTier[i] = Math.Min(remainSub, maxSubTier);
                    remainSub -= maxSubTier;
                    if (remainSub <= 0) { remainSub = 0; }
                }
                if (peopleInSubTier[tierMinor - 1] == 0)
                {
                    Console.WriteLine("Liar");
                    return;
                }
                else
                {
                    for (int i = 0; i < tierMinor - 1; i++)
                        priorPeople += peopleInSubTier[i];
                    upper = priorPeople + 1;
                    lower = upper + peopleInSubTier[tierMinor - 1] - 1;
                    break;
                }
            }
            priorPeople += peopleInTier[index];
            index++;
        }
        Console.WriteLine($"{upper} {lower}");
        sr.Close();
    }
}