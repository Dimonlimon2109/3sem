#pragma once

#include "IT.h" 
#include "LT.h"

namespace LEX {
	struct LEX {
		IT::IdTable idtable;
		LT::LexTable lextable;

		LEX(LT::LexTable llextable, IT::IdTable iidtable) {
			this->idtable = iidtable;
			this->lextable = llextable;
		}

		LEX() {};
	};
}