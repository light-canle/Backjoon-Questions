using System;
using System.Linq;
using System.Collections.Generic;

// p2577 - 숫자의 개수, B2 
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        List<int> input = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            input.Add(int.Parse(Console.ReadLine()));
        }

        string product = (input[0] * input[1] * input[2]).ToString();

        List<int> count = new List<int>(new int[10]);

        for (int i = 0 ; i < product.Length ; i++) 
        {
            count[Convert.ToInt32(product[i]) - Convert.ToInt32('0')]++;
        }

        for (int i = 0 ; i < 10; i++)
        {
            Console.WriteLine(count[i]);
        }
        
    }
}
