#define _CRT_SECURE_NO_WARNINGS

#include "Out.h"
#include "In.h"
#include "Parm.h"
#include <fstream>
#include <iostream>

namespace Out {
	void WriteOut(In::IN in, Parm::PARM parms) {
		std::wofstream fout(parms.out);
		char str[600]{};
		wcstombs(str, in.text, in.size);
		fout << str;
		fout.close();
	}

	void WriteError(Error::ERROR err, Parm::PARM parms) {
		std::wofstream fout(parms.out);
		fout << "Ошибка " << err.id << " :" << err.message << ", строка " << err.inext.line << ", позиция " << err.inext.col;
		fout.close();
	}
}