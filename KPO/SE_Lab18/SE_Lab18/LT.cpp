#include "LT.h"
#include "Error.h"

namespace LT {
	LexTable Create(int size) {
		if (size > LT_MAXSIZE) {
			ERROR_THROW(114);
		}
		LexTable* lextable = new LexTable();
		lextable->maxsize = size;
		lextable->size = 0;
		lextable->table = new Entry[lextable->maxsize];
		return *lextable;
	}

	void Add(LexTable& lextable, Entry entry) {
		if (lextable.size + 1 > lextable.maxsize) {
			ERROR_THROW(115);
		}
		lextable.table[lextable.size] = entry;
		lextable.size++;
	}

	Entry GetEntry(LexTable& lextable, int n) {
		return lextable.table[n];
	}

	void Delete(LexTable& lextable) {
		delete[] lextable.table;
		delete &lextable;
	}
}
