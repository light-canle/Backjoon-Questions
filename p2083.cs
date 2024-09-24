using System;

/// <summary>
/// p2083 - 럭비 클럽, B4
/// 해결 날짜 : 2023/9/29
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "# 0 0") 
            {
                break;
            }
            string[] info = input.Split();
            int age = int.Parse(info[1]);
            int weight = int.Parse(info[2]);

            if (age > 17 ||  weight >= 80) 
            {
                Console.WriteLine($"{info[0]} Senior");
            }
            else
            {
                Console.WriteLine($"{info[0]} Junior");
            }
        }
    }
}