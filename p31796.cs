using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// p31796 - 한빛미디어 (Easy) (S4)
// #그리디 #정렬
// 2025.6.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        List<int> prices = sr.ReadLine().Split().Select(int.Parse).ToList();
        prices.Sort();

        /*
        페이지 수를 최소화 하는 방법은 책들을 가격 순으로 오름차순 정렬하고
        가격이 작은 책부터 한 페이지에 넣는다.
        어느 책의 가격이 그 페이지의 가장 싼 책의 가격이 2배가 되는 순간이 오면
        새 페이지에 그 책을 꽂고 책들을 꽂는다.
        */
        int pages = 1;
        int minPrice = prices[0];
        for (int i = 1; i < n; i++)
        {
            if (prices[i] >= 2 * minPrice)
            {
                pages++;
                minPrice = prices[i];
            }
        }
        Console.WriteLine(pages);
        sr.Close();
    }
}
