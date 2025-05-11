using System;

// p5613 - 계산기 프로그램 (B3)
// #사칙연산 #구현
// 2025.5.11 solved

public class Program
{
    public static void Main(string[] args)
    {
        int calMode = 0;
        int ret = int.Parse(Console.ReadLine());
        while (true)
        {
            string s = Console.ReadLine();
            bool isOp = false;
            // 입력으로 연산자 또는 =이 입력된 경우
            switch (s)
            {
            case "+":
                calMode = 1; isOp = true;
                break;
            case "-":
                calMode = 2; isOp = true;
                break;
            case "*":
                calMode = 3; isOp = true;
                break;
            case "/":
                calMode = 4; isOp = true;
                break;
            case "=": // 결과를 출력하고 종료
                Console.WriteLine(ret);
                return;
            }
            if (isOp) continue; // 연산자임이 확인되었으므로 건너뛴다.
            int num = int.Parse(s);
            // 결과값에 누적
            switch (calMode)
            {
            case 1:
                ret += num;
                break;
            case 2:
                ret -= num;
                break;
            case 3:
                ret *= num;
                break;
            case 4:
                ret /= num;
                break;
            }
        }
    }
}
