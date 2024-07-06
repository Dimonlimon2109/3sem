#include <iostream>
#include <Windows.h>
using namespace std;
void hanoi(int, int, int, int);

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    int d, s1, s2, middle;

    cout << "Введите кол-во дисков: ", cin >> d;
    cout << "i-й стержень ,на котором находятся диски изначально: ", cin >> s1;
    cout << "k-й стержень ,на который вы хотите переместить диски: ", cin >> s2;

    if (d == 1)
    {
        cout << "Переместить диск " << d << " c " << s1 << " на " << s2 << " стержень\n";
        return 0;
    }

    if (d < 1) cout << "Необходимо использовать минимум один диск!";
    middle = 6 - s1 - s2;

    hanoi(d, s1, s2, middle);
 }

void hanoi(int blocks, int s1, int s2, int middle)
{
    if (blocks != 0)
    {
        hanoi(blocks - 1, s1, middle, s2);
        cout << "Переместить диск " << blocks << " c " << s1 << " на " << s2 << " стержень\n";
        hanoi(blocks - 1, middle, s2, s1);
    }
}