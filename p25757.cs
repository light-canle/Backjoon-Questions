// p25757 - 임스와 함께하는 미니게임 (S5)
// #맵 #문자열
// 2026.2.21 solved (2.20)

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
string[] input = sr.ReadLine().Split();
int n = int.Parse(input[0]);
int need = 0; // 한 게임을 하기 위해 필요한 자신을 제외한 사람 수
switch(input[1])
{
    case "Y": need = 1; break;
    case "F": need = 2; break;
    case "O": need = 3; break;
}
// 이미 플레이 한 사람의 명단
// 딕셔너리를 사용하는 이유는 이미 있는 키를 O(1)에 찾을 수 있기 때문
Dictionary<string, bool> alreadyPlayed = new();
// 놀 수 있는 횟수
int canPlayTime = 0;
// 현재 모인 사람 수
int curPeople = 0;
for (int i = 0; i < n; i++)
{
    string name = sr.ReadLine();
    // 이미 플레이 한 사람이면 건너뜀
    if (alreadyPlayed.ContainsKey(name)) continue;
    alreadyPlayed[name] = true;
    // 현재 모인 사람에 추가
    curPeople++;
    // 다 모이면 게임 횟수 증가
    if (curPeople == need)
    {
        curPeople = 0;
        canPlayTime++;
    }
}
Console.WriteLine(canPlayTime);
