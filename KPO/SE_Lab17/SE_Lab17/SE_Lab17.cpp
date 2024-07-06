﻿#include <iostream>
#include <cwchar>
#include <tchar.h>

#include "Error.h"
#include "Parm.h"
#include "In.h"
#include "Log.h"
#include "out.h"
#include "LT.h"
#include "IT.h"
#include "FST.h"

using namespace std;

int _tmain(int argc, wchar_t* argv[]) {
	setlocale(LC_ALL, "rus");
	Log::LOG log = Log::INITLOG;
	Parm::PARM parms;
	try {
		parms = Parm::getparm(argc, argv);
		log = Log::getlog(parms.log);
		Log::WriteLine(log, (char*)"Тест:", (char*)" без ошибок \n", "");
		Log::WriteLine(log, (wchar_t*)L"Тест:", (wchar_t*)L" без ошибок \n", L"");
		Log::WriteLog(log);
		Log::WriteParm(log, parms);
		In::IN in = In::getin(parms.in);
		Log::WriteIn(log, in);
		Out::WriteOut(in, parms);
		LT::LexTable lextable = LT::Create(in.lexems.size());
		IT::IdTable idtable = IT::Create(in.lexems.size());
		for (int i = 0; i < in.lexems.size(); i++) {
			cout << in.lexems[i].lexem << "\n";
		}
		FST::Analyze(in, lextable, idtable);
		Log::WriteTables(log, idtable, lextable);
		Log::Close(log);
	}
	catch (Error::ERROR e) {
		Log::WriteError(log, e);
		Out::WriteError(e, parms);
	}

	system("pause");
	return 0;
}