using System;

/// <summary>
/// p1264 - 모음의 개수
/// 해결 날짜 : 2023/9/9
/// </summary>

public class Program {
    public static void Main(string[] args) {
        while(true){
            string input = Console.ReadLine();
            if (input ==  "#") break;
            input = input.ToLower();
            int count = 0;
            for (int i = 0; i < input.Length; i++){
                if (input[i] == 'a' || input[i] == 'e' || 
                    input[i] == 'i'|| input[i] == 'o'|| input[i] =='u'){
                        count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}