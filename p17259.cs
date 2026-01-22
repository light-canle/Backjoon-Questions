#pragma warning disable CS8604, CS8602, CS8600

// p17259 - 선물이 넘쳐흘러 (G4)
// #구현 #시뮬레이션
// 2026.1.22 solved

public class Employee
{
    public List<int> canPickPosition; // 상하좌우 컨베이어 벨트 위치
    public int time; // 포장에 걸리는 시간
    public int currentTime; // 포장 경과 시간
    public bool hasGift; // 선물을 포장 중인가?

    public Employee(int time)
    {
        this.canPickPosition = new();
        this.time = time;
        this.currentTime = 0;
        this.hasGift = false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int factorySize = input[0], employee = input[1], gift = input[2];

        List<Employee> list = new();
        (int x, int y)[] diff = { (1, 0), (-1, 0), (0, -1), (0, 1) };
        for (int i = 0; i < employee; i++)
        {
            int[] info = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int y = info[0], x = info[1], time = info[2];
            list.Add(new(time));
            // 자신의 위치 상하좌우에 있는 컨베이어 벨트 조사
            foreach (var d in diff)
            {
                int dx = x + d.x, dy = y + d.y;
                // 인덱스 초과
                if (dx < 0 || dx >= factorySize) continue;
                if (dy < 0 || dy >= factorySize) continue;
                // 해당 위치에 컨베이어 벨트가 있는가?
                int onBelt = OnConveyorBelt(dy, dx, factorySize);
                if (onBelt != -1)
                {
                    list[i].canPickPosition.Add(onBelt);
                }
            }
            // 오래 올려진 선물을 먼저 잡아야 하므로 리스트를 역순 정렬함
            list[i].canPickPosition.Sort();
            list[i].canPickPosition.Reverse();
        }

        // 모든 선물이 컨베이어 벨트를 통과하거나 포장될 때까지 시뮬레이션
        int length = 3 * factorySize - 2;
        bool[] conveyorBelt = new bool[length + 1]; // index 0은 미사용
        int curGift = 0;
        int packedGift = 0;
        while (true)
        {
            // 선물을 올린다.
            if (curGift < gift)
            {
                conveyorBelt[1] = true;
                curGift++;
            }
            // 만약 컨베이어 벨트에 선물이 없다면 시뮬레이션 종료
            bool isEmpty = true;
            for (int i = 0; i < length; i++) 
                isEmpty &= !conveyorBelt[i];
            if (isEmpty) break;

            // 직원들이 포장 중이 아니라면 선물을 집는다.
            foreach (var emp in list)
            {
                if (emp.hasGift) continue;
                foreach (int pos in emp.canPickPosition)
                {
                    // 현재 위치에 선물이 존재함
                    if (conveyorBelt[pos])
                    {
                        conveyorBelt[pos] = false;
                        packedGift++;
                        emp.hasGift = true;
                        break;
                    }
                }
            }
            // 컨베이어 벨트 위 선물 1칸씩 이동
            for (int i = length; i > 1; i--)
            {
                conveyorBelt[i] = conveyorBelt[i - 1];
            }
            conveyorBelt[1] = false;

            // 포장 시간 경과
            foreach (var emp in list)
            {
                if (!emp.hasGift) continue;
                emp.currentTime++;
                // 포장 완료
                if (emp.currentTime == emp.time)
                {
                    emp.currentTime = 0;
                    emp.hasGift = false;
                }
            }
        }

        // 포장한 선물의 개수 출력
        Console.WriteLine(packedGift);
    }

    // 해당 위치에 컨베이어 벨트가 있는지 판정
    // 있으면 몇 번째 컨베이어 벨트인지 순서를 반환 (첫 칸이 1), 없으면 -1
    public static int OnConveyorBelt(int y, int x, int factorySize)
    {
        if (y == 0)
        {
            return x + 1;
        }
        else if (y == factorySize - 1)
        {
            return 3 * factorySize - x - 2;
        }
        else if (x == factorySize - 1)
        {
            return factorySize + y;
        }
        else
        {
            return -1;
        }
    }
}
