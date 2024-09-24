using System;

/// <summary>
/// p1063 - 킹, S3
/// 해결 날짜 : 2023/10/20
/// 질문방 반례로 해결
/// </summary>

// 항상 문제를 잘 생각하고, 빠진 조건이 없는 것이 확인할 것

public class Position
{
    public int x;
    public int y;

    public Position(char x, int y)
    {
        this.x = Convert.ToInt32(x) - 64;
        this.y = y;
    }

    public bool Same(Position other)
    {
        return other.x == this.x && other.y == this.y;
    }

    public override string ToString()
    {
        return Convert.ToChar(x + 64).ToString() + y.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine()!.Split();
        Position kingPos = new Position(inputs[0][0], 
            int.Parse(inputs[0][1].ToString()));
        Position stonePos = new Position(inputs[1][0],
            int.Parse(inputs[1][1].ToString()));
        int N = int.Parse(inputs[2]);

        for (int i = 0; i < N; i++)
        {
            string move = Console.ReadLine()!;

            MovePiece(kingPos, stonePos, move);
        }

        Console.WriteLine(kingPos.ToString());
        Console.WriteLine(stonePos.ToString());
    }

    public static void MovePiece(Position king, Position stone, string move)
    {
        bool stoneMove = false;
        switch (move)
        {
            case "R":
                // Stone check
                if (stone.x - king.x == 1 && stone.y == king.y) // 빠뜨린 조건은 오른쪽으로 움직일 때 y좌표가 같은지 확인하는 것이었다.
                    stoneMove = true;
                // Boundary check
                if (stone.x < 8 && stoneMove) { stone.x++; }
                if (king.x < 8) { king.x++; }

                // Collision check
                if (king.Same(stone)) { king.x--; }
                break;

            case "L":
                // Stone check
                if (stone.x - king.x == -1 && stone.y == king.y)
                    stoneMove = true;
                // Boundary check
                if (stone.x > 1 && stoneMove) { stone.x--; }
                if (king.x > 1) { king.x--; }

                // Collision check
                if (king.Same(stone)) { king.x++; }
                break;

            case "B":
                // Stone check
                if (stone.y - king.y == -1 && stone.x == king.x)
                    stoneMove = true;
                // Boundary check
                if (stone.y > 1 && stoneMove) { stone.y--; }
                if (king.y > 1) { king.y--; }

                // Collision check
                if (king.Same(stone)) { king.y++; }
                break;
            case "T":
                // Stone check
                if (stone.y - king.y == 1 && stone.x == king.x)
                    stoneMove = true;
                // Boundary check
                if (stone.y < 8 && stoneMove) { stone.y++; }
                if (king.y < 8) { king.y++; }

                // Collision check
                if (king.Same(stone)) { king.y--; }
                break;
            case "RT":
                // Stone check
                if (stone.x - king.x == 1 && stone.y - king.y == 1)
                    stoneMove = true;
                // Boundary check
                if (stone.x < 8 && stone.y < 8 && stoneMove) { stone.x++; stone.y++; }
                if (king.x < 8 && king.y < 8) { king.x++; king.y++; }

                // Collision check
                if (king.Same(stone)) { king.x--; king.y--; }
                break;
            case "LT":
                // Stone check
                if (stone.x - king.x == -1 && stone.y - king.y == 1)
                    stoneMove = true;
                // Boundary check
                if (stone.x > 1 && stone.y < 8 && stoneMove) { stone.x--; stone.y++; }
                if (king.x > 1 && king.y < 8) { king.x--; king.y++; }

                // Collision check
                if (king.Same(stone)) { king.x++; king.y--; }
                break;
            case "RB":
                // Stone check
                if (stone.x - king.x == 1 && stone.y - king.y == -1)
                    stoneMove = true;
                // Boundary check
                if (stone.x < 8 && stone.y > 1 && stoneMove) { stone.x++; stone.y--; }
                if (king.x < 8 && king.y > 1) { king.x++; king.y--; }

                // Collision check
                if (king.Same(stone)) { king.x--; king.y++; }
                break;
            case "LB":
                // Stone check
                if (stone.x - king.x == -1 && stone.y - king.y == -1)
                    stoneMove = true;
                // Boundary check
                if (stone.x > 1 && stone.y > 1 && stoneMove) { stone.x--; stone.y--; }
                if (king.x > 1 && king.y > 1) { king.x--; king.y--; }

                // Collision check
                if (king.Same(stone)) { king.x++; king.y++; }
                break;
        }
    }
}