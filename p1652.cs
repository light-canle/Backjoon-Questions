using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Program
{
		public static void Main(string[] args)
		{
		    StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
		    
		    int n = int.Parse(sr.ReadLine());
		    List<string> room = new List<string>();
		    
		    for (int i = 0; i < n; i++)
		    {
		        room.Add(sr.ReadLine());
		    }
		    
		    int countH = 0, countV = 0, space = 0;
		    
		    for (int i = 0; i < n; i++)
		    {
		        space = 0;
		        for (int j = 0; j < n; j++)
		        {
		            if (room[i][j] == '.')
		            {
		                space++;
		            }
		            else if (room[i][j] == 'X')
		            {
		                if (space >= 2)
		                {
		                    countH++;
		                }
		                space = 0;
		            }
		        }
		        if (space >= 2){
		            countH++;
		        }
		    }
		    
		    for (int i = 0; i < n; i++)
		    {
		        space = 0;
		        for (int j = 0; j < n; j++)
		        {
		            if (room[j][i] == '.')
		            {
		                space++;
		            }
		            else if (room[j][i] == 'X')
		            {
		                if (space >= 2)
		                {
		                    countV++;
		                }
		                space = 0;
		            }
		        }
		        if (space >= 2){
		            countV++;
		        }
		    }
		    
		    Console.WriteLine(countH + " " + countV);
		    sr.Close();
		}
}
