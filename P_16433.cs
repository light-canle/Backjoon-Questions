using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class P16433{
    static void Main(string[] args){
        string input = Console.ReadLine();
        int[] num_input = input.Trim().Split(' ').Select(s => int.Parse(s)).ToList().ToArray();
        
        int criteria_y = num_input[1];
        int criteria_x = num_input[2];
        
        StringBuilder str = new StringBuilder();
        for (int i = 1; i <= num_input[0]; i++){
            for (int j = 1; j <= num_input[0]; j++){
                if (i % 2 == criteria_y % 2){
                    if (j % 2 == criteria_x % 2)
                        str.Append("v");
                    else
                        str.Append(".");
                }
                else{
                    if (j % 2 == criteria_x % 2)
                        str.Append(".");
                    else
                        str.Append("v");
                }
            }
            str.Append("\n");
        }
        Console.WriteLine(str);
    }
}