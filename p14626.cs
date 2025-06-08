using System;

// p14626 - ISBN (B1)
// #사칙연산 #완전 탐색
// 2025.6.8 solved

public class Program
{
    public static void Main(string[] args)
    {
        string ISBN = Console.ReadLine();
        // 손상된 자리의 인덱스가 홀수인가?
        bool isOdd = true;
        // 손상된 자리를 제외한 12자리의 체크 값의 합
        int checkValue = 0;
        for (int i = 0; i < 13; i++)
        {
            if (ISBN[i] == '*') 
            {
                isOdd = i % 2 == 1 ? true : false;
                continue;
            }
            // 짝수 인덱스는 더하고, 홀수 인덱스는 3을 곱해서 더함
            if (i % 2 == 0)
            {
                checkValue += ISBN[i] - '0';
            }
            else
            {
                checkValue += 3 * (ISBN[i] - '0');
            }
        }
        // 0 ~ 9까지 수 중 손상된 자리에 들어갈 수를 구한다.
        for (int i = 0; i < 10; i++)
        {
            // 손상된 자리 인덱스가 홀수이면 가중치 3을 곱하고, 아니면 그냥 더함
            int sum = checkValue + (isOdd ? 3 * i : i);
            if (sum % 10 == 0)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}
