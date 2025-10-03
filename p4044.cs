#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p4044 - 도전 24 (G2)
// #백트래킹 #스택 #사칙연산 #완전 탐색
// 2025.10.3 solved

public class Program
{
    public static void Main(string[] args)
    {
        int caseNum = 0;
        while (true)
        {
            caseNum++;
            int[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            int a = input[0], b = input[1], c = input[2], d = input[3];
            if (a + b + c + d == 0)
            {
                break;
            }

            List<int> results = AllPossibleResult(a, b, c, d);

            int maxLen = 0;
            int rangeStart = -987654321, rangeEnd = -987654321;
            int curRangeStart = results[0], curRangeEnd = results[0];
            int curLen = 1;
            int prev = -987654321;
            foreach (int cur in results)
            {
                if (cur == prev + 1)
                {
                    curLen++;
                }
                else
                {
                    // cur 전까지 구간의 종료 지점을 구함
                    curRangeEnd = prev;
                    // 최대 길이 갱신 - 길이가 같아도 큰 수를 우선하기 위해 갱신
                    if (curLen >= maxLen)
                    {
                        maxLen = curLen;
                        rangeStart = curRangeStart;
                        rangeEnd = curRangeEnd;
                    }
                    // 구간 초기화
                    curLen = 1;
                    curRangeStart = cur;
                }
                prev = cur;
            }

            // 마지막 구간에 대한 갱신
            curRangeEnd = prev;
            if (curLen >= maxLen)
            {
                maxLen = curLen;
                rangeStart = curRangeStart;
                rangeEnd = curRangeEnd;
            }
            
            Console.WriteLine($"Case {caseNum}: {rangeStart} to {rangeEnd}");
        }
    }

    // a, b, c, d를 이용해서 만들 수 있는 모든 사칙연산 식을 계산했을 때 나올 수 있는 모든 결과를 찾음 (단, 정수만)
    public static List<int> AllPossibleResult(int a, int b, int c, int d)
    {
        List<int> ret = new();

        // a, b, c, d의 모든 순서 조합
        string[] nums = { a.ToString(), b.ToString(), c.ToString(), d.ToString() };
        List<string[]> orders = new();
        Order(nums, new bool[4], new string[4], 0, orders);

        // +, -, *, /의 길이 3짜리 중복 순열
        string[] oper = { "+", "-", "*", "/" };
        List<string[]> operOrders = new();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    string[] aOperOrder = new string[3];
                    aOperOrder[0] = oper[i];
                    aOperOrder[1] = oper[j];
                    aOperOrder[2] = oper[k];
                    operOrders.Add(aOperOrder);
                }
            }
        }

        /*
        가능한 후위 표기식의 형태는 아래 5가지가 있다.
        ab+c-d+
        ab+cd+-
        abc+d-+
        abc+-d+
        abcd+-+
        모든 숫자 x 연산자 조합에 대하여 후위 표기식을 5개씩 만든다. 총 24 x 64 x 5 = 7680가지
        */
        List<List<string>> postfixs = new();
        foreach (var num in orders)
        {
            foreach (var op in operOrders)
            {
                postfixs.Add(new() { num[0], num[1], op[0], num[2], op[1], num[3], op[2] });
                postfixs.Add(new() { num[0], num[1], op[0], num[2], num[3], op[1], op[2] });
                postfixs.Add(new() { num[0], num[1], num[2], op[0], num[3], op[1], op[2] });
                postfixs.Add(new() { num[0], num[1], num[2], op[0], op[1], num[3], op[2] });
                postfixs.Add(new() { num[0], num[1], num[2], num[3], op[0], op[1], op[2] });
            }
        }

        // 7680개의 식 계산
        foreach (var postfix in postfixs)
        {
            int? cal = Calculate(postfix);
            if (cal != null)
            {
                ret.Add(cal.Value);
            }
        }
        // 계산 결과 중 중복된 것은 하나로 만들고, 정렬 후 반환
        ret = ret.Distinct().ToList();
        ret.Sort();

        return ret;
    }

    public static void Order(string[] nums, bool[] visited, string[] ret, int depth, List<string[]> all)
    {
        // 4개 모두 선택
        if (depth == 4)
        {
            string[] arr = new string[4];
            // ret는 계속 바뀌므로 현재 ret의 복사본으로 전달해야 한다.
            Array.Copy(ret, arr, 4);
            all.Add(arr);
            return;
        }
        for (int i = 0; i < 4; i++)
        {
            if (!visited[i]) {
                visited[i] = true;
                ret[depth] = nums[i];
                Order(nums, visited, ret, depth + 1, all);
                visited[i] = false;
            }
        }
    }

    public static int? Calculate(List<string> postfix)
    {
        // 피연산자 스택
        Stack<int> numbers = new();

        foreach (string n in postfix)
        {
            // 연산자이면 스택에서 값 2개를 뺀 뒤 연산자에 대응하는 연산을 수행함
            if (n == "+" || n == "-" ||
                n == "/" || n == "*")
            {
                int a = numbers.Pop();
                int b = numbers.Pop();
                switch (n)
                {
                    case "+":
                        numbers.Push(b + a);
                        break;
                    case "-":
                        numbers.Push(b - a);
                        break;
                    case "*":
                        numbers.Push(b * a);
                        break;
                    case "/":
                        // 나누는 수가 0이거나 나눗셈의 결과가 정수가 되지 않으면 null
                        if (a == 0 || b % a != 0)
                        {
                            return null;
                        }
                        numbers.Push(b / a);
                        break;
                }
            }
            else
            {
                numbers.Push(int.Parse(n));
            }
        }
        return numbers.Pop();
    }
}
