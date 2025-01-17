#define _CRT_SECURE_NO_WARNINGS
#include "Log.h"
#include "Error.h"
#include "IT.h"
#include "LT.h"
#include <fstream>
#include <stdarg.h>
#include <iostream>
#include <ctime>


using namespace std;

namespace Log {
	LOG getlog(wchar_t logfile[]) {
		LOG log{};
		wcscpy_s(log.logfile, logfile);
		log.stream = new ofstream(logfile);
		if (!log.stream->is_open()) {
			throw ERROR_THROW(112)
		}
		return log;
	}

	void WriteLine(LOG log, char* c, ...) {
		char str[80]{};
		char** p = &c;
		while (*p[0]) {
			strcat_s(str, *p);
			p++;
		}
		str[strlen(str)] = '\0';
		(*log.stream) << str;
	}

	void WriteLine(LOG log, wchar_t* c, ...) {
		wchar_t strw[300]{};
		char str[300]{};
		wchar_t** p = &c;
		while (*p[0]) {
			wcscat_s(strw, *p);
			p++;
		}
		wcstombs(str, strw, sizeof(strw));
		(*log.stream) << str;
	}

	void WriteLog(LOG log) {
		std::time_t t = std::time(nullptr);
		std::tm* now = std::localtime(&t);
		(*log.stream) << "----��������-----" << now->tm_mday << "." << now->tm_mon + 1 << "." <<
			now->tm_year + 1900 << " " << now->tm_hour << ":" << now->tm_min << ":" << now->tm_sec << "----" << endl;
	}

	void WriteParm(LOG log, Parm::PARM parm) {
		char str[300]{};
		(*log.stream) << "----���������-----" << endl;
		wcstombs(str, parm.log, sizeof(parm.log));
		(*log.stream) << "-log: " << str << endl;
		wcstombs(str, parm.out, sizeof(parm.out));
		(*log.stream) << "-out: " << str << endl;
		wcstombs(str, parm.in, sizeof(parm.in));
		(*log.stream) << "-in: " << str << endl;
	}

	void WriteIn(LOG log, In::IN in) {
		(*log.stream) << "----�������� ������-----" << endl;
		(*log.stream) << "���������� ��������: " << in.size << endl;
		(*log.stream) << "���������������: " << in.ignor << endl;
		(*log.stream) << "���������� �����: " << in.lines << endl;
	}

	void WriteError(LOG log, Error::ERROR error) {
		(*log.stream) << "������ " << error.id << " :" << error.message << ", ������ " << error.inext.line << ", ������� " << error.inext.col;
	}

	void WriteTables(LOG log, IT::IdTable& idtable, LT::LexTable& lextable) {
		int line = 0;
		for (int i = 0; i < lextable.size; i++) {
			if (line != lextable.table[i].sn) {
				(*log.stream) << "\n" << line + 1 << " ";
				line++;
			}
			(*log.stream) << lextable.table[i].lexema;
		}
		(*log.stream) << "\n\n";

		for (int i = 0; i < idtable.size; i++) {
			(*log.stream) << idtable.table[i].id << " ������ ��������� � ������� ������: " << idtable.table[i].idxfirstLE << " ���: " << idtable.table[i].idtype << " ��� ������: " << idtable.table[i].iddatatype << "\n";
		}
	}

	void Close(LOG log) {
		puts("��������� ���������");
		(*log.stream).close();
	}
}