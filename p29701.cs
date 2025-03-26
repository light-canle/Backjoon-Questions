#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p29701 - 모스 부호 (B2)
// #문자열 #해시와 맵
// 2025.3.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        // 실은 키와 값을 거꾸로 잘못 넣은 것이다.
        // 그래서 아래에서 값으로 키를 받는 방식으로 짰는데 O(n)이 걸린다. 이 문제는 짧아서 상관없지만
        // 다른 문제였다면 이거를 거꾸로 만들었어야 한다.
        Dictionary<char, String> dic = new() { { 'A', ".-" }, { 'B', "-..." },
        { 'C', "-.-." }, { 'D', "-.." }, { 'E', "." }, { 'F', "..-." }, { 'G', "--." },
        { 'H', "...." }, { 'I', ".." }, { 'J', ".---" }, { 'K', "-.-" }, { 'L', ".-.." },
        { 'M', "--" }, { 'N', "-." }, { 'O', "---" }, { 'P', ".--." }, { 'Q', "--.-" },
        { 'R', ".-." }, { 'S', "..." }, { 'T', "-" }, { 'U', "..-" }, { 'V', "...-" },
        { 'W', ".--" }, { 'X', "-..-" }, { 'Y', "-.--" }, { 'Z', "--.." }, { '1', ".----" },
        { '2', "..---" }, { '3', "...--" }, { '4', "....-" }, { '5', "....." }, { '6', "-...." },
        { '7', "--..." }, { '8', "---.." }, { '9', "----." }, { '0', "-----" }, { ',', "--..--" },
        { '.', ".-.-.-" }, { '?', "..--.." }, { ':', "---..." }, { '-', "-....-" }, { '@', ".--.-." },}; 

        int n = int.Parse(Console.ReadLine());

        string[] letters = Console.ReadLine().Split();
        string ret = "";
        foreach (string letter in letters)
        {
            ret += dic.Where((x) => x.Value == letter).First().Key;
        }
        Console.WriteLine(ret);
    }
}
