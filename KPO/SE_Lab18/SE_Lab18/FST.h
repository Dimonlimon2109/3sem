#pragma once
#include <iostream>
#include "In.h"
#include "LT.h"
#include "IT.h"

namespace FST {
	struct RELATION {
		char symbol;
		short nnode;
		RELATION(
			char c = 0x00,
			short ns = NULL
		);
	};

	struct NODE {
		short n_relation;
		RELATION* relations;
		NODE();
		NODE(
			short n,
			RELATION rel, ...
		);
	};

	struct FST {
		char* string;
		short position;
		short nstates;
		NODE* nodes;
		short* rstates;
		FST(
			char* s,
			short ns,
			NODE n, ...
			);
		void FSTreturn() {
			this->position = -1;
			this->rstates[0] = 0;
		}
	};

	struct FSTAssigned {
		FST* fst;
		IT::IDDATATYPE iddatatype;
		char lex;
		FSTAssigned(FST* f, IT::IDDATATYPE i, char l) {
			fst = f;
			iddatatype = i;
			lex = l;
		}
	};

	bool execute(
				FST& fst
				); 

	void Analyzer();

	void Analyze(In::IN in, LT::LexTable& lextable, IT::IdTable& idtable);
}