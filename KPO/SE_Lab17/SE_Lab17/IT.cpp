#include "IT.h"
#include "Error.h"
#include <string.h>

namespace IT {
	IdTable Create(int size) {
		if (size > TI_MAXSIZE) {
			throw ERROR_THROW(116)
		}
		IdTable* idtable = new IdTable();
		idtable->maxsize = size; //- 150;
		idtable->size = 0;
		idtable->table = new Entry[idtable->maxsize];
		return *idtable;
	}

	void Add(IdTable& idtable, Entry entry) {
		if (idtable.size + 1 > idtable.maxsize) {
			throw ERROR_THROW(117);
		}
		idtable.table[idtable.size] = entry;
		idtable.size++;
	}

	Entry GetEntry(IdTable& idtable, int n) {
		return idtable.table[n];
	}

	int IsId(IdTable& idtable, char id[ID_MAXSIZE]) {
		for (int i = 0; i < idtable.size; i++) {
			if (strcmp(idtable.table[i].id, id) == 0) {
				return i;
			}
		}
		return TI_NULLIDX;
	}

	void Delete(IdTable& idtable) {
		delete[] idtable.table;
		delete &idtable;
	}
}