#include "stdafx.h"
#include "Serialization.h"

void main() {
	bool bools[] = {true, false};
	char chars[][10] = { {'a','b','c','d','e','f'}, {'g','h','z','x','c'} };
	int sizes[] = { 6,5 };
	Serialization::Serialize((char*)"D:\\study\\3_sem\\KPO\\Lab_04asm\\Serialization\\ser.txt", bools, 2);
	Serialization::Serialize((char*)"D:\\study\\3_sem\\KPO\\Lab_04asm\\Serialization\\ser.txt", chars, 2, sizes);
}