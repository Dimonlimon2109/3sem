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
		fout << "������ " << err.id << " :" << err.message << ", ������ " << err.inext.line << ", ������� " << err.inext.col;
		fout.close();
	}
}