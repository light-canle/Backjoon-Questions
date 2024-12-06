using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program {
	public static void Main() {
		while (true)
		{
			StringBuilder s = new StringBuilder();
			List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
			if (nums[0] == 0)
			{
				break;
			}
			int n = nums[0];
			nums.RemoveAt(0);
			FindAll(nums, n, 0, 6, new List<int>(), s);
			Console.WriteLine(s);
		}
	}
	public static void FindAll(List<int> nums, int n, int front, int left, List<int> cur, StringBuilder s)
	{
		if (left == 0)
		{
			s.AppendLine(string.Join(" ", cur));
			return;
		}
		for (int i = front; i < n; i++)
		{
			cur.Add(nums[i]);
			FindAll(nums, n, i + 1, left - 1, cur, s);
			cur.RemoveAt(cur.Count - 1);
		}
	}
}
