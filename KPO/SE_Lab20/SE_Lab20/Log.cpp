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
		(*log.stream) << "----Протокол-----" << now->tm_mday << "." << now->tm_mon + 1 << "." <<
			now->tm_year + 1900 << " " << now->tm_hour << ":" << now->tm_min << ":" << now->tm_sec << "----" << endl;
	}

	void WriteParm(LOG log, Parm::PARM parm) {
		char str[300]{};
		(*log.stream) << "----Параметры-----" << endl;
		wcstombs(str, parm.log, sizeof(parm.log));
		(*log.stream) << "-log: " << str << endl;
		wcstombs(str, parm.out, sizeof(parm.out));
		(*log.stream) << "-out: " << str << endl;
		wcstombs(str, parm.in, sizeof(parm.in));
		(*log.stream) << "-in: " << str << endl;
	}

	void WriteIn(LOG log, In::IN in) {
		(*log.stream) << "----Исходные данные-----" << endl;
		(*log.stream) << "Количество символов: " << in.size << endl;
		(*log.stream) << "Проигнорировано: " << in.ignor << endl;
		(*log.stream) << "Количество строк: " << in.lines << endl;
	}

	void WriteError(LOG log, Error::ERROR error) {
		(*log.stream) << "Ошибка " << error.id << " :" << error.message << ", строка " << error.inext.line << ", позиция " << error.inext.col;
	}

	void WriteTables(LOG log, IT::IdTable& idtable, LT::LexTable& lextable) {
		int line = 0;
		for (int i = 0; i < lextable.size; i++) {
			if (line != lextable.table[i].sn) {
				(*log.stream) << "\n" << lextable.table[i].sn << " ";
				line = lextable.table[i].sn;
			}
			(*log.stream) << lextable.table[i].lexema;
		}
		(*log.stream) << "\n\n";
		for (int i = 0; i < idtable.size; i++) {
			(*log.stream) << idtable.table[i].id << " Первое вхождение в таблицу лексем: " << idtable.table[i].idxfirstLE << " Тип: " << idtable.table[i].idtype << " Тип данных: " << idtable.table[i].iddatatype << "\n";
		}
	}

	void Close(LOG log) {
		puts("Программа выполнена");
		(*log.stream).close();
	}
}