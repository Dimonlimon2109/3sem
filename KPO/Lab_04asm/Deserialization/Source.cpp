#include "stdaxf.h"
#include "Deserialization.h"
#include <windows.h>

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	Deserialization::Deserialize((char*)"D:\\study\\3_sem\\KPO\\Lab_04asm\\Serialization\\ser.txt");
}