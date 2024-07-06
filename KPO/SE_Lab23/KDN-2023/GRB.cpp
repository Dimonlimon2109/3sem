#define _CRT_SECURE_NO_WARNINGS
#include "GRB.h"
#include <iostream>

typedef short GRBALPHABET;

#define GRB_ERROR_SERIES 600

using namespace std;

namespace GRB {
	#define NS(n) Rule::Chain::N(n)
	#define TS(n) Rule::Chain::T(n)	

	Greibach greibach(NS('S'), TS('$'),
		5,
		Rule(NS('S'), GRB_ERROR_SERIES + 0,
			2,
			Rule::Chain(7, TS('m'), TS('{'), NS('N'), TS('r'), NS('R'), TS('}'), TS(';')),
			Rule::Chain(14, TS('d'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS('{'), NS('N'), TS('r'), NS('R'), TS('}'), TS(';'), NS('S'))
		),
		Rule(NS('N'), GRB_ERROR_SERIES + 1,
			14,
			Rule::Chain(4, TS('d'), TS('t'), TS('i'), TS(';')),
			Rule::Chain(3, TS('p'), TS('i'), NS('N')),
			Rule::Chain(5, TS('d'), TS('t'), TS('i'), TS(';'), NS('N')),
			Rule::Chain(4, TS('i'), TS('v'), NS('E'), TS(';')),
			Rule::Chain(5, TS('i'), TS('v'), NS('E'), TS(';'), NS('N')),
			Rule::Chain(4, TS('p'), TS('i'), TS(';'), NS('N')),
			Rule::Chain(3, TS('p'), TS('i'), TS(';')),
			Rule::Chain(4, TS('p'), TS('l'), TS(';'), NS('N')),
			Rule::Chain(3, TS('p'), TS('l'), TS(';')),
			Rule::Chain(13, TS('d'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS('{'), NS('N'), TS('r'), NS('R'), TS('}'), TS(';')),
			Rule::Chain(14, TS('d'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS('{'), NS('N'), TS('r'), NS('R'), TS('}'), TS(';'), NS('N')),
			Rule::Chain(8, TS('d'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS(';')),
			Rule::Chain(9, TS('d'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS(';'), NS('N')),
			Rule::Chain(5, TS('i'), TS('('), NS('F'), TS(')'), TS(';'))

		),
		Rule(NS('R'), GRB_ERROR_SERIES + 2, 
			2,
			Rule::Chain(2, TS('i'), TS(';')),
			Rule::Chain(2, TS('l'), TS(';'))
		),
		Rule(NS('F'), GRB_ERROR_SERIES + 3,
			6,
			Rule::Chain(2, TS('t'), TS('i')),
			Rule::Chain(4, TS('t'), TS('i'), TS(','), NS('F')),
			Rule::Chain(1, TS('i')),
			Rule::Chain(3, TS('i'), TS(','), NS('F')),
			Rule::Chain(1, TS('l')),
			Rule::Chain(3, TS('l'), TS(','), NS('F'))
		),
		Rule(NS('E'), GRB_ERROR_SERIES + 4,
			9,
			Rule::Chain(1, TS('i')),
			Rule::Chain(2, TS('v'), TS('i')),
			Rule::Chain(1, TS('l')),
			Rule::Chain(2, TS('v'), TS('l')),
			Rule::Chain(3, TS('('), NS('E'), TS(')')),
			Rule::Chain(3, TS('i'), TS('v'), NS('E')),
			Rule::Chain(3, TS('l'), TS('v'), NS('E')),
			Rule::Chain(4, TS('i'), TS('('), NS('F'), TS(')')),
			Rule::Chain(5, TS('i'), TS('('), NS('F'), TS(')'), NS('E'))
		)
	);



	Rule::Chain::Chain(short psize, GRBALPHABET s, ...) {
	    int* p = (int*) & s;
		size = psize;
		nt = new GRBALPHABET[psize];
		for (int i = 0; i < psize; i++) {
			nt[i] = (short)p[i];
		}
	}

	char* Rule::Chain::getCChain(char* b) {
		for (int i = 0; i < size; i++) {
			b[i] = alphabet_to_char(this->nt[i]);
		}
		b[size] = 0;
		return b;
	}

	Rule::Rule(
		GRBALPHABET pnn,
		int iderror,
		short psize,
		Chain c, ...
	) {
		this->nn = pnn;
		this->iderror = iderror;
		this->size = psize;
		this->chains = new Chain[psize];
		Chain* p = &c;
		for (short i = 0; i < psize; i++) {
			this->chains[i] = p[i];
		}
	}

	char* Rule::getCRule(char* b, short nchain) {
		char* bchain = new char[this->chains[nchain].size];
		b[0] = Chain::alphabet_to_char(this->nn);
		b[1] = '-';
		b[2] = '>';
		b[3] = 0;
		this->chains[nchain].getCChain(bchain);
		strcat(b, bchain);
		return b;
	}

	short Rule::getNextChain(GRBALPHABET t, Rule::Chain& pchain, short j) {
		while (j < this->size && chains[j].nt[0] != t) {
			j++;
		}
		if (j != this->size && chains[j].nt[0] == t) {
			if (j < this->size) {
				pchain = chains[j];
				return j;
			}
		}
		return -1;
	}

	Greibach::Greibach(GRBALPHABET pstartN, GRBALPHABET pstbottomT, short psize, Rule r, ...) {
		this->startN = pstartN;
		this->stbottomT = pstbottomT;
		this->size = psize;
		this->rules = new Rule[psize];
		Rule* p = &r;
		for (short i = 0; i < psize; i++) {
			this->rules[i] = p[i];
		}
	}

	short Greibach::getRule(GRBALPHABET pnn, Rule& prule) {
		short i = 0;
		while (i < this->size && this->rules[i].nn != pnn) {
			i++;
		}
		if (i != this->size && i < size) {
			prule = this->rules[i];
			return i;
		}
		return -1;
	}

	Rule Greibach::getRule(short n) {
		if (this->size < n) {
			throw ERROR_THROW(600);
		}
		return this->rules[n];
	}

	Greibach getGreibach() {
		return greibach;
	}
}