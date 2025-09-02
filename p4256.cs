using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p4256 - 트리 (G2)
// #트리 #재귀
// 2025.6.6 start
// 2025.9.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

        int t = int.Parse(sr.ReadLine().Trim());
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(sr.ReadLine().Trim());
            List<int> preorder = sr.ReadLine().Trim().Split().Select(int.Parse).ToList();
            List<int> inorder = sr.ReadLine().Trim().Split().Select(int.Parse).ToList();

            List<int> postorder = new();
            FindPostOrder(preorder, inorder, postorder);
            sw.WriteLine(string.Join(" ", postorder));
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    // preorder, inorder를 받아 postorder에 그 순서를 추가하는 재귀함수
    // preorder, inorder의 크기는 같고, 각각에 들어있는 원소는 순서가 다른 같은 조합이다.
    public static void FindPostOrder(List<int> preorder, List<int> inorder, List<int> postorder)
    {
        // preorder의 길이를 가져옴
        int total = preorder.Count;
        // 비어있는 경우 재귀 끝
        if (total == 0 || inorder.Count == 0) return;
        // preorder의 맨 앞은 현재 서브트리의 루트이다.
        int root = preorder[0];
        // inorder에서 루트의 인덱스를 찾는다. (자동으로 왼쪽 서브트리의 크기를 의미)
        // inorder에서 루트를 기준으로 왼쪽에 있는 것은 왼쪽 서브트리, 오른쪽에 있는 것은 오른쪽 서브트리이다.
        int root_idx = inorder.IndexOf(root);
        // 오른쪽 서브트리의 크기
        int right = total - root_idx - 1;
        // 왼쪽 서브트리에서의 전위/중위 탐색결과를 기존 트리에서 찾는다.
        // 기존 전위 탐색에서 왼쪽 서브트리의 전위 탐색 결과는 맨 앞 루트를 뺀 1번 인덱스 부터 
        // 왼쪽 서브트리의 개수만큼의 부분 리스트이다.
        // 오른쪽 서브트리의 전위 탐색은 그 부분 다음 원소부터 리스트의 끝까지이다.
        // 중위 탐색은 기존 트리의 중위탐색에서 처음부터 루트 전까지가 왼쪽 서브트리의 중위 탐색,
        // 루트 다음부터 끝까지가 오른쪽 서브트리의 중위 탐색 결과가 된다.
        List<int> leftpre = preorder.GetRange(1, root_idx);
        List<int> leftin = inorder.GetRange(0, root_idx);
        List<int> rightpre = preorder.GetRange(1 + root_idx, right);
        List<int> rightin = inorder.GetRange(root_idx + 1, right);
        // 후위 탐색 : 왼쪽 서브트리 -> 오른쪽 서브트리 -> 루트 순으로 탐색
        FindPostOrder(leftpre, leftin, postorder);
        FindPostOrder(rightpre, rightin, postorder);
        postorder.Add(root);
    }
}
