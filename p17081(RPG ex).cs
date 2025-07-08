using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Numerics;
using System.Collections.Generic;

// p17081 - RPG Extreme (P2)
// #시뮬레이션
// 2024.6.23 solved

public enum IType
{
    Weapon, Armor, Accessory,
}

public enum AType
{
    HR, RE, CO, EX, DX, HU, CU,
}

public class Player
{
    public int originY;
    public int originX;
    public int y;
    public int x;
    public int lv;
    public int hp;
    public int maxHp;
    public int atk;
    public int weaponAtk;
    public int def;
    public int armorDef;
    public int curExp;
    public int maxExp;
    public bool isAlive;
    public string killedBy;
    public List<AType> accessories;

    public Player()
    {
        lv = 1;
        hp = 20;
        maxHp = 20;
        atk = 2;
        weaponAtk = 0;
        def = 2;
        armorDef = 0;
        curExp = 0;
        maxExp = 5;
        isAlive = true;
        accessories = new();
    }

    public void GainExp(int exp)
    {
        curExp += exp;
        if (curExp >= maxExp)
        {
            lv++;
            atk += 2;
            def += 2;
            maxHp += 5;
            hp = maxHp;
            curExp = 0;
            maxExp = lv * 5;
        }
    }

    public bool AccessoryCheck(AType type)
    {
        return accessories.Contains(type);
    }

    public bool AccessoryFull() => accessories.Count >= 4;
    
    public int Attack(bool isFirstAttack)
    {
        int total = atk + weaponAtk;
        if (isFirstAttack && AccessoryCheck(AType.CO))
        {
            if (AccessoryCheck(AType.DX))
                total *= 3;
            else
                total *= 2;
        }
        
        return total;
    }

    // amount에는 적의 순수 공격력을 넣음
    public void Damage(int amount)
    {
        int dmg = (amount - def - armorDef);
        hp -= Math.Max(dmg, 1);
    }

    public void TrapTrigger()
    {
        if (AccessoryCheck(AType.DX))
            hp -= 1;
        else
            hp -= 5;
        DeadCheck();
        if (!isAlive)
            killedBy = "SPIKE TRAP";
    }

    public void DeadCheck()
    {
        if (hp <= 0)
        {
            if (AccessoryCheck(AType.RE))
            {
                hp = maxHp;
                y = originY;
                x = originX;
                accessories.Remove(AType.RE);
                return;
            }
            else
            {
                hp = 0;
                isAlive = false;
            }
        }
    }
}

public class Monster
{
    public string name;
    public int atk;
    public int def;
    public int hp;
    public int maxHp;
    public int gainExp;
    public bool isBoss;
    public bool isAlive;
    
    public Monster(string name, int atk, int def, int maxHp, int gainExp, bool isBoss)
    {
        this.name = name;
        this.atk = atk;
        this.def = def;
        this.hp = maxHp;
        this.maxHp = maxHp;
        this.gainExp = gainExp;
        this.isBoss = isBoss;
        isAlive = true;
    }

    public void Damage(int amount)
    {
        this.hp -= Math.Max((amount - def), 1);
        if (this.hp <= 0)
            isAlive = false;
    }
}

public class Item
{
    public IType itemType;
    public int power;
    public AType accessoryType;

    public Item(char itemType, int power)
    {
        this.itemType = itemType == 'W' ? IType.Weapon : itemType == 'A' ? IType.Armor : IType.Accessory;
        this.power = power;
    }
    public Item(AType accessoryType)
    {
        this.itemType = IType.Accessory;
        this.accessoryType = accessoryType;
    }
}

public class Program
{
    public static List<List<char>> grid = new();
    public static Dictionary<(int, int), Monster> monsters = new();
    public static Dictionary<(int, int), Item> items = new();
    public static Player player = new();

    public static int Battle(Monster monster)
    {
        // 플레이어가 보스 배틀에서 HU 장신구를 가지고 있을 경우 체력이 완충된다.
        if (player.AccessoryCheck(AType.HU) && monster.isBoss)
        {
            player.hp = player.maxHp;
        }
        
        // 플레이어 선공이 원칙
        // 1턴 공격 - 장신구에 따라 피해량이 달라짐
        bool isFirst = true;
        while (true)
        {
            monster.Damage(player.Attack(isFirst));
            if (monster.hp <= 0)
            {
                int exp = monster.gainExp;
                if (player.AccessoryCheck(AType.EX))
                {
                    exp = (int)((double)exp * 1.2);
                }
                player.GainExp(exp);
                return 1;
            }

            // 보스 몬스터의 경우 HU를 끼고 있을 때 1턴 공격은 무효화 된다.
            if (!isFirst)
            {
                player.Damage(monster.atk);
            }
            else
            {
                if (!player.AccessoryCheck(AType.HU) || !monster.isBoss)
                {
                    player.Damage(monster.atk);
                }
            }
            
            if (player.hp <= 0)
            {
                monster.hp = monster.maxHp;
                if (player.AccessoryCheck(AType.RE))
                {
                    player.hp = player.maxHp;
                    player.y = player.originY;
                    player.x = player.originX;
                    player.accessories.Remove(AType.RE);
                    return 0;
                }
                else
                {
                    player.isAlive = false;
                    player.hp = 0;
                    player.killedBy = monster.name;
                    
                    return -1;
                }
            }
            isFirst = false;
        }
    }
    
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));

        // input
        int[] size = sr.ReadLine().Split().Select(int.Parse).ToArray();

        (int N, int M) = (size[0], size[1]);

        for (int i = 0; i < N; i++)
        {
            grid.Add(sr.ReadLine().ToCharArray().ToList());
        }

        // determine # of monsters, item box and boss' position
        int monsterCount = 0;
        int itemBoxCount = 0;
        int bossY = 0, bossX = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                switch (grid[i][j])
                {
                case 'M':
                    bossY = i; bossX = j;
                    monsterCount++;
                    break;
                case '&':
                    monsterCount++;
                    break;
                case 'B':
                    itemBoxCount++;
                    break;
                case '@':
                    player.originY = i; player.originX = j;
                    player.y = i; 
                    player.x = j;
                    grid[i][j] = '.';
                    break;
                }
            }
        }
        string command = sr.ReadLine();

        // read information of monsterd and items
        for (int i = 0; i < monsterCount; i++)
        {
            string[] info = sr.ReadLine().Split();
            int y = int.Parse(info[0]) - 1;
            int x = int.Parse(info[1]) - 1;
            string name = info[2];
            int atk = int.Parse(info[3]);
            int def = int.Parse(info[4]);
            int maxHp = int.Parse(info[5]);
            int exp = int.Parse(info[6]);
            bool isBoss = y == bossY && x == bossX;
            monsters[(y, x)] = new Monster(name, atk, def, maxHp, exp, isBoss);
        }

        for (int i = 0; i < itemBoxCount; i++)
        {
            string[] info = sr.ReadLine().Split();

            int y = int.Parse(info[0]) - 1;
            int x = int.Parse(info[1]) - 1;
            char type = info[2][0];
            switch (type)
            {
            case 'W':
            case 'A':
                int power = int.Parse(info[3]);
                items[(y, x)] = new Item(type, power);
                break;
            case 'O':
                AType aType = (AType)Enum.Parse(typeof(AType), info[3]);
                items[(y, x)] = new Item(aType);
                break;
            }
        }

        // game loop
        int gameEnd = 0;
        int turn = 0;
        for (int i = 0; i < command.Length; i++)
        {
            turn++;
            int dy = 0, dx = 0;
            // 새 위치 파악
            switch (command[i])
            {
            case 'L':
                dx = -1;
                break;
            case 'R':
                dx = 1;
                break;
            case 'U':
                dy = -1;
                break;
            case 'D':
                dy = 1;
                break;
            }
            // 범위에 벗어나는지 확인
            if (player.y + dy >= 0 && player.y + dy < N && player.x + dx >= 0 && player.x + dx < M)
            {
                // 새로운 곳에 무엇이 있는지 확인
                switch (grid[player.y + dy][player.x + dx])
                {
                // 빈 공간 - 그대로 이동
                case '.':
                case '^':
                    player.y += dy;
                    player.x += dx;
                    break;
                // 아이템 획득
                case 'B':
                    if (items.ContainsKey((player.y + dy, player.x + dx)))
                    {
                        Item item = items[(player.y + dy, player.x + dx)];
                        switch (item.itemType)
                        {
                        case IType.Weapon:
                            player.weaponAtk = item.power;
                            break;
                        case IType.Armor:
                            player.armorDef = item.power;
                            break;
                        case IType.Accessory:
                            if (!player.AccessoryCheck(item.accessoryType) && !player.AccessoryFull())
                        
                            {
                                 player.accessories.Add(item.accessoryType);
                            }
                            break;
                        }
                        // 아이템 제거
                        items.Remove((player.y + dy, player.x + dx));
                        grid[player.y + dy][player.x + dx] = '.';
                        player.y += dy;
                        player.x += dx;
                    }
                break;
                    
            case '#':
                break;
            // 몬스터 배틀
            case '&':
            case 'M':
                Monster monster = monsters[(player.y + dy, player.x + dx)];
                int result = Battle(monster);
                if (result == 1)
                {
                    // HR 장신구가 있을 경우 체력이 3 회복된다.
                    if (player.AccessoryCheck(AType.HR))
                    {
                        player.hp = Math.Min(player.maxHp, player.hp + 3);
                    }
                    // 죽은 몬스터가 보스인지 확인
                    if (monster.isBoss)
                    {
                        gameEnd = 1;
                    }
                    // 죽은 몬스터 제거
                    monsters.Remove((player.y + dy, player.x + dx));
                    grid[player.y + dy][player.x + dx] = '.';
                    // 이동
                    player.y += dy;
                    player.x += dx;               
                }
                break;
                }
            }
            

            // 함정을 밟았는지 체크 - 플레이어가 몬스터와의 전투에서 죽은 경우에는 체크하지 않음
            if (grid[player.y][player.x] == '^' && player.isAlive)
                player.TrapTrigger();
            // 플레이어 생존 여부
            if (!player.isAlive)
            {
                gameEnd = 2;
                break;
            }

            if (gameEnd == 1)
                break;
        }
        // result
        // grid 상태
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (player.isAlive && (player.y == i && player.x == j))
                {
                    Console.Write("@");
                }
                else
                {
                    Console.Write(grid[i][j]);
                }
            }
            Console.WriteLine();
        }
        // player info
        Console.WriteLine($"Passed Turns : {turn}");
        Console.WriteLine($"LV : {player.lv}");
        Console.WriteLine($"HP : {player.hp}/{player.maxHp}");
        Console.WriteLine($"ATT : {player.atk}+{player.weaponAtk}");
        Console.WriteLine($"DEF : {player.def}+{player.armorDef}");
        Console.WriteLine($"EXP : {player.curExp}/{player.maxExp}");
        // end message
        if (gameEnd == 1)
        {
            Console.WriteLine("YOU WIN!");
        }
        else if (gameEnd == 2)
        {
            Console.WriteLine($"YOU HAVE BEEN KILLED BY {player.killedBy}..");
        }
        else
        {
            Console.WriteLine("Press any key to continue.");
        }
        sr.Close();
    }
}
