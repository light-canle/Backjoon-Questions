// p24390 - 또 전자레인지야? (S2)
// #그리디
// 2026.2.15 solved

/*
누를 수 있는 버튼 : 10초, 1분, 10분, 시작 버튼
시작 버튼을 누르면 0초인 경우 조리 시작과 동시에 30초 충전, 
조리 중이 아닌데 시간이 있으면 그냥 조리 시작, 이미 조리 중인 경우 30초 증가
목표는 1) 지정된 시간에 정확히 맞추면서 2) 조리 시작된 상태를 만드는 것이다.

풀이
AA:BB로 시간이 주어지면 분과 초로 나누어 생각한다. (BB는 10의 배수) - 시작 버튼을 여러 번 누르는 것 보다 1분 버튼을 누르는 것이 분 단위 시간을 맞추는데 효율적이기 때문
BB가 30 이상인 경우 조리 시작을 처음에 눌러 30초 + 조리 시작 상태로 만든 뒤 10초 버튼을 필요한 만큼 누른다.
30 미만인 경우에는 10초 버튼을 눌러서 BB를 맞춘 뒤 시작 버튼을 누른다. 이렇게 되면 시간이 추가되지 않는다.
AA는 10분 버튼을 AA / 10회, 1분 버튼을 AA % 10회 눌러서 맞춘다.
*/

int[] time = Array.ConvertAll(Console.ReadLine().Split(":"), int.Parse);
int minute = time[0], second = time[1];

int minPress = 0;
if (second >= 30)
{
    minPress = (second - 30) / 10 + 1;
}
else
{
    minPress = second / 10 + 1;
}
minPress += minute / 10;
minPress += minute % 10;
Console.WriteLine(minPress);
