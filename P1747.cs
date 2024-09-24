using System;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        while(true){
            if (IsPrime(n) && IsPalindrome(n)){
                Console.WriteLine(n);
                break;
            }
            n++;
        }
    }
    
    public static bool IsPrime(int n){
        if (n == 1) return false;
        if (n == 2 || n == 3) return true;
        for (int i = 2 ; i * i <= n; i++){
            if (n % i == 0) return false;
        }
        return true;
    }
    
    public static bool IsPalindrome(int n){
        string num = n.ToString();
        for (int i = 0; i < num.Length; i++){
            if (num[i] != num[num.Length - 1 - i]) return false;
        }
        return true;
    }
}