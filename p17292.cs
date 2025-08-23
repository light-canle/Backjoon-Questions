using System;
using System.Collections.Generic;

// p17292 - 바둑이 포커 (G5)
// #구현 #정렬
// 2025.8.23 solved

public class Card
{
    public int Number { get; private set; }
    public bool IsBlack { get; private set; }

    public Card(string c)
    {
        char n = c[0];
        if ('1' <= n && n <= '9')
        {
            Number = n - '0';
        }
        else if ('a' <= n && n <= 'f')
        {
            Number = n - 'a' + 10;
        }

        IsBlack = c[1] == 'b' ? true : false;
    }

    public override string ToString()
    {
        string num = Number.ToString();
        if (Number >= 10)
        {
            num = Convert.ToChar(Number + 'a' - 10).ToString();
        }
        string color = IsBlack ? "b" : "w";
        return num + color;
    }
}

public class Pair : IComparable<Pair>
{
    public Card C1 { get; private set; }
    public Card C2 { get; private set; }

    public Pair(Card c1, Card c2)
    {
        C1 = c1; C2 = c2;
    }

    public override string ToString()
    {
        return C1.ToString() + C2.ToString();
    }

    public bool IsStraight()
    {
        return Math.Abs(C1.Number - C2.Number) == 1 || (C1.Number == 15 && C2.Number == 1) || (C1.Number == 1 && C2.Number == 15);
    }

    public bool IsSameNumber()
    {
        return C1.Number == C2.Number;
    }

    // 스트레이트는 3, 같은 수는 2, 그 외는 1
    public int Rank()
    {
        if (this.IsStraight()) return 3;
        else if (this.IsSameNumber()) return 2;
        return 1;
    }

    public bool IsSameColor()
    {
        return C1.IsBlack == C2.IsBlack;
    }

    public int MaxNumber()
    {
        return Math.Max(C1.Number, C2.Number);
    }

    public int MinNumber()
    {
        return Math.Min(C1.Number, C2.Number);
    }

    public bool MaxNumberColor()
    {
        int max = MaxNumber();
        if (C1.Number == max)
        {
            return C1.IsBlack;
        }
        else
        {
            return C2.IsBlack;
        }
    }

    // 서열에 따라 두 카드 쌍을 비교하는 함수
    // this가 더 높은 서열이면 양수, 아니먄 음수를 반환한다.
    public int CompareTo(Pair other)
    {
        /*
        서열의 순서
        1. 연속된 수 (1과 f는 연속)
        2. 같은 수
        3. 그 외
        */
        if (this.Rank() != other.Rank())
        {
            return this.Rank() - other.Rank();
        }
        /*
        같은 서열 내 순위
        1. 색이 같은 쌍
        2. 큰 수가 큰 쪽
        3. 작은 수가 큰 쪽
        4. 큰 수가 검은색
        */
        else
        {
            bool tsc = this.IsSameColor();
            bool osc = other.IsSameColor();
            if (tsc != osc) 
                return tsc ? 1 : -1;
            else if (this.MaxNumber() != other.MaxNumber())
                return this.MaxNumber() - other.MaxNumber();

            else if (this.MinNumber() != other.MinNumber())
                return this.MinNumber() - other.MinNumber();

            else if (this.MaxNumberColor())
                return 1;
            else
                return -1;
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        string[] cardStr = Console.ReadLine().Split(',');

        List<Card> cards = new();
        foreach (string c in cardStr)
        {
            cards.Add(new Card(c));
        }

        List<Pair> pairs = new();

        for (int i = 0; i < 5; i++)
        {
            for (int j = i + 1; j < 6; j++)
            {
                pairs.Add(new Pair(cards[i], cards[j]));
            }
        }

        pairs.Sort();
        pairs.Reverse();

        foreach (var p in pairs)
        {
            Console.WriteLine(p);
        }
    }
}
