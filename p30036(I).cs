using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 유틸컵 Chapter2 - I번(3), INK
/// 30036 - S1
/// 해결 날짜 : 2023/9/16
/// </summary>

public class Obstacle
{
    public int y;
    public int x;

    public Obstacle(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}

public class Square
{
    public int y;
    public int x;
    public int inkAmount;
    public int jumpCount;
}
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int I, int N, int K) = (input[0], input[1], input[2]);
        string color = sr.ReadLine();

        List<List<char>> list = new List<List<char>>();
        List<Obstacle> obstacles = new List<Obstacle>(); ;
        Square s = new Square();
        s.inkAmount = 0;
        s.jumpCount = 0;
        for (int i = 0; i < N; i++)
        {
            list.Add(sr.ReadLine().ToList());
            for (int j = 0; j < N; j++)
            {
                if (list[i][j] == '@') 
                { 
                    s.y = i; 
                    s.x = j;
                }
                else if (list[i][j] == '#')
                {
                    obstacles.Add(new Obstacle(i, j));
                }
            }
        }
        string command = sr.ReadLine();

        for (int i = 0; i < command.Length; i++)
        {
            switch(command[i])
            {
                case 'U':
                    if (s.y != 0 && list[s.y - 1][s.x] == '.')
                    {
                        list[s.y - 1][s.x] = '@';
                        list[s.y][s.x] = '.';
                        s.y -= 1;
                    }
                    break;
                case 'D':
                    if (s.y != N - 1 && list[s.y + 1][s.x] == '.')
                    {
                        list[s.y + 1][s.x] = '@';
                        list[s.y][s.x] = '.';
                        s.y += 1;
                    } 
                    break;
                case 'L':
                    if (s.x != 0 && list[s.y][s.x - 1] == '.')
                    {
                        list[s.y][s.x - 1] = '@';
                        list[s.y][s.x] = '.';
                        s.x -= 1;
                    } 
                    break;
                case 'R':
                    if (s.x != N - 1 && list[s.y][s.x + 1] == '.')
                    {
                        list[s.y][s.x + 1] = '@';
                        list[s.y][s.x] = '.';
                        s.x += 1;
                    }
                    break;

                case 'j':
                    s.inkAmount += 1;
                    break;

                case 'J':
                    s.jumpCount++;
                    if (s.inkAmount == 0) break;
                    char current_color = color[(s.jumpCount - 1) % color.Length];
                    for (int j = 0; j < obstacles.Count; j++)
                    {
                        if (Distance(obstacles[j], s) <= s.inkAmount)
                        {
                            list[obstacles[j].y][obstacles[j].x] = current_color;
                        }
                    }
                    s.inkAmount = 0;
                    break;
            }
        }

        foreach(var l in list)
        {
            output.AppendLine(string.Join("", l));
        }

        Console.WriteLine(output);
        sr.Close();
    }

    public static int Distance(Obstacle ob, Square sq)
    {
        return Math.Abs(ob.y - sq.y) + Math.Abs(ob.x - sq.x);
    }
}