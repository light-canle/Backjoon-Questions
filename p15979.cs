using System;

// p15979 - 스승님 찾기 (S2)
// #유클리드 호제법 #애드 혹
// 2025.7.9 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] point = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int x = point[0], y = point[1];
        // (0, 0)에서 시작하므로 도착점이 원점이면 이동할 필요가 없다.
        if (x == 0 && y == 0)
        {
            Console.WriteLine(0);
        }
        // (x, y)에서 x, y의 절댓값의 최대공약수가 1이면
        // (0, 0)과 (x, y)를 이은 선분에서 x좌표가 1 ~ x-1 사이 정수일 때
        // y좌표가 정수가 되는 점이 없으므로 한 번에 이동 가능하다.
        else if (GCD(Abs(x), Abs(y)) == 1)
        {
            Console.WriteLine(1);
        }
        /*
        그 외의 점은 2번 안에 이동할 수 있다.
        (1) 어떤 점에서 x좌표가 1 차이나거나 y좌표가 1 차이나는 점은 한 번에 이동할 수 있다.
        두 점을 잇는 선분에서 한 좌표가 정수가 되도 다른 점이 정수가 되는 점이 양 끝점 외에는 없기 때문이다.
        (2) (0, 0)에서 (m - 1, 1)은 한 번에 갈 수 있고, 
        (m - 1, 1)에서 (m, n)까지도 한 번에 갈 수 있다.
        즉, 2번의 이동으로 (0,0)에서 1사분면의 임의의 점으로 최대 2번 안에 이동가능하다.
        (3) 비슷한 방법으로 x축 대칭, y축 대칭을 적용하여 (0,0)에서 모든 사분면의 임의의 점으로
        (2)의 경로를 써서 최대 2번 안에 이동 가능하다.
        */
        else
        {
            Console.WriteLine(2);
        }
    }

    public static int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }

    public static int Abs(int n)
    {
        if (n < 0) return -n;
        return n;
    }
}
