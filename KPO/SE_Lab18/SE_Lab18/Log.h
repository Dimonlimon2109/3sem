#pragma once

#include <fstream>
#include "In.h"
#include "IT.h"
#include "LT.h"
#include "Error.h"
#include "Parm.h"

namespace Log {
	struct LOG {
		wchar_t logfile[PARM_MAX_SIZE];
		std::ofstream* stream;
	};

	static const LOG INITLOG {L"", nullptr};
	LOG getlog(wchar_t logfile[]);
	void WriteLine(LOG log, char* c, ...);
	void WriteLine(LOG log, wchar_t* c, ...);
	void WriteLog(LOG log);
	void WriteParm(LOG log, Parm::PARM parm);
	void WriteIn(LOG log, In::IN in);
	void WriteError(LOG log, Error::ERROR error);
	void WriteTables(LOG log, IT::IdTable& idtable, LT::LexTable& lextable);
	void Close(LOG log);
}