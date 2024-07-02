using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int s = int.Parse(input[0]);
        int len = input[1].Length;
        char[,] ret = LCD(s, input[1]);
        for (int i = 0; i < 2*s+3; i++)
        {
            for (int j = 0; j < len * (s + 2) + (len - 1); j++)
            {
                Console.Write(ret[i, j]);
            }
            Console.WriteLine();
        }
    }

    public static char[,] LCD(int s, string l)
    {
        int len = l.Length;
        char[,] ret = new char[2*s + 3, len * (s + 2) + (len - 1)];

        for (int i = 0; i < 2*s+3; i++)
        {
            for (int j = 0; j < len * (s + 2) + (len - 1); j++)
            {
                ret[i, j] = ' ';
            }
        }

        for (int i = 0; i < len; i++)
        {
            int xs = i * (s + 2) + i;
            int half = (2*s+3) / 2;
            switch (l[i])
            {
            case '0':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[0, xs + j] = '-';
                    ret[2*s+2, xs+j] = '-';
                }
                for (int j = 1; j < 2*s + 2; j++)
                {
                    if (j == half) continue;
                    ret[j, xs] = '|';
                    ret[j, xs + s + 1] = '|';
                }
                break;

            case '1':
                for (int j = 1; j < 2*s + 2; j++)
                {
                    if (j == half) continue;
                    ret[j, xs + s + 1] = '|';
                }
                break;

            case '2':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[0, xs + j] = '-';
                    ret[half, xs + j] = '-';
                    ret[2*s+2, xs+j] = '-';
                }
                for (int j = 1; j < half; j++)
                    ret[j, xs + s + 1] = '|';
                for (int j = half + 1; j < 2*s + 2; j++)
                    ret[j, xs] = '|';
                break;

            case '3':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[0, xs + j] = '-';
                    ret[half, xs + j] = '-';
                    ret[2*s+2, xs+j] = '-';
                }
                for (int j = 1; j < 2*s+2; j++)
                {
                    if (j == half) continue;
                    ret[j, xs + s + 1] = '|';
                }
                break;
            case '4':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[half, xs + j] = '-';         
                }
                for (int j = 1; j < half; j++)
                    ret[j, xs] = '|';
                for (int j = 1; j < 2*s+2; j++)
                {
                    if (j == half) continue;
                    ret[j, xs + s + 1] = '|';
                }
                break;

            case '5':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[0, xs + j] = '-';
                    ret[half, xs + j] = '-';
                    ret[2*s+2, xs+j] = '-';
                }
                for (int j = 1; j < half; j++)
                    ret[j, xs] = '|';
                for (int j = half + 1; j < 2*s + 2; j++)
                    ret[j, xs + s + 1] = '|';
                break;

            case '6':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[0, xs + j] = '-';
                    ret[half, xs + j] = '-';
                    ret[2*s+2, xs+j] = '-';
                }
                for (int j = 1; j < half; j++)
                    ret[j, xs] = '|';
                for (int j = half + 1; j < 2*s + 2; j++)
                {
                    ret[j, xs] = '|';
                    ret[j, xs + s + 1] = '|';
                }
                    
                break;
            case '7':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[0, xs + j] = '-';
                }
                for (int j = 1; j < 2*s + 2; j++)
                {
                    if (j == half) continue;
                    ret[j, xs + s + 1] = '|';
                }
                break;

            case '8':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[0, xs + j] = '-';
                    ret[half, xs + j] = '-';
                    ret[2*s+2, xs+j] = '-';
                }
                for (int j = 1; j < 2*s + 2; j++)
                {
                    if (j == half) continue;
                    ret[j, xs] = '|';
                    ret[j, xs + s + 1] = '|';
                }
                break;
            case '9':
                for (int j = 1; j < s + 1; j++)
                {
                    ret[0, xs + j] = '-';
                    ret[half, xs+j] = '-';
                    ret[2*s+2, xs+j] = '-';
                }
                for (int j = 1; j < half; j++)
                {
                    ret[j, xs] = '|';
                    ret[j, xs + s + 1] = '|';
                }
                for (int j = half + 1; j < 2*s + 2; j++)
                {
                    ret[j, xs + s + 1] = '|';
                }
                break;
            }
        }
        return ret;
    }
}
