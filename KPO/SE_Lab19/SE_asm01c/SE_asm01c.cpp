#include <iostream>
#pragma comment(lib, "SE_Asm01a.lib")

using namespace std;

extern "C"
{
	int _stdcall getmin(int, int*);
	int _stdcall getmax(int, int*);
}

int main() {
	int* mas = new int[10];
	for (int i = 0; i < 10; i++) {
		mas[i] = i + 1;
	}
	int min = getmin(10, mas);
	int max = getmax(10, mas);
	cout << "getmin + getmax = " << min + max;
}