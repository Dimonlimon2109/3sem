#pragma once

#include "IT.h"
#include "LT.h"
#include "LEX.h"

namespace PolishNotation {
	bool PolishNotation(int pos, LT::LexTable& lextable, IT::IdTable& idtable);
	void CreatePolishTable(LEX::LEX&lex);
}