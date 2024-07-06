#include "FST.h"
#include <iostream>
#include "tchar.h"

using namespace std;

int _tmain(int argc, wchar_t* argv[])
{
	setlocale(LC_ALL, "rus");

	FST::FST fst(
		(char*)"main wait; show; show; send;  return;",
		26,
		FST::NODE(1, FST::RELATION('m', 1)),//0
		FST::NODE(1, FST::RELATION('a', 2)),//1
		FST::NODE(1, FST::RELATION('i', 3)),//2
		FST::NODE(1, FST::RELATION('n', 4)),//3
		FST::NODE(3, FST::RELATION(' ', 4), FST::RELATION(' ', 5), FST::RELATION(' ',17 )),//4
		FST::NODE(3, FST::RELATION('s', 6), FST::RELATION('w', 9), FST::RELATION('s', 12)),//5
		FST::NODE(1, FST::RELATION('e', 7)),//6
		FST::NODE(1, FST::RELATION('n', 8)),//7
		FST::NODE(1, FST::RELATION('d', 15)),//8
		FST::NODE(1, FST::RELATION('a', 10)),//9
		FST::NODE(1, FST::RELATION('i', 11)),//10
		FST::NODE(1, FST::RELATION('t', 15)),//11
		FST::NODE(1, FST::RELATION('h', 13)),//12
		FST::NODE(1, FST::RELATION('o', 14)),//13
		FST::NODE(1, FST::RELATION('w', 15)),//14
		FST::NODE(1, FST::RELATION(';', 16)),//15
		FST::NODE(3, FST::RELATION(' ', 16), FST::RELATION(' ', 5), FST::RELATION(' ', 17)),//16
		FST::NODE(2, FST::RELATION(' ', 17), FST::RELATION(' ', 18)),//17
		FST::NODE(1, FST::RELATION('r', 19)),//18
		FST::NODE(1, FST::RELATION('e', 20)),//19
		FST::NODE(1, FST::RELATION('t', 21)),//20
		FST::NODE(1, FST::RELATION('u', 22)),//21
		FST::NODE(1, FST::RELATION('r', 23)),//22
		FST::NODE(1, FST::RELATION('n', 24)),//23
		FST::NODE(1, FST::RELATION(';', 25)),//24
		FST::NODE()//25
	);
	
	
	if (FST::execute(fst)) {
		cout << "Цепочка " << fst.string << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst.string << " не распознана" << endl;
	}
	
}