using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p16927 - 배열 돌리기 2 (G5)
// #구현
// 2025.7.25 solved

public struct Pos
{
    public int x, y;
    public Pos(int y, int x)
    {
        this.x = x;
        this.y = y;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = nums[0], m = nums[1], r = nums[2];
        List<List<int>> board = new();
        for (int i = 0; i < n; i++)
        {
            board.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        // 현재 고리의 왼쪽 위, 왼쪽 아래, 오른쪽 아래, 오른쪽 위의 위치 (처음에는 보드의 맨 끝 모서리)
        Pos lt = new(0, 0);
        Pos lb = new(n - 1, 0);
        Pos rb = new(n - 1, m - 1);
        Pos rt = new(0, m - 1);

        // 
        while (lt.y < lb.y && lt.x < rt.x)
        {
            // 현재 고리에 속한 모든 요소를 가져온다.
            var order = ReadRing(board, lt, lb, rb, rt);
            // 고리의 길이를 구한다.
            int ringLen = RingLength(lt, lb, rb, rt);
            // r번 움직였을 때, lt에 올 요소의 인덱스를 구한다.
            int start = r % ringLen;
            // start에 넣은 나머지를 반전시킨다.
            /*
            Note : 반시계 방향으로 2칸 움직이면, 시작 위치 인덱스는 2번이 아니라, 4번이어야 한다.
                   2회
            1 2 3  ->  3 6 5
            4 5 6      2 1 4
            order : 1 4 5 6 3 2
            3이 lt가 되어야 하므로, 2번 움직이면, start는 2가 아니라, (6 - 2) mod 6 = 4가 된다.
            r이 ringLen으로 나누어 떨어지면, 결국 순환하지 않은 것과 같아 움직인 횟수가 0이 되므로,
            start는 ringLen - start를 ringLen으로 나눈 나머지가 되어야 한다.
            */
            start = (ringLen - start) % ringLen;
            // 구한 시작 위치부터 반시계 방향으로 요소들을 다시 붙여 넣는다.
            WriteRing(board, order, lt, lb, rb, rt, start);
            // 대각선 방향으로 1칸씩 움직여서 안쪽의 고리로 이동한다.
            /*
            lt $..$ rt     ....
               ....        .$$.
               ....    ->  .$$.
            lb $..$ rd     ....
            */
            lt.x++; lt.y++;
            lb.x++; lb.y--;
            rb.x--; rb.y--;
            rt.x--; rt.y++;
        }

        foreach (var line in board)
        {
            sw.WriteLine(string.Join(" ", line));
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    // lt, lb, rb, rt를 경계로 한 고리 부분의 데이터를 lt부터 반시계방향으로 돌면서 탐색한 것을 반환
    /*
    alkj     
    b..i  -> [a b c d e f g h i j k l]을 반환 
    c..h
    defg
    */
    public static List<int> ReadRing(List<List<int>> board, Pos lt, Pos lb, Pos rb, Pos rt)
    {
        List<int> ret = new();
        int y = lt.y, x = lt.x; // 현재 위치
        // lt -> lb로 이동 (아래로 이동 : y좌표 증가)
        while (y < lb.y)
        {
            ret.Add(board[y][x]);
            y++;
        }
        // lb -> rb로 이동 (오른쪽으로 이동 : x좌표 증가)
        while (x < rb.x)
        {
            ret.Add(board[y][x]);
            x++;
        }
        // rb -> rt로 이동 (위로 이동 : y좌표 감소)
        while (y > rt.y)
        {
            ret.Add(board[y][x]);
            y--;
        }
        // rt -> lt로 이동 (왼쪽으로 이동 : x좌표 감소)
        while (x > lt.x)
        {
            ret.Add(board[y][x]);
            x--;
        }
        return ret;
    }

    // lt, lb, rb, rt를 경계로 한 고리 부분에 toWrite에 있는 데이터를 start번 인덱스 요소부터 채운다.
    // start번 인덱스의 요소가 lt에 들어가고 이후 반시계 방향으로 순차적으로 넣는다. toWrite의 끝에 도달하면 처음으로 돌아간다.
    /*
    %%%% start : 3                     4 3 2 1
    %%%% toWrite : 1 2 3 4 5 6 7 8 ->  5 6 7 8
    */
    public static void WriteRing(List<List<int>> board, List<int> toWrite, Pos lt, Pos lb, Pos rb, Pos rt, int start)
    {
        int y = lt.y, x = lt.x;
        int idx = start;
        int ringLen = RingLength(lt, lb, rb, rt); // 링의 길이가 필요함 (마지막 인덱스에서 0으로 가야 하므로)
        // 도는 순서는 위의 ReadRing과 동일하다.
        while (y < lb.y)
        {
            // 현재 위치에 idx에 해당하는 값을 넣고 idx에 1 누적. idx가 ringLen이 되면 0이 된다.
            board[y][x] = toWrite[idx];
            idx = (idx + 1) % ringLen;
            y++;
        }
        while (x < rb.x)
        {
            board[y][x] = toWrite[idx];
            idx = (idx + 1) % ringLen;
            x++;
        }
        while (y > rt.y)
        {
            board[y][x] = toWrite[idx];
            idx = (idx + 1) % ringLen;
            y--;
        }
        while (x > lt.x)
        {
            board[y][x] = toWrite[idx];
            idx = (idx + 1) % ringLen;
            x--;
        }
    }

    // lt, lb, rb, rt를 경계로 한 고리 부분의 길이를 반환한다.
    // 가로 길이가 w, 세로 길이가 h이면, 2(w+h)-4이다. 모서리가 2번 세지므로 4를 뺐다.
    public static int RingLength(Pos lt, Pos lb, Pos rb, Pos rt)
    {
        int w = rt.x - lt.x + 1;
        int h = lb.y - lt.y + 1;
        return 2 * (w + h) - 4;
    }
}
