using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class P11650{
    public class Point{
        public int x, y;

        public Point(int _x, int _y){
            x = _x; 
            y = _y;
        }
    }
    static void Main(string[] args){
        int N = int.Parse(Console.ReadLine());
        List<Point> points = new List<Point>();
        for (int i = 0; i < N; i++){
            string input = Console.ReadLine();
            int[] num_input = input.Trim().Split(' ').Select(s => int.Parse(s)).ToList().ToArray();
            points.Add(new Point(num_input[0], num_input[1]));
        }

        var result = points.OrderBy(p => p.x).ThenBy(p => p.y);

        StringBuilder str = new StringBuilder("");
        foreach (var element in result){
            str.Append($"{element.x} {element.y}\n");
        }
        Console.WriteLine(str);
    }
}