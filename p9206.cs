using System;

// p9206 - 나무 말고 꽃 (P3)
// #미적분학 #수치해석
// 2025.6.22 solved

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        double V = double.Parse(input[0]);
        int n = int.Parse(input[1]);

        double[] volumes = new double[n];
        for (int i = 0; i < n; i++)
        {
            double[] info = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            double a = info[0], b = info[1], h = info[2];
            volumes[i] = FindVolume(a, b, h);
        }
        double minDiff = Math.Abs(V - volumes[0]);
        int minIndex = 0;
        for (int i = 1; i < n; i++)
        {
            double cur = Math.Abs(V - volumes[i]);
            if (cur < minDiff)
            {
                minIndex = i;
                minDiff = cur;
            }
        }
        Console.WriteLine(minIndex);
    }

    // f(x) = a・exp(-x^2)+ b・√x에 대해,
    // 정의역이 0~h인 f(x)를 x축에 대해 회전시킨 회전체의 부피를 구한다.
    // {f(x)}^2을 0~h까지 범위에서 정적분 한 것에 pi를 곱한 것과 같다.
    public static double FindVolume(double a, double b, double h)
    {
        // {f(x)}^2을 전개하면 A(x) + (b^2)*x가 된다.
        // 여기서 A(x) = a^2*exp(-2*x^2) + 2*a*b*sqrt(x)*exp(-x^2)로 초등함수 형태의 부정적분이 없다.
        // 부정적분이 있는 (b^2)*x는 두고, A(x)는 수치 적분을 한다.
        return Math.PI * (NumericalIntegral(a, b, h) + 0.5 * b * b * h * h);
    }

    // A(x)의 0~h까지의 정적분 근사치를 구한다.
    public static double NumericalIntegral(double a, double b, double h)
    {
        // A(x)를 람다 형태로 생성, a, b, h는 캡쳐한다.
        Func<double, double> A = (x) =>
        {
            return (Math.Pow(a, 2) * Math.Exp(-2 * Math.Pow(x, 2))) + 2 * a * b * Math.Sqrt(x) * Math.Exp(-1 * Math.Pow(x, 2));
        };

        // 사다리꼴 공식 사용
        // 적분하고자 하는 구간을 n등분 하면, 한 사다리꼴의 높이는 h / n이 된다.
        // 사다리꼴의 윗변과 아랫변 길이는 해당 x에서의 함숫값 A(x)와 같다.
        // 왼쪽 부분과, 오른쪽 부분에서의 함숫값을 구해 더한 뒤, 
        // h / n을 곱하고 2로 나누면 부분 사다리꼴의 넓이를 구할 수 있다.
        int n = 3000000;
        double sum = 0;
        double dx = h / (double)n;
        for (int k = 1; k <= n; k++)
        {
            double left = A(dx * (double)(k - 1));
            double right = A(dx * (double)k);
            sum += 0.5 * dx * (left + right);
        }
        return sum;
    }
}
